using BehaviorTree;

public class CheckMateNearby : Node
{
    private readonly IMateFinder _finder;
    
    public CheckMateNearby(FoodAgentTree root)
    {
        _root = root;
        _finder = _root.GetComponent<IMateFinder>();
    }
    
    public override NodeState Evaluate()
    {
        var mate = _finder.FindMate();

        if (mate == null)
        {
            _state = NodeState.FAILURE;
            return _state;
        }

        _root.SetMate(mate);
        _root.SetTarget(mate.transform);
        
        _state = NodeState.SUCCESS;
        return _state;
    }
}