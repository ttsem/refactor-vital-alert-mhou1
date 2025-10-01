namespace checker.Checkers
{
    internal class OxygenSaturationChecker : IChecker<int>
    {
        public static int MinValue => 90;

        public static bool CheckOk(int value)
        {
            if (value < MinValue)
            {
                return false;
            }
            return true;
        }
    }
}
