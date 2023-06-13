using System;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class FoodAgentTree : BTree
{
    public static Action OnAgentSpawn;

    public string NodeDebug;

    public float TickFrequency = 0.02f;

    
    /*INITIALIZE*/
    [field: SerializeField] public float Speed { get; private set; }
    
    /*CAN BE CHANGED*/
    [field: SerializeField] public float FoodValue { get; private set; }
    [field: SerializeField] public float HungerRemaining { get; private set; }
    
    [field: SerializeField] public float WaterValue { get; private set; }
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
    private float _hungerDecreaseRate = 0.05f;
    private float _thirstDecreaseRate= 0.05f;

    public int Cooldown = 600;


    private void FixedUpdate() => OnTick();

    protected override void OnTick()
    {
        IncreaseHunger();
        IncreaseThirst();
        CheckCanSurvive();

        Food = null;
        Water = null;
        
        base.OnTick();
    }

    protected override Node SetupTree()
    {
        var node = 
            new Selector(this, new List<Node>
            {
                new CheckHasCooldown(this),
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
                        /*new Sequence(this, new List<Node>
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
                                    new CheckHasTarget(this),
                                    new CheckHasMateTarget(this),
                                    new TaskGoToTarget(this)
                                }),
                                new Sequence(this, new List<Node>
                                {
                                    new Inverter(new CheckHasMateTarget(this)),
                                    new CheckMateNearby(this),
                                    new TaskRequestMate(this)
                                })
                            })
                        }),*/
                        
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
                                    new CheckHasTarget(this),
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
                                    new CheckHasTarget(this),
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
                                 new CheckHasTarget(this),
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
        if (HungerRemaining <= 0f || WaterRemaining <= 0f)
        {
            print($"water: {WaterRemaining} , food: {HungerRemaining}");
            Destroy(gameObject);
        }
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
        FoodValue -= GlobalSettings.FoodToRep;
        WaterValue -= GlobalSettings.WaterToRep;
    }
    
    #region Set Methods

    public void IncreaseFoodValue(float value)
    {
        FoodValue += value;
        EnergyLevel += 6f;
    }

    public void IncreaseWaterCount(float value)
    {
        WaterValue += value;
        
        EnergyLevel += 4f;
    }

    public void EatFood()
    {
        var f = 100f - HungerRemaining;
        
        var value = FoodValue > f ? f : FoodValue;

        HungerRemaining += value;
        FoodValue -= value;
    }
    public void DrinkWater()
    {
        var f = 100f - WaterRemaining;
        
        var value = WaterValue > f ? f : WaterValue;

        WaterRemaining += value;
        WaterValue -= value;
    }

    public void Rest() => EnergyLevel += GlobalSettings.RestRegain;
    public void SpendEnergy(float value) => EnergyLevel -= value;
    public void SetCooldown(int i) => Cooldown += i;

    public void SetTarget(Transform target) => Target = target;
    public void SetFood(Food food) => Food = food;
    public void SetWater(Water water) => Water = water;
    public void SetMate(FoodAgentTree mate) => Mate = mate;

    #endregion

    private void OnDrawGizmos()
    {
        if(Target == null) return;
        
        Gizmos.color = Color.red;
        
        Gizmos.DrawSphere(Target.position, 0.6f);
    }
}

