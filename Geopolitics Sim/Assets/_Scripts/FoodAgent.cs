using UnityEngine;
using Random = System.Random;

public class FoodAgent : MonoBehaviour
{
    private State _state = State.SearchFood;
    private bool _tick;
    private readonly float _speed = 2f;
    private static readonly Random random = new();

    private Vector3 _targetPoint;
    
    private IFood _food;
    private IFoodFinder _foodFinder;
    private FoodAgent _targetMate;

    private void OnEnable() => GameManager.OnTick += OnStateChanged;
    private void OnDisable() => GameManager.OnTick -= OnStateChanged;

    private void OnStateChanged(bool b) => _tick = b;


    private void Awake()
    {
        _targetPoint = transform.position;
        _foodFinder = GetComponent<IFoodFinder>();
    }

    private void Update()
    {
        if(!_tick) return;
        
        switch (_state)
        {
            case State.SearchFood:
                _food ??= _foodFinder.FindFood();
                if (_food != null)
                {
                    _targetPoint = _food.Position;
                    _state = State.Eat;
                    return;
                }
                
                if (Move()) _targetPoint = transform.position + new Vector3(random.Next(-2, 3), 0f, random.Next(-2, 3));

                break;
            
            case State.Eat:
                if (_food == null)
                {
                    _state = State.SearchFood;
                    return;
                }
                
                if(Move())
                {
                    _food.EatFood();
                    _state = State.Reproduce;
                }
                break;
            
            case State.SearchMate:
                break;
            
            case State.Reproduce:
                
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
}