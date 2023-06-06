using BehaviorTree;
using UnityEngine;

public class TaskReproduce : Node
{
    public TaskReproduce(FoodAgentTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var mate = _root.Mate;
        var speed = CalculateSpeed(_root.Speed, mate.Speed);
        
        Object.Instantiate(_root, _root.transform.position + Vector3.right * 10f, Quaternion.identity).Init(speed);

        mate.ReproductionCost();
        _root.ReproductionCost();
        
        _root.NodeDebug = "TaskReproduce";
        
        _root.SpendEnergy(EnergySettings.Reproduce);
        _root.SetCooldown(CooldownConfiguration.Reproduce);
        
        _state = NodeState.RUNNING;
        return _state;
    }

    private static float CalculateSpeed(float a, float b)
    {
        var c = (a + b) * 0.5f + Utility.RandomFloat() * GlobalSettings.MutationMultiplier * Utility.RandomInt(-1, 2);
        c = Mathf.Clamp(c ,GlobalSettings.MinSpeed, GlobalSettings.MaxSpeed);
        
        return c;
    }
}