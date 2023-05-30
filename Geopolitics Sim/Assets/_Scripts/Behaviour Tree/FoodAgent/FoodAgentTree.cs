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

    public PositionMemory[] PositionMemory { get; } = new PositionMemory[GlobalSettings.MaxPositionMemory];


    public Food Food;
    public Water Water;
    public Transform Target;
    public FoodAgentTree Mate;

    

    private float _hungerDecreaseRate;
    private float _thirstDecreaseRate;

    private int _ticksSinceLastMeal;
    private int _ticksSinceLastDrink;
    

    private void Update()
    {
        OnTick();
    }

    protected override void OnTick()
    {
        IncreaseHunger();
        IncreaseThirst();
        CheckCanSurvive();
        
        base.OnTick();
    }

    protected override Node SetupTree()
    {
        /*var node = 
            new Selector(this, new List<Node>
            {
                //WAIT FOR A MATE
                new TaskWaitMate(this)
                ,//REPRODUCE
                new Sequence(this, new List<Node>
                {
                    new CheckReadyToReproduce(this),
                    new CheckMateInDoRange(this),
                    new TaskReproduce(this)
                })
                ,//WALK TO MATE
                new Sequence(this, new List<Node>
                {
                    new CheckReadyToReproduce(this),
                    new CheckMateInFOVRange(this),
                    new TaskGoToTarget(this)
                })
                ,//EAT FOOD
                new Sequence(this, new List<Node>
                {
                    new CheckNotEnoughFood(this),
                    new CheckFoodInEatingRange(this),
                    new TaskEatFood(this)
                })
               , //WALK TO FOOD
                new Sequence(this, new List<Node>
                {
                    new CheckNotEnoughFood(this),
                    new CheckFoodInFOVRange(this),
                    new TaskGoToTarget(this)
                })
                , //WALK AROUND
                new TaskWander(this)
            });*/

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
                        })
                    }),
                    new TaskWander(this)
                }),
                
            });

  
        return node;
    }
    
    
    


    public void IncreaseFoodCount() => FoodCount++;
    public void IncreaseWaterCount() => WaterCount++;
    
    public void EatFood() => HungerRemaining += GlobalSettings.FoodRegain;
    public void DrinkWater() => WaterRemaining += GlobalSettings.WaterRegain;
    public void Rest() => EnergyLevel += GlobalSettings.EnergyRegain;

    public void Init(float speed)
    {
        Speed = speed;
    }
    
    
    
    
    private void IncreaseHunger()
    {
    }
    private void IncreaseThirst()
    {
        
    }
    private void CheckCanSurvive()
    {
        
    }
    
    public bool RequestMate(FoodAgentTree male)
    {
        if (new CheckReadyToReproduce(this).Evaluate() != NodeState.SUCCESS) return false;
        /*if ((Object)GetData("mate") != null) return false;
        
        SetData("mate", male);
        SetData("target", transform);*/
        
        return true;
    }
    public void Reproduced()
    {
        Mate = null;
        Target = null;
        FoodCount -= 2;
    }
}