namespace FakeRobot.Models;

public record Coordinate(int X, int Y)
{
    public int X { get; internal set; } = X;
    public int Y { get; internal set; } = Y;
}