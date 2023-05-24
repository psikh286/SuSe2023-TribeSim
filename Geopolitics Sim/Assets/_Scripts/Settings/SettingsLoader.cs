using UnityEngine;

public class SettingsLoader : MonoBehaviour
{
    [SerializeField] private SettingsSO _settings;

    private void Awake()
    {
        _settings.OnValidate();
    }
}