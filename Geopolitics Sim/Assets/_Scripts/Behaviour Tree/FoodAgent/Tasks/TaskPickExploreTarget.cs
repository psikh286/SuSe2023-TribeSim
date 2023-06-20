using UnityEngine;
using BehaviorTree;

public class TaskPickExploreTarget : Node
{
    public TaskPickExploreTarget(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var r = new GameObject("target")
        {
            tag = "Target",
            transform =
            {
                position = GetRandomPosition()
            }
        };
        
        Object.Destroy(r, 10f);

        _root.SetTarget(r.transform);
        _root.SetCooldown((int)(CooldownConfiguration.PickExploreTarget * Utility.RandomFloat()));
        
        _root.NodeDebug = "TaskPickExploreTarget";
        _root.OnAgentAct?.Invoke("Thinking where to go");

        _state = NodeState.RUNNING;
        return _state;
    }

    private Vector3 GetRandomPosition()
    {
        var result = _root.transform.position;
        
        var angle = 2f * Mathf.PI * Utility.RandomFloat();
        
        result += new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * Utility.RandomFloat(GlobalSettings.MinExploreDistance, GlobalSettings.MaxExploreDistance);
        
        return result;
    }
}