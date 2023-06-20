using BehaviorTree;

public class CheckHasFoodTarget : Node
{
    public CheckHasFoodTarget(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        if (_root.Food == null)
            _state = NodeState.FAILURE;
        else
        {
            _state = NodeState.SUCCESS;
            _root.OnAgentAct?.Invoke("Going to Food");
        }

        return _state;
    }
}