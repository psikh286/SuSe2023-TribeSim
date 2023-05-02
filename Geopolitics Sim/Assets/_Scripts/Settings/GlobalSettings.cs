public static class GlobalSettings
{
    public static int FoodToRep { get; private set; }
    public static int FoodToSurvive { get; private set; }

    public static void SetFoodToRep(int i) => FoodToRep = i;
    public static void SetFoodToSurvive(int i) => FoodToSurvive = i;
}