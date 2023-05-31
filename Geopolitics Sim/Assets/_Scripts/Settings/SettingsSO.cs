using UnityEngine;

[CreateAssetMenu(fileName = "Globals", menuName = "GlobalSettings")]
public class SettingsSO : ScriptableObject
{
    [Header("Food")]
    [SerializeField] [Tooltip("Food to reproduce")]private int _foodToRep;
    [SerializeField] [Tooltip("Amount of hunger restored by consuming one food item")] private float _foodRegain;
    [SerializeField] [Tooltip("Hunger threshold for food consumption")] private float _isHungryThreshold;
    
    
    [Header("Water")]
    [SerializeField] [Tooltip("Water to reproduce")]private int _waterToRep;
    [SerializeField] [Tooltip("Amount of thirstiness restored by consuming one water item")] private float _waterRegain;
    [SerializeField] [Tooltip("Thirstiness threshold for water consumption")] private float _isThirstyThreshold;
    
    [Header("Energy")]
    [SerializeField] [Tooltip("Energy level <= rest point: stop moving and rest")] private float _restPoint;
    [SerializeField] [Tooltip("Amount of energy restored by standing still during day")] private float _restRegain;
    
    [Header("Day And Night")]
    [SerializeField] private TimeOfDay _time;
    
    [Header("Memory")]
    [SerializeField] [Tooltip("Number of memory slots in the position array")] private int _posMemory;
    
    [Header("Inheritance")]
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _mutationMultiplier;

    private void OnEnable()
    {
        OnValidate();
    }

    public void OnValidate()
    {
        /*FOOD*/
        GlobalSettings.SetFoodToRep(_foodToRep);
        GlobalSettings.SetFoodRegain(_foodRegain);
        GlobalSettings.SetIsHungryThreshold(_isHungryThreshold);
        
        /*WATER*/
        GlobalSettings.SetWaterToRep(_waterToRep);
        GlobalSettings.SetWaterRegain(_waterRegain);
        GlobalSettings.SetIsThirstyThreshold(_isThirstyThreshold);
        
        /*ENERGY*/
        GlobalSettings.SetEnergyRestPoint(_restPoint);
        GlobalSettings.SetRestRegain(_restRegain);
        
        /*TIME*/
        GlobalSettings.SetTimeOfTheDay(_time);
        
        /*MEMORY*/
        GlobalSettings.SetMaxPositionMemory(_posMemory);
        
        /*INHERITANCE*/
        GlobalSettings.SetMinSpeed(_minSpeed);
        GlobalSettings.SetMaxSpeed(_maxSpeed);
        GlobalSettings.SetMutationMultiplier(_mutationMultiplier);
    }
}
