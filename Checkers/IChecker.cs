namespace checker.Checkers
{
    internal interface IChecker<T>
    {
        static abstract bool CheckOk(T value);
    }
}
