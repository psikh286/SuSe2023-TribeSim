using BehaviorTree;

public class TaskEatFood : Node
{
    public TaskEatFood(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        _root.EatFood();
        
        _state = NodeState.RUNNING;
        return _state;
    }
}