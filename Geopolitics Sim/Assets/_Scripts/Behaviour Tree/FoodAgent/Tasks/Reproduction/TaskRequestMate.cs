using BehaviorTree;

public class TaskRequestMate : Node
{
    public TaskRequestMate(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var accepted = _root.Mate.RequestMate(_root);

        if (!accepted)
        {
            _root.SetMate(null);
            _root.SetTarget(null);
        }
        
        _root.NodeDebug = "TaskRequestMates";
        _root.OnAgentAct?.Invoke("Request Mating");
        
        _root.SpendEnergy(EnergySettings.RequestMate);
        _root.SetCooldown(CooldownConfiguration.RequestMate);
        
        _state = NodeState.RUNNING;
        return _state;
    }
}