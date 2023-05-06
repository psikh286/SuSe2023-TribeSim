using BehaviorTree;
using UnityEngine;

public class CheckMateInDoRange : Node
{
    public CheckMateInDoRange(BTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var m = _root.GetData("mate");
        var t = (Transform)_root.GetData("target");
        if (m == null || t == null)
        {
            _state = NodeState.FAILURE;
            _root.ClearData("mate");
            return _state;
        }

        _state = Vector3.Distance(_root.transform.position, t.position) > 0.01f ? NodeState.FAILURE : NodeState.SUCCESS;

        return _state;
    }
}