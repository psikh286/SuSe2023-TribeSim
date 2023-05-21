using UnityEngine;
public class TerrainManager : MonoBehaviour
{
    public int width;
    public int height;
    public TerrainRegionData[,] grid;

    void Awake()
    {
        grid = new TerrainRegionData[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Assign a TerrainRegionData object to grid[x, y] here.
                // You could select this object randomly from a list, generate it procedurally, or determine it based on the x and y values.
            }
        }
    }

    public TerrainRegionData GetTerrainRegionData(Vector3 position)
    {
        // Convert the position to grid coordinates.
        int x = Mathf.FloorToInt(position.x);
        int y = Mathf.FloorToInt(position.z); // Use the z value for y because Unity is 3D and y is up.

        // Ensure the coordinates are within the grid's bounds.
        x = Mathf.Clamp(x, 0, width - 1);
        y = Mathf.Clamp(y, 0, height - 1);

        return grid[x, y];
    }

}
