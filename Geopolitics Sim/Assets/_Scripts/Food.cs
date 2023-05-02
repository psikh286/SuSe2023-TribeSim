using UnityEngine;

public class Food : MonoBehaviour, IFood
{
    public Vector3 Position {get; set; }

    public void EatFood() => Destroy(gameObject);

    private void Awake() => Position = transform.position;
}
