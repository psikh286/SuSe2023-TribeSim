using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmp;

    private int _count;

    private void OnEnable()
    {
        FoodAgentTree.OnAgentSpawn += OnAgentSpawn;
    }
    
    private void OnDisable()
    {
        FoodAgentTree.OnAgentSpawn -= OnAgentSpawn;
    }

    private void OnAgentSpawn(int obj)
    {
        _count += obj;

        _tmp.text = $"{_count}";
    }
}