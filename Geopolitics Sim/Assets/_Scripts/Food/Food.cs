using UnityEngine;

public class Food : MonoBehaviour, IFood
{
    private float _value;
    
    public Transform Transform { get; set; }
    public void Collect() => Destroy(gameObject);
    public float GetFoodRegain() => _value;

    private void Awake()
    {
        Transform = transform;

        _value = Utility.RandomFloat(GlobalSettings.MinFoodRegain, GlobalSettings.MaxFoodRegain);
        
        Transform.localScale = Vector3.one * 
                               Utility.Map(_value, 
                                    GlobalSettings.MinFoodRegain,GlobalSettings.MaxFoodRegain, 
                                    VisualConfiguration.MinFoodScale, VisualConfiguration.MaxFoodScale); 
    }
}
