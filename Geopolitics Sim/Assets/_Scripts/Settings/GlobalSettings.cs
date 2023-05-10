public static class GlobalSettings
{
    public static int FoodToRep { get; private set; }
    public static int FoodToSurvive { get; private set; }
    
    public static void SetFoodToRep(int i) => FoodToRep = i;
    public static void SetFoodToSurvive(int i) => FoodToSurvive = i;
    
    
    
    public static float MinSpeed { get; private set; }
    public static float MaxSpeed { get; private set; }

    public static void SetMinSpeed(float i) => MinSpeed = i;
    public static void SetMaxSpeed(float i) => MaxSpeed = i;


    public static float MutationMultiplier { get; private set; }

    public static void SetMutationMultiplier(float f) => MutationMultiplier = f;
}