using BehaviorTree;

public class TaskEatFood : Node
{
    public TaskEatFood(FoodAgentTree root)
    {
        _root = root;
    }

    public override NodeState Evaluate()
    {
        _root.Food.EatFood();

        _root.IncreaseFoodCount();
        
        _root.Food = null;
        _root.Target = null;
        
        _state = NodeState.RUNNING;
        return _state;
    }
}