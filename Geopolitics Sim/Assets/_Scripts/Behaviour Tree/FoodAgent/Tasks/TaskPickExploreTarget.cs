using UnityEngine;
using BehaviorTree;

public class TaskPickExploreTarget : Node
{
    private Vector3 _targetPoint;
    
    public TaskPickExploreTarget(FoodAgentTree root)
    {
        _root = root;
        _targetPoint = _root.transform.position;
    }
    
    public override NodeState Evaluate()
    {
        var r = new GameObject("g")
        {
            tag = " ",
            transform =
            {
                position = Vector3.back
            }
        };

        _root.SetTarget(r.transform);

        _state = NodeState.RUNNING;
        return _state;
    }
}