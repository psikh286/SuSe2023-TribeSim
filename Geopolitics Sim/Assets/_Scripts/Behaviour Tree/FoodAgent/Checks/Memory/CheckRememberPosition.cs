using System.Linq;
using BehaviorTree;
using UnityEngine;

public class CheckRememberPosition : Node
{
    private readonly string _key;

    public CheckRememberPosition(FoodAgentTree root, string key)
    {
        _root = root;
        _key = key;
    }

    public override NodeState Evaluate()
    {
        var target = Remember();

        if (target == null)
        {
            _state = NodeState.FAILURE;
        }
        else
        {
            _root.SetTarget(target);
            _root.OnAgentAct?.Invoke($"Going to already visited {_key.ToLower()} place");
            _state = NodeState.SUCCESS;
        }

        return _state;

        Transform Remember()
        {
            if (_root.PositionMemories.All(r => r.Key != _key)) return null;
            var pos = _root.PositionMemories.First(r => r.Key == _key).Value;


            if (_root.Target != null && _root.Target.position == pos) return _root.Target;
            if (_root.Target != null && _root.Target.CompareTag("Target")) Object.Destroy(_root.Target.gameObject);

            var g = new GameObject("target")
            {
                tag = "Target",
                transform =
                {
                    position = pos
                }
            };

            return g.transform;
        }
    }
}