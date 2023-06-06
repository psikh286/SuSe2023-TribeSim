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
        
        _root.NodeDebug = "TaskPickExploreTarget";

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