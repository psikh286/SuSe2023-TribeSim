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

    #region Food

    public static float IsHungryPercent { get; private set; }
    public static void SetIsHungryPercent(float f) => IsHungryPercent = f;
    
    public static float FoodRegain { get; private set; }
    public static void SetFoodRegain(float f) => FoodRegain = f;

    #endregion

    #region Water

    public static float IsThirstyPercent { get; private set; }
    public static void SetIsThirstyPercent(float f) => IsThirstyPercent = f;
    
    public static float WaterRegain { get; private set; }
    public static void SetWaterRegain(float f) => WaterRegain = f;

    #endregion

    #region Energy

    public static float EnergyRestPoint { get; private set; }
    public static void SetEnergyRestPoint(float f) => EnergyRestPoint = f;
    
    public static float EnergyRegain { get; private set; }
    public static void SetEnergyRegain(float f) => EnergyRegain = f;
    
   

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