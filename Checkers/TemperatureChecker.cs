namespace checker.Checkers
{
    internal class TemperatureChecker : IChecker<float>
    {
        public static float MinValue => 95;
        public static float MaxValue => 102;

        public static bool CheckOk(float value)
        {
            if (value < MinValue || value > MaxValue)
            {
                return false;
            }
            return true;
        }
    }
}