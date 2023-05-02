using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action<bool> OnTick;

    public void Tick(bool b)
    {
        OnTick?.Invoke(b);
    }
}

public enum State
{
    Eat,
    SearchFood,
    SearchMate,
    Reproduce,
    Basic
}

