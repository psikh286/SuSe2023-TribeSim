using BehaviorTree;
using UnityEngine;

public class TaskGoToTarget : Node
{
    public TaskGoToTarget(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        var agentPosition = _root.transform.position;
        var target = _root.Target;
        var speed = _root.Speed;
        
        if (Vector3.Distance(agentPosition, target.position) > 0.01f)
        {
            var targetPosition = target.position;
            
            _root.transform.LookAt(target);
            
            _root.transform.position = Vector3.MoveTowards(agentPosition, targetPosition, speed * Time.deltaTime);
            
            
           
        }
        
        _root.NodeDebug = "TaskGoToTarget";

        _state = NodeState.RUNNING;
        return _state;
    }
}