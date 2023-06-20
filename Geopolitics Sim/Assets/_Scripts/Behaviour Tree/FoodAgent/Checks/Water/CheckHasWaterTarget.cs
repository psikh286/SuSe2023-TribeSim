using BehaviorTree;

public class CheckHasWaterTarget : Node
{
    public CheckHasWaterTarget(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        if (_root.Water == null)
        {
            _state = NodeState.FAILURE;
        }
        else
        {
            _state = NodeState.SUCCESS;
            _root.OnAgentAct?.Invoke("Going to water source");
        }

        return _state;
    }
}