using UnityEngine;

[System.Serializable]
public class TMotivation
{
    [SerializeField] private float Value;
    
    public float Evaluate(float b)
    {
        var a = Value;

        return (a + b) * 0.5f;
    }
}