using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnTick;

    public void Tick()
    {
        OnTick?.Invoke();
    }
}

