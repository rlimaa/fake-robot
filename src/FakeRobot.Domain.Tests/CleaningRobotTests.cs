using FakeRobot.Enums;
using FakeRobot.Models;

namespace FakeRobot.Domain.Tests;

public class Tests
{
    [TestCase(1, 1, 1, 1, 1, 1, ExpectedResult = 4)]
    [TestCase(1, 1, 2, 1, 0, 1, ExpectedResult = 4)]
    [TestCase(1, 1, 3, 1, 2, 3, ExpectedResult = 9)]
    public int ProcessCommands_ShouldReturnNumberOfCleanedPlaces(int startX, int startY, int nStepsSouth, int nStepsWest, int nStepsNorth, int nStepsEast)
    {
        var sut = new CleaningRobot(new Coordinate(startX, startY));
        var commands = GenerateRobotCommandSet(nStepsSouth, nStepsWest, nStepsNorth, nStepsEast);
        var res= sut.ProcessCommands(commands);
        return res.NumberCleanedPlaces;
    }

    [TestCase(ExpectedResult = 8)]
    public int ProcessCommands_ShouldReturnRightNumberOfCleanedPlacesIfLoop()
    {
        var sut = new CleaningRobot(new Coordinate(0, 0));
        var commands = GenerateRobotCommandSet(2, 2, 2, 2)
            .Concat(GenerateRobotCommandSet(2, 2, 2, 2));
        var res= sut.ProcessCommands(commands);
        return res.NumberCleanedPlaces;
    }

    private static IEnumerable<RobotCommand> GenerateRobotCommandSet(int nStepsSouth = 0, int nStepsWest = 0,  int nStepsNorth = 0, int nStepsEast = 0) =>
        new[]
        {
            new RobotCommand(Direction.South, nStepsSouth),
            new RobotCommand(Direction.West, nStepsWest),
            new RobotCommand(Direction.North, nStepsNorth),
            new RobotCommand(Direction.East, nStepsEast)
        };
}