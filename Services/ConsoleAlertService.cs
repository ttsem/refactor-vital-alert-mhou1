namespace checker.Services
{
    internal class ConsoleAlertService : IAlertService
    {
        public void SendAlert(string message)
        {
            Console.WriteLine(message);
        }

        public void SendFlashingAlert(string message)
        {
            SendAlert(message);
            for (int i = 0; i < 6; i++)
            {
                Console.Write("\r* ");
                Thread.Sleep(1000);
                Console.Write("\r *");
                Thread.Sleep(1000);
            }
        }
    }
}