using UnityEngine;

[CreateAssetMenu(fileName = "Globals", menuName = "GlobalSettings")]
public class SettingsSO : ScriptableObject
{
    [Header("Food")]
    [SerializeField] [Tooltip("Food to reproduce")]private float _foodToRep;
    [SerializeField] [Tooltip("Minimal amount of hunger restored by consuming one food item")] private float _minFoodRegain;
    [SerializeField] [Tooltip("Maximum amount of hunger restored by consuming one food item")] private float _maxFoodRegain;
    [SerializeField] [Tooltip("Hunger threshold for food consumption")] private float _isHungryThreshold;
    
    [Header("Water")]
    [SerializeField] [Tooltip("Water to reproduce")]private float _waterToRep;
    [SerializeField] [Tooltip("Minimal amount of thirstiness restored by consuming one water item")] private float _minWaterRegain;
    [SerializeField] [Tooltip("Maximum amount of thirstiness restored by consuming one water item")] private float _maxWaterRegain;
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

    [Header("Exploration")] 
    [SerializeField] private float _minExploreDistance;
    [SerializeField] private float _maxExploreDistance;

    private void OnEnable()
    {
        OnValidate();
    }

    public void OnValidate()
    {
        /*FOOD*/
        GlobalSettings.SetFoodToRep(_foodToRep);
        GlobalSettings.SetMinFoodRegain(_minFoodRegain);
        GlobalSettings.SetMaxFoodRegain(_maxFoodRegain);
        GlobalSettings.SetIsHungryThreshold(_isHungryThreshold);
        
        /*WATER*/
        GlobalSettings.SetWaterToRep(_waterToRep);
        GlobalSettings.SetMinWaterRegain(_minWaterRegain);
        GlobalSettings.SetMaxWaterRegain(_maxWaterRegain);
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
        
        /*EXPLORATION*/
        GlobalSettings.SetMinExploreDistance(_minExploreDistance);
        GlobalSettings.SetMaxExploreDistance(_maxExploreDistance);
    }
}
