using UnityEngine;

[CreateAssetMenu(fileName = "Globals", menuName = "GlobalSettings")]
public class SettingsSO : ScriptableObject
{
    [SerializeField] private int _foodToRep;
    [SerializeField] private int _foodToSurvive;

    private void OnEnable()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        GlobalSettings.SetFoodToRep(_foodToRep);
        GlobalSettings.SetFoodToSurvive(_foodToSurvive);
    }
}
