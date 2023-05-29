using System;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class FoodAgentTree : BTree
{
    public static Action OnAgentSpawn;
    private int _colorIndex;


    [SerializeField] private float _speed;
    [SerializeField] private int _foodCount;
    
    /*INITIALIZE*/
    public float Speed => _speed;
    
    /*CAN BE CHANGED*/
    public int FoodCount => _foodCount;

    public Food Food;
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
        var node = 
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
            });
        
        return node;
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
        _foodCount -= 2;
    }


    public void IncreaseFoodCount() => _foodCount++;

    public void Init(float speed)
    {
        _speed = speed;
    }
}