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
        var f = (Object)_root.GetData("food");
        var t = (Object)_root.GetData("target");
        
        if (f == null || t == null)
        {
            _state = NodeState.FAILURE;
            _root.ClearData("food");
            return _state;
        }

        var target = (Transform)t;
        _state = Vector3.Distance(_transform.position, target.position) > 0.01f ? NodeState.FAILURE : NodeState.SUCCESS;

        return _state;
    }
}