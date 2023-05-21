using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TerrainRegionData", menuName = "Terrain/TerrainRegionData", order = 1)]
public class TerrainRegionData : ScriptableObject
{
    public enum TerrainType { Mountain, Forest, Desert, Water }

    public TerrainType terrainType;
    public float shelterAvailability;
    public float survivalFactor;
    public float terrainDifficulty;
    public List<Resource> availableResources;
}

