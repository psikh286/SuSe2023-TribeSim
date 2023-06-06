using BehaviorTree;

public class CheckHasCooldown : Node
{
    public CheckHasCooldown(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        if (_root.Cooldown > 0)
        {
            _state = NodeState.SUCCESS;
            _root.Cooldown--;
        }
        else
        {
            _state = NodeState.FAILURE;
        }
        
        return _state;
    }
}