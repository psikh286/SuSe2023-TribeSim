using UnityEngine;

public class Water : MonoBehaviour, IFood
{
    public Transform Transform { get; set; }
    public void Collect() => Destroy(gameObject);

    private void Awake() => Transform = transform;
}