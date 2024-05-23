namespace FakeRobot.DataObject;

public record CommandsResult(int NumberCleanedPlaces, double ElapsedMilliSeconds)
{
    public int NumberCleanedPlaces { get; set; } = NumberCleanedPlaces;
    public double ElapsedMilliSeconds { get; set; } = ElapsedMilliSeconds;
}