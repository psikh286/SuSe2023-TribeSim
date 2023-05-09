using BehaviorTree;
using UnityEngine;

public class CheckMateInFOVRange : Node
{
    private readonly Transform _transform;
    
    public CheckMateInFOVRange(BTree root)
    {
        _root = root;
        _transform = root.transform;
    }
    
    public override NodeState Evaluate()
    {
        var m = _root.GetData("mate");
        if (m != null)
        {
            _state = NodeState.SUCCESS;
            return _state;
        }

        object mate = null;
        
        var hits = new Collider[4];
        var i = Physics.OverlapBoxNonAlloc(_transform.position, Vector3.one * 4f, hits, Quaternion.identity, 1 << 8);

        if (i <= 0)
        {
            _state = NodeState.FAILURE;
            return _state;
        }
        for (var j = 0; j < i; j++)
        {
            if (!hits[j].TryGetComponent(out BTree agent)) continue;
            if(agent == _root) continue;
            PotentialMateFound((FoodAgentTree)agent);
            
            if (mate != null) break;
        }

        if (mate == null)
        {
            _state = NodeState.FAILURE;
            return _state;
        }
        
        _root.SetData("mate", mate);
        _root.SetData("target", ((BTree)mate).transform);
        
        _state = NodeState.SUCCESS;
        
        return _state;
        
        void PotentialMateFound(FoodAgentTree female)
        {
            var accepted = female.RequestMate((FoodAgentTree)_root);

            if (!accepted) return;

            mate = female;
        }
    }
}