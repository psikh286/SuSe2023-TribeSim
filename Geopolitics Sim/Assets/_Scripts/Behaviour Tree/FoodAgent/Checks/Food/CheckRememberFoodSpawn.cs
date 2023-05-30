using BehaviorTree;
using UnityEngine;

public class CheckRememberFoodSpawn : Node
{
    public CheckRememberFoodSpawn(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var target = Remember();
        
        _state = target == null ? NodeState.FAILURE : NodeState.SUCCESS;
        
        return _state;

        Transform Remember()
        {
            
            
            return null;
        }
    }
}