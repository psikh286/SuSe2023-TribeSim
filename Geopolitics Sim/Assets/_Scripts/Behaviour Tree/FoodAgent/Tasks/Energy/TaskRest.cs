using BehaviorTree;

public class TaskRest : Node
{
    public TaskRest(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _root.Rest();
        
        _root.NodeDebug = "TaskRest";
        
        _state = NodeState.RUNNING;
        return _state;
    }
}