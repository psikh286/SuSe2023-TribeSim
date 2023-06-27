using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;

public class TaskGoToTarget : Node
{
    private NavMeshAgent _nav;
    
    public TaskGoToTarget(FoodAgentTree root)
    {
        _root = root;
        _nav = root.GetComponent<NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        var agentPosition = _root.transform.position;
        var target = _root.Target;
        var speed = _root.Speed;
        
        if (Vector3.Distance(agentPosition, target.position) > 0.01f)
        {
            var targetPosition = target.position;
            
            //_root.transform.LookAt(target);
            
            //_root.transform.position = Vector3.MoveTowards(agentPosition, targetPosition, speed);

            _nav.speed = speed;
            _nav.destination = targetPosition;
            
            _root.SpendEnergy(EnergySettings.Walk);
        }
        
        _root.NodeDebug = "TaskGoToTarget";

        _state = NodeState.RUNNING;
        return _state;
    }
}