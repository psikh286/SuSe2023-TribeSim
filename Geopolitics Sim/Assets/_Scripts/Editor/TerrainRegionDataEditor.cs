using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainRegionData))]
public class TerrainRegionDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Add a button to the inspector
        if (GUILayout.Button("Populate Data"))
        {
            PopulateData();
        }
    }

    void PopulateData()
    {
        // Get a reference to the TerrainRegionData object
        TerrainRegionData terrainRegionData = (TerrainRegionData)target;

        // Populate the data
        // You will need to replace this with your own data population logic
        terrainRegionData.shelterAvailability = Random.Range(0.0f, 1.0f);
        terrainRegionData.survivalFactor = Random.Range(0.0f, 1.0f);
        terrainRegionData.terrainDifficulty = Random.Range(0.0f, 1.0f);
        // Populate the availableResources list here
    }
}
