public static class EnergySettings
{
    public static float EnergyCollectingFood { get; private set; }
    public static void SetEnergyCollectingFood(float f) => EnergyCollectingFood = f;

    public static float EnergyCollectingWater { get; private set; }
    public static void SetEnergyCollectingWater(float f) => EnergyCollectingWater = f;

    public static float EnergyWalk { get; private set; }
    public static void SetEnergyWalk(float f) => EnergyWalk = f;

    public static float EnergyReproduce { get; private set; }
    public static void SetEnergyReproduce(float f) => EnergyReproduce = f;

    public static float EnergyRequestMate { get; private set; }
    public static void SetEnergyRequestMate(float f) => EnergyRequestMate = f;

}