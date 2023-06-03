using UnityEngine;

public class Water : MonoBehaviour, IFood
{
    private float _value;
    
    public Transform Transform { get; set; }
    public void Collect() => Destroy(gameObject);
    public float GetFoodRegain() => _value;

    private void Awake()
    {
        Transform = transform;

        _value = Utility.RandomFloat(GlobalSettings.MinWaterRegain, GlobalSettings.MaxFoodRegain);
    }
}