using BehaviorTree;
using UnityEngine;

public class TaskWander : Node
{
    private readonly Transform _transform;
    private Vector3 _targetPoint;
    
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
            var position = _transform.position;
            _targetPoint = position + new Vector3(Utility.RandomInt(-2, 3), 0f, Utility.RandomInt(-2, 3));

            if (Physics.Linecast(position, _targetPoint, 1 << 12))
            {
                _state = NodeState.RUNNING;
                return _state;
            }
        }
        
        _transform.position = Vector3.MoveTowards(_transform.position, _targetPoint, speed * Time.deltaTime);

        _state = NodeState.RUNNING;
        return _state;
    }
}