namespace FakeRobot.Contracts;

public record CommandsSummary(int Id, DateTime Timestamp, int Commands, int Result, double Duration)
{
    public int Id { get; set; } = Id;
    public DateTime Timestamp { get; set; } = Timestamp;
    public int Commands { get; set; } = Commands;
    public int Result { get; set; } = Result;
    public double Duration { get; set; } = Duration;
}