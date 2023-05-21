[System.Serializable]
public class Resource
{
    public enum ResourceType { Food, Water }

    public ResourceType resourceType;
    public int quantity;
}