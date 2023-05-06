using BehaviorTree;
using UnityEngine;
using Random = System.Random;

public class TaskWander : Node
{
    private readonly Transform _transform;
    private Vector3 _targetPoint;
    
    private readonly Random random = new();
    
    public TaskWander(BTree root)
    {
        _root = root;
        _transform = root.transform;
        _targetPoint = _transform.position;
    }

    public override NodeState Evaluate()
    {
        var speed = (float)_root.GetData("speed");
        
        if (Vector3.Distance(_transform.position, _targetPoint) < 0.01f)
        {
            _targetPoint = _transform.position + new Vector3(random.Next(-2, 3), 0f, random.Next(-2, 3));
        }
        
        _transform.position = Vector3.MoveTowards(_transform.position, _targetPoint, speed * Time.deltaTime);

        _state = NodeState.RUNNING;
        return _state;
    }
}