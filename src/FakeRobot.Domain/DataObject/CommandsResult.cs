namespace FakeRobot.DataObject;

public record CommandsResult(int NumberCleanedPlaces, long ElapsedMilliSeconds)
{
    public int NumberCleanedPlaces { get; set; } = NumberCleanedPlaces;
    public long ElapsedMilliSeconds { get; set; } = ElapsedMilliSeconds;
}