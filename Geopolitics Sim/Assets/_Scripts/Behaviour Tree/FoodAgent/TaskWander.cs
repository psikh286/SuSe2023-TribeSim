using BehaviorTree;

public class TaskWander : Node
{
    public override NodeState Evaluate()
    {
        return NodeState.RUNNING;
    }
}