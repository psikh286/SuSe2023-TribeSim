public static class VisualConfiguration
{  
    public static float MinFoodScale { get; private set; }
    public static void SetMinFoodScale(float f) => MinFoodScale = f;

    public static float MaxFoodScale { get; private set; }
    public static void SetMaxFoodScale(float f) => MaxFoodScale = f;

}