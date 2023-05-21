using System.Collections.Generic;
using UnityEngine;
public class TerrainManager : MonoBehaviour
{
    public int width;
    public int height;
    public List<TerrainRegionData> terrainTypes;
    private TerrainRegionData[,] grid;

    public Renderer terrainRenderer;

    void Awake()
    {
        grid = new TerrainRegionData[width, height];
        PopulateGrid();

        Texture2D texture = GenerateTexture();
        terrainRenderer.material.mainTexture = texture;
    }

    public TerrainRegionData GetTerrainRegionData(Vector3 position)
    {
        int x = Mathf.FloorToInt(position.x);
        int y = Mathf.FloorToInt(position.z);

        x = Mathf.Clamp(x, 0, width - 1);
        y = Mathf.Clamp(y, 0, height - 1);

        return grid[x, y];
    }


    void PopulateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float noiseValue = Mathf.PerlinNoise(x * 0.1f, y * 0.1f);
                TerrainRegionData terrain = ChooseTerrainType(noiseValue);
                grid[x, y] = terrain;
            }
        }
    }

    TerrainRegionData ChooseTerrainType(float noiseValue)
    {
        // For this example, we'll assume that the terrainTypes list is sorted in ascending order of terrain difficulty.
        // We'll choose the terrain type based on the noise value.
        for (int i = 0; i < terrainTypes.Count; i++)
        {
            if (noiseValue < (i + 1) / (float)terrainTypes.Count)
            {
                return terrainTypes[i];
            }
        }

        // If we haven't returned yet, return the last terrain type.
        return terrainTypes[terrainTypes.Count - 1];
    }
    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = grid[x, y].terrainColor;
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }
    

}
