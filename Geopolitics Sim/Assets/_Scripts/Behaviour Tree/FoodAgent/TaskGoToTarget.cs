using BehaviorTree;
using UnityEngine;

public class TaskGoToTarget : Node
{
    private readonly Transform _transform;
    
    public TaskGoToTarget(FoodAgentTree root)
    {
        _root = root;
        _transform = root.transform;
    }

    public override NodeState Evaluate()
    {
        var target = _root.Target;
        var speed = _root.Speed;
        
        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            var position = target.position;
            _transform.position = Vector3.MoveTowards(_transform.position, position, speed * Time.deltaTime);
        }

        _state = NodeState.RUNNING;
        return _state;
    }
}