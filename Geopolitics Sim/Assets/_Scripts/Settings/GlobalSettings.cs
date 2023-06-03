public static class GlobalSettings
{
    #region Inheretance

    public static float MinSpeed { get; private set; }
    public static void SetMinSpeed(float i) => MinSpeed = i;
    
    public static float MaxSpeed { get; private set; }
    public static void SetMaxSpeed(float i) => MaxSpeed = i;


    public static float MutationMultiplier { get; private set; }
    public static void SetMutationMultiplier(float f) => MutationMultiplier = f;

    #endregion
    
    #region Food

    public static float IsHungryThreshold { get; private set; }
    public static void SetIsHungryThreshold(float f) => IsHungryThreshold = f;
    
    public static float MinFoodRegain { get; private set; }
    public static void SetMinFoodRegain(float f) => MinFoodRegain = f;
    
    public static float MaxFoodRegain { get; private set; }
    public static void SetMaxFoodRegain(float f) => MaxFoodRegain = f;
    
    public static int FoodToRep { get; private set; }
    public static void SetFoodToRep(int i) => FoodToRep = i;
    
    #endregion

    #region Water

    public static float IsThirstyThreshold { get; private set; }
    public static void SetIsThirstyThreshold(float f) => IsThirstyThreshold = f;
    
    public static float MinWaterRegain { get; private set; }
    public static void SetMinWaterRegain(float f) => MinWaterRegain = f;
    
    public static float MaxWaterRegain { get; private set; }
    public static void SetMaxWaterRegain(float f) => MaxWaterRegain = f;
    
    public static int WaterToRep { get; private set; }
    public static void SetWaterToRep(int i) => WaterToRep = i;

    #endregion

    #region Energy

    public static float EnergyRestPoint { get; private set; }
    public static void SetEnergyRestPoint(float f) => EnergyRestPoint = f;
    
    public static float RestRegain { get; private set; }
    public static void SetRestRegain(float f) => RestRegain = f;
    
    
    #endregion

    #region DayAndNight

    public static TimeOfDay Time { get; private set; }
    public static void SetTimeOfTheDay(TimeOfDay time) => Time = time;

    #endregion

    #region Memory
    
    public static int MaxPositionMemory { get; private set; }
    public static void SetMaxPositionMemory(int i) => MaxPositionMemory = i;

    #endregion
}