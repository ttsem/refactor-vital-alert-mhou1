namespace checker.Services
{
    internal interface IAlertService
    {
        void SendAlert(string message);
        void SendFlashingAlert(string message);
    }
}
