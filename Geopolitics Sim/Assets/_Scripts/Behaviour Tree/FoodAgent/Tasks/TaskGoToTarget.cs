using BehaviorTree;
using UnityEngine;

public class TaskGoToTarget : Node
{
    private readonly float _tickFreq;
    
    public TaskGoToTarget(FoodAgentTree root)
    {
        _root = root;
        _tickFreq = FoodAgentTree.TickFrequency;
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
            
            _root.transform.position = Vector3.MoveTowards(agentPosition, targetPosition, speed * _tickFreq);
        }
        
        _root.NodeDebug = "TaskGoToTarget";

        _state = NodeState.RUNNING;
        return _state;
    }
}