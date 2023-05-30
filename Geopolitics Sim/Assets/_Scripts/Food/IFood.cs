using UnityEngine;

public interface IFood
{
    public Transform Transform { get; }
    public void Collect();
}