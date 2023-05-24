using UnityEngine;

[CreateAssetMenu(fileName = "Globals", menuName = "GlobalSettings")]
public class SettingsSO : ScriptableObject
{
    [SerializeField] private int _foodToRep;
    [SerializeField] private int _foodToSurvive;

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    [SerializeField] private float _mutationMultiplier;

    private void OnEnable()
    {
        OnValidate();
    }

    public void OnValidate()
    {
        GlobalSettings.SetFoodToRep(_foodToRep);
        GlobalSettings.SetFoodToSurvive(_foodToSurvive);
        GlobalSettings.SetMinSpeed(_minSpeed);
        GlobalSettings.SetMaxSpeed(_maxSpeed);
        GlobalSettings.SetMutationMultiplier(_mutationMultiplier);
    }
}
