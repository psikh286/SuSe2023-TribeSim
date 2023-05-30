using BehaviorTree;
using UnityEngine;

public class CheckMateInDoRange : Node
{
    public CheckMateInDoRange(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var mate = _root.Mate;
        var target = _root.Target;
        if (mate == null || target == null)
        {
            _state = NodeState.FAILURE;
            return _state;
        }

        _state = Vector3.Distance(_root.transform.position, target.position) > 0.01f ? NodeState.FAILURE : NodeState.SUCCESS;

        return _state;
    }
}