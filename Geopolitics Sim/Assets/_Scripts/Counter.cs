using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _tmp;

    private int[] _count = new int[3];

    private void OnEnable()
    {
        FoodAgentTree.OnAgentSpawn += OnAgentSpawn;
    }
    
    private void OnDisable()
    {
        FoodAgentTree.OnAgentSpawn -= OnAgentSpawn;
    }

    private void OnAgentSpawn()
    {
        
    }
}