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

        if (Vector3.Distance(_root.transform.position, target.position) > 0.01f)
        {
            _state = NodeState.FAILURE;
        }
        else
        {
            _state = NodeState.SUCCESS;
            
            if(_root.Target.CompareTag("Target")) Object.Destroy(_root.Target.gameObject);
        }

        return _state;
    }
}