using UnityEngine;
using Random = System.Random;

public class FoodAgent : MonoBehaviour
{
    /*STATUS*/
    private State _state = State.SearchFood;
    private bool _tick;
    private int _foodCount;
    
    /*TARGETS*/
    private Vector3 _targetPoint;
    private IFood _food;
    private FoodAgent _targetMate;
    
    /*SETTINGS*/
    private readonly float _speed = 2f;
    
    /*REF AND DECL*/
    private IFoodFinder _foodFinder;
    private static readonly Random random = new();

    private void OnEnable() => GameManager.OnTick += OnStateChanged;
    private void OnDisable() => GameManager.OnTick -= OnStateChanged;

    private void OnStateChanged(bool b)
    {
        _tick = b;
        if(!b && _foodCount < GlobalSettings.FoodToSurvive) Destroy(gameObject);
        
        _foodCount = 0;
        _state = State.SearchFood;
    }


    private void Awake()
    {
        _targetPoint = transform.position;
        _foodFinder = GetComponent<IFoodFinder>();
    }

    private void Update()
    {
        if (!_tick) return;

        switch (_state)
        {
            case State.SearchFood:
                _food ??= _foodFinder.FindFood();
                if (_food != null)
                {
                    _targetPoint = _food.Transform.position;
                    _state = State.Eat;
                    break;
                }
                
                if (Move()) _targetPoint = transform.position + new Vector3(random.Next(-2, 3), 0f, random.Next(-2, 3));

                break;
            
            case State.Eat:
                if (_food == null)
                {
                    _state = State.SearchFood;
                    break;
                }

                if(Move())
                {
                    _food.EatFood();
                    _food = null;

                    _foodCount++;
                    
                    _state = _foodCount >= GlobalSettings.FoodToRep ? State.SearchMate : State.SearchFood;
                }
                break;
            
            case State.SearchMate:
                if(_targetMate is null) LookForMate();
                
                if (Move()) _targetPoint = transform.position + new Vector3(random.Next(-2, 3), 0f, random.Next(-2, 3));
                break;
            
            case State.Reproduce:
                if (Move())
                {
                    print("new baby");
                    _state = State.Basic;
                }
                break;

            case State.Basic:
                break;
        }
    }

    private bool Move()
    {
        var pos = transform.position;
        if (Vector3.Distance(pos, _targetPoint) < 0.1f) return true;
        
        transform.position = Vector3.MoveTowards(pos, _targetPoint, _speed * Time.deltaTime);
        return false;

    }
    
    private void LookForMate()
    {
        var hits = new Collider[4];
        var i = Physics.OverlapBoxNonAlloc(transform.position, Vector3.one * 4f, hits, Quaternion.identity, 1 << 8);

        if (i <= 0) return;
        
        for (var j = 0; j < i; j++)
        {
            if (!hits[j].TryGetComponent(out FoodAgent agent)) continue;
            if(agent == this) continue;
            PotentialMateFound(agent);
            
            if (_targetMate is not null) break;
        }
    }
    private void PotentialMateFound(FoodAgent female)
    {
        var accepted = female.RequestMate(this);

        if (accepted)
        {
            _targetMate = female;
            _targetPoint = Vector3.Lerp(transform.position, female.transform.position, 0.5f);;
            _state = State.Reproduce;
        }
        else
        {
            //_unimpressedFemales.Add(female);
        }
    }
    
    private bool RequestMate(FoodAgent male)
    {
        if (_targetMate is not null || _state != State.SearchMate) return false;
        //if ((float)random.NextDouble() >= 0.8f) return false;
        
        _targetMate = male;
        _targetPoint = Vector3.Lerp(transform.position, male.transform.position, 0.5f);
        _state = State.Reproduce;
        
        return true;
    }
}