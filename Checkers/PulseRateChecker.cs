namespace checker.Checkers
{
    internal class PulseRateChecker : IChecker<int>
    {
        public static int MinValue => 60;
        public static int MaxValue => 100;

        public static bool CheckOk(int value)
        {
            if (value < MinValue || value > MaxValue)
            {
                return false;
            }
            return true;
        }
    }
}
