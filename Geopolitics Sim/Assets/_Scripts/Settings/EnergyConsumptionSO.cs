using UnityEngine;

[CreateAssetMenu(fileName = "EnergyConsumption", menuName = "Energy Consumption")]
public class EnergyConsumptionSO : ScriptableObject
{
    [SerializeField, Tooltip("Energy spend collecting food")] private float _energyCollectingFood;
    [SerializeField, Tooltip("Energy spend collecting water")] private float _energyCollectingWater;
    [SerializeField, Tooltip("Energy spend walk")] private float _energyWalk;
    [SerializeField, Tooltip("Energy spend reproduce")] private float _energyReproduce;
    [SerializeField, Tooltip("Energy spend request mate")] private float _energyRequestMate;


    private void OnEnable()
    {
        OnValidate();
    }

    public void OnValidate()
    {
        EnergySettings.SetEnergyCollectingFood(_energyCollectingFood);
        EnergySettings.SetEnergyCollectingWater(_energyCollectingWater);
        EnergySettings.SetEnergyWalk(_energyWalk);
        EnergySettings.SetEnergyReproduce(_energyReproduce);
        EnergySettings.SetEnergyRequestMate(_energyRequestMate);
    }
}
