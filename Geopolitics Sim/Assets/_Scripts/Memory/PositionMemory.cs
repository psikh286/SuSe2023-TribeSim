using UnityEngine;

[System.Serializable]
public struct PositionMemory
{
    public string Key;
    public Vector3 Value;

    public PositionMemory(string key, Vector3 value)
    {
        Key = key;
        Value = value;
    }
}
