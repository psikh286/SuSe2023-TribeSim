using BehaviorTree;

public class Inverter : Node
{
    private readonly Node _child;
    
    public Inverter(Node child)
    {
        _child = child;
    }
    
    public override NodeState Evaluate()
    {
        switch (_child.Evaluate())
        {
            case NodeState.RUNNING:
                _state = NodeState.RUNNING;
                return _state;
            case NodeState.SUCCESS:
                _state = NodeState.FAILURE;
                return _state;
            case NodeState.FAILURE:
                _state = NodeState.SUCCESS;
                return _state;
            default:
                _state = NodeState.RUNNING;
                return _state;
        }
    }
}