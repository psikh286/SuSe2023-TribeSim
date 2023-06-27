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

        if (Physics.Raycast(result, Vector3.up, out var hit, Mathf.Infinity, 1 << 13))
        {
            result.y = hit.point.y + 0.5f;
        }
        else
        {
            if (Physics.Raycast(result, Vector3.down, out hit, Mathf.Infinity, 1 << 13))
            {
                result.y = hit.point.y ;
            }
        }

        return result;
    }
}