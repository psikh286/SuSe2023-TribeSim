using BehaviorTree;
using UnityEngine;

public class TaskReproduce : Node
{
    public TaskReproduce(BTree root)
    {
        _root = root;
    }
    
    public override NodeState Evaluate()
    {
        var mate = (FoodAgentTree)_root.GetData("mate");

        var a = (float)_root.GetData("speed");
        var b = (float)mate.GetData("speed");
        var c = ((a + b) * 0.5f) + Utility.RandomFloat() * GlobalSettings.MutationMultiplier;
        
        c = Mathf.Clamp(c ,GlobalSettings.MinSpeed, GlobalSettings.MaxSpeed);
        
        var offspring = Object.Instantiate(_root, _root.transform.position, Quaternion.identity);
        offspring.SetData("speed", c);
        
        mate.Impregnate();
        ((FoodAgentTree)_root).Impregnate();
        
        _state = NodeState.RUNNING;
        return _state;
    }
}