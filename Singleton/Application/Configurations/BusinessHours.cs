namespace Singleton.Application.Configurations;

public class BusinessHours {

    private static BusinessHours _instance;

    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    private BusinessHours(DateTime startTime, DateTime endTime) {
        this.StartTime = startTime;
        this.EndTime = endTime;
    }

    public static BusinessHours GetInstance() {
        if (_instance is null) {
            _instance = new BusinessHours(
                new DateTime(1, 1, 1, new Random().Next(0, 10), 0, 0),
                new DateTime(1, 1, 1, new Random().Next(18, 24), 0, 0)
            );

            Console.WriteLine("Nova instância gerada");
        }

        return _instance;
    }
}