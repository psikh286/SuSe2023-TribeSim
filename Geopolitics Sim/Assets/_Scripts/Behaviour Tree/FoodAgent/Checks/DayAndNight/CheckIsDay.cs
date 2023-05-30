using BehaviorTree;

public class CheckIsDay : Node
{
    public CheckIsDay(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _state = GlobalSettings.Time == TimeOfDay.Day ? NodeState.SUCCESS : NodeState.FAILURE;
        
        return _state;
    }
}