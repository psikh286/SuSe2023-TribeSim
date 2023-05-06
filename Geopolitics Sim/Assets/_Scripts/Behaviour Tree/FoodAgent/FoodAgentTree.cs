using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class FoodAgentTree : BTree
{
    private void Update()
    {
        OnTick(true);
    }

    protected override Node SetupTree()
    {
        var node = 
            new Selector(this, new List<Node>
            {
                //WAIT FOR A MATE
                new CheckWaitingForMate(this)
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
        
        SetData("speed", 2f);
        SetData("foodCount", 0);
        return node;
    }
    
    public bool RequestMate(FoodAgentTree male)
    {
        if (new CheckReadyToReproduce(this).Evaluate() != NodeState.SUCCESS) return false;
        
        SetData("mate", male);
        SetData("target", transform);
        
        return true;
    }
    public void Impregnate(FoodAgentTree male)
    {
        ClearData("mate");
        ClearData("target");
    }
}