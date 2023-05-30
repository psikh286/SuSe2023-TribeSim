using UnityEngine;
using BehaviorTree;

public class CheckTargetNear: Node
{
    public CheckTargetNear(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var target = _root.Target;
        
        if (target == null)
        {
            _state = NodeState.FAILURE;
            return _state;
        }

        _state = Vector3.Distance(_root.transform.position, target.position) > 0.01f ? NodeState.FAILURE : NodeState.SUCCESS;

        return _state;
    }
}