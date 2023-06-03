using UnityEngine;

[CreateAssetMenu(fileName = "VisualConfig", menuName = "Visual Configuration")]
public class VisualConfigSO : ScriptableObject
{
    [SerializeField] private float _minFoodScale;
    [SerializeField] private float _maxFoodScale;
    
    private void OnEnable()
    {
        OnValidate();
    }

    public void OnValidate()
    {
        VisualConfiguration.SetMinFoodScale(_minFoodScale);
        VisualConfiguration.SetMaxFoodScale(_maxFoodScale);
    }
}
