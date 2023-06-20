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
            _root.NodeDebug = "Cooldown";
            _root.SetCooldown(-1);
        }
        else
        {
            _state = NodeState.FAILURE;
        }
        
        return _state;
    }
}