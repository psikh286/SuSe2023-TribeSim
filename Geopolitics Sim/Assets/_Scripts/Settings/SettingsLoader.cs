using UnityEngine;

public class SettingsLoader : MonoBehaviour
{
    [SerializeField] private SettingsSO _globals;
    [SerializeField] private EnergyConsumptionSO _energy;
    [SerializeField] private VisualConfigSO _visuals;

    private void Awake()
    {
        _globals.OnValidate();
        _energy.OnValidate();
        _visuals.OnValidate();
    }
}