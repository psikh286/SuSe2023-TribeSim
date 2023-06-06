public static class EnergySettings
{
    public static float CollectFood { get; private set; }
    public static void SetEnergyCollectingFood(float f) => CollectFood = f;

    public static float CollectWater { get; private set; }
    public static void SetEnergyCollectingWater(float f) => CollectWater = f;

    public static float Walk { get; private set; }
    public static void SetEnergyWalk(float f) => Walk = f;

    public static float Reproduce { get; private set; }
    public static void SetEnergyReproduce(float f) => Reproduce = f;

    public static float RequestMate { get; private set; }
    public static void SetEnergyRequestMate(float f) => RequestMate = f;

    public static float EatFood { get; private set; }
    public static void SetEnergyEatFood(float f) => EatFood = f;
    
    public static float DrinkWater { get; private set; }
    public static void SetEnergyDrinkWater(float f) => EatFood = f;
}