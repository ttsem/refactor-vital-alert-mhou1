using checker.Checkers;
using checker.Domain;
using checker.Services;

class Checker
{
    private static IAlertService AlertService = new ConsoleAlertService();
    private static readonly Dictionary<Type, string> AlertMessages = new()
    {
        { typeof(TemperatureChecker), "Temperature critical!" },
        { typeof(PulseRateChecker), "Pulse Rate is out of range!" },
        { typeof(OxygenSaturationChecker), "Oxygen Saturation out of range!" }
    };

    public static bool VitalsOk(Vitals vitals)
    {
        var checks = new (Func<bool> check, Type checkerType)[]
        {
            (() => TemperatureChecker.CheckOk(vitals.Temperature), typeof(TemperatureChecker)),
            (() => PulseRateChecker.CheckOk(vitals.PulseRate), typeof(PulseRateChecker)),
            (() => OxygenSaturationChecker.CheckOk(vitals.OxygenSaturation), typeof(OxygenSaturationChecker))
        };

        foreach (var (check, checkerType) in checks)
        {
            if (!check())
            {
                AlertService.SendFlashingAlert(AlertMessages[checkerType]);
                return false;
            }
        }

        AlertService.SendAlert("Vitals received within normal range");
        AlertService.SendAlert($"Temperature: {vitals.Temperature} Pulse: {vitals.PulseRate}, SO2: {vitals.OxygenSaturation}");
       
        return true;
    }
}
