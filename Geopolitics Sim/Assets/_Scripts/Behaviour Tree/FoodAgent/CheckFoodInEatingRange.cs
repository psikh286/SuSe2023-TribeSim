using BehaviorTree;
using UnityEngine;

public class CheckFoodInEatingRange : Node
{
    private readonly Transform _transform;
    
    public CheckFoodInEatingRange(BTree root)
    {
        _root = root;
        _transform = root.transform;
    }

    public override NodeState Evaluate()
    {
        var f = _root.GetData("food");
        var t = (Transform)_root.GetData("target");
        
        if (f == null || t == null)
        {
            _state = NodeState.FAILURE;
            _root.ClearData("food");
            return _state;
        }

        _state = Vector3.Distance(_transform.position, t.position) > 0.01f ? NodeState.FAILURE : NodeState.SUCCESS;

        return _state;
    }
}