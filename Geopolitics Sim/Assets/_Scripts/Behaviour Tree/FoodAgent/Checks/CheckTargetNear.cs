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

        if (Vector2.Distance(Vector3ToVector2(_root.transform.position), Vector3ToVector2(target.position)) > 0.01f)
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
    
    private static Vector2 Vector3ToVector2(Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }
}