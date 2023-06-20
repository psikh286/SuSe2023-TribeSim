using BehaviorTree;

public class CheckHasMateTarget : Node
{
    public CheckHasMateTarget(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        if (_root.Mate == null)
        {
            _state = NodeState.FAILURE;
        }
        else
        {
            _state = NodeState.SUCCESS;
            _root.OnAgentAct?.Invoke("Going to Mate");
        }

        return _state;
    }
}