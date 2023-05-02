using UnityEngine;

public interface IFood
{
    public Vector3 Position { get; set; }
    public void EatFood();
}