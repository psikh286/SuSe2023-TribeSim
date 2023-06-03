using System;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class FoodAgentTree : BTree
{
    public static Action OnAgentSpawn;
    private int _colorIndex;

    
    /*INITIALIZE*/
    [field: SerializeField] public float Speed { get; private set; }
    
    /*CAN BE CHANGED*/
    [field: SerializeField] public float FoodCount { get; private set; }
    [field: SerializeField] public float HungerRemaining { get; private set; }
    
    [field: SerializeField] public float WaterCount { get; private set; }
    [field: SerializeField] public float WaterRemaining { get; private set; }
    
    [field: SerializeField] public float EnergyLevel { get; private set; }

    /*REFERENCES*/
    [field: SerializeField] public Transform Target { get; private set; }
    [field: SerializeField] public Food Food { get; private set; }
    [field: SerializeField] public Water Water { get; private set; }
    [field: SerializeField] public FoodAgentTree Mate { get; private set; }
    
    
    /*MEMORY*/
    public PositionMemory[] PositionMemory { get; } = new PositionMemory[GlobalSettings.MaxPositionMemory];
    
    /*DYNAMIC*/
    private float _hungerDecreaseRate;
    private float _thirstDecreaseRate;
   

    private void Update() => OnTick();

    protected override void OnTick()
    {
        IncreaseHunger();
        IncreaseThirst();
        CheckCanSurvive();
        
        base.OnTick();
    }

    protected override Node SetupTree()
    {
        var node = 
            new Selector(this, new List<Node>
            {
                new Sequence(this, new List<Node>
                {
                    new CheckIsHungry(this),
                    new CheckHasFood(this),
                    new TaskEatFood(this)
                }),
                new Sequence(this, new List<Node>
                {
                    new CheckIsThirsty(this),
                    new CheckHasWater(this),
                    new TaskDrinkWater(this)
                }),
                new Sequence(this, new List<Node>
                {
                    new CheckNoEnergy(this),
                    new TaskRest(this)
                }),
                new Sequence(this, new List<Node>
                {
                    new CheckIsDay(this),
                    new Selector(this, new List<Node>
                    {
                        /*REPRODUCTION SECTION*/
                        new Sequence(this, new List<Node>
                        {
                            new CheckReproductionCapability(this),
                            new Selector(this, new List<Node>
                            {
                                new Sequence(this, new List<Node>
                                {
                                    new CheckHasMateTarget(this),
                                    new CheckTargetNear(this),
                                    new TaskReproduce(this)
                                }),
                                new Sequence(this, new List<Node>
                                {
                                    new CheckHasMateTarget(this),
                                    new TaskGoToTarget(this)
                                }),
                                new Sequence(this, new List<Node>
                                {
                                    new CheckMateNearby(this),
                                    new TaskRequestMate(this)
                                })
                            })
                        }),
                        
                        /*FOOD SECTION*/
                        new Sequence(this, new List<Node>
                        {
                            new CheckNeedFood(this),
                            new Selector(this, new List<Node>
                            {
                                new Sequence(this, new List<Node>
                                {
                                    new CheckFoodNearby(this),
                                    new CheckTargetNear(this),
                                    new TaskCollectFood(this)
                                }),
                                new Sequence(this, new List<Node>
                                {
                                    new Inverter(new CheckHasFoodTarget(this)),
                                    new CheckRememberFoodSpawn(this)
                                }),
                                new Sequence(this, new List<Node>
                                {
                                    new CheckHasFoodTarget(this),
                                    new TaskGoToTarget(this)
                                })
                            })
                        }),
                        
                        /*WATER SECTION*/
                        new Sequence(this, new List<Node>
                        {
                            new CheckNeedWater(this),
                            new Selector(this, new List<Node>
                            {
                                new Sequence(this, new List<Node>
                                {
                                    new CheckWaterNearby(this),
                                    new CheckTargetNear(this),
                                    new TaskCollectWater(this)
                                }),
                                new Sequence(this, new List<Node>
                                {
                                    new Inverter(new CheckHasWaterTarget(this)),
                                    new CheckRememberWaterSpawn(this)
                                }),
                                new Sequence(this, new List<Node>
                                {
                                    new CheckHasWaterTarget(this),
                                    new TaskGoToTarget(this)
                                })
                            })
                        }),
                        
                        /*EXPLORE SECTION*/
                        new Selector(this, new List<Node>
                        {
                            new Sequence(this, new List<Node>
                            {
                                 new Inverter(new CheckTargetNear(this)),
                                 new TaskGoToTarget(this)
                            }),
                            new TaskPickExploreTarget(this)
                        })
                    }),
                }),
                
            });

  
        return node;
    }
    
    public void Init(float speed)
    {
        transform.name = "Agent";
        
        Speed = speed;
    }
    
    private void IncreaseHunger()
    {
        HungerRemaining -= _hungerDecreaseRate;
    }
    private void IncreaseThirst()
    {
        WaterRemaining -= _thirstDecreaseRate;
    }
    private void CheckCanSurvive()
    {  
        if(HungerRemaining <= 0f || WaterRemaining <= 0f) Destroy(gameObject);
    }
    
    public bool RequestMate(FoodAgentTree male)
    {
        if (Mate != null) return false;
        if (new CheckReproductionCapability(this).Evaluate() != NodeState.SUCCESS) return false;

        Mate = male;
        Target = male.transform;
        
        return true;
    }
    public void ReproductionCost()
    {
        Mate = null;
        Target = null;
        FoodCount -= GlobalSettings.FoodToRep;
        WaterCount -= GlobalSettings.WaterToRep;
    }
    
    #region Set Methods

    public void IncreaseFoodCount() => FoodCount++;
    public void IncreaseWaterCount() => WaterCount++;
    
    public void EatFood() => HungerRemaining += GlobalSettings.MinFoodRegain;
    public void DrinkWater() => WaterRemaining += GlobalSettings.MinWaterRegain;
    public void Rest() => EnergyLevel += GlobalSettings.RestRegain;

    public void SetTarget(Transform target) => Target = target;
    public void SetFood(Food food) => Food = food;
    public void SetWater(Water water) => Water = water;
    public void SetMate(FoodAgentTree mate) => Mate = mate;

    #endregion
}

