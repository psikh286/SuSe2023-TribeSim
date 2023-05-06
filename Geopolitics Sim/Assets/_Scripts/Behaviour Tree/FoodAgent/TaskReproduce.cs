using BehaviorTree;

public class TaskReproduce : Node
{
    public TaskReproduce(BTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var mate = (FoodAgentTree)_root.GetData("mate");
        
        mate.Impregnate((FoodAgentTree)_root);
        
        _root.ClearData("mate");
        _root.ClearData("target");
        _root.SetData("foodCount", (int)_root.GetData("foodCount") - 2);
        
        _state = NodeState.RUNNING;
        return _state;
    }
}