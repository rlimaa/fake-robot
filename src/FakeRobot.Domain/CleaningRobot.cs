using System.Diagnostics;
using FakeRobot.DataObject;
using FakeRobot.Enums;
using FakeRobot.Models;

namespace FakeRobot;

public class CleaningRobot(Coordinate start)
{
    private Coordinate CurrentPosition { get; set; } = start;
    private IList<Coordinate> _visitedPlaces = new List<Coordinate>();

    public CommandsResult ProcessCommands(IEnumerable<RobotCommand> commands)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        _visitedPlaces.Add(new Coordinate(CurrentPosition.X, CurrentPosition.Y));
        foreach (var command in commands)
        {
            ProcessCommand(command);
        }

        var nCleanedPlaces = _visitedPlaces.Distinct().Count();
        Task.Delay(100);
        stopwatch.Stop();
        var ts = stopwatch.Elapsed; 
        var res = new CommandsResult(nCleanedPlaces, ts.Nanoseconds);
        return res;
    }

    private void ProcessCommand(RobotCommand command)
    {
        switch (command.Direction)
        {
            case Direction.East:
                MoveEast(command.Steps);
                return;
            case Direction.West:
                MoveWest(command.Steps);
                return;
            case Direction.North:
                MoveNorth(command.Steps);
                return;
            case Direction.South:
                MoveSouth(command.Steps);
                return;
        }
    }

    private void MoveEast(int steps)
    {
        for (var i = 1; i <= steps; i++)
        {
            CurrentPosition.X++;
            _visitedPlaces.Add(new Coordinate(CurrentPosition.X, CurrentPosition.Y));
        }
    }
    
    private void MoveWest(int steps)
    {
        for (var i = 1; i <= steps; i++)
        {
            CurrentPosition.X--;
            _visitedPlaces.Add(new Coordinate(CurrentPosition.X, CurrentPosition.Y));
        }
    } 
    
    private void MoveNorth(int steps)
    {
        for (var i = 1; i <= steps; i++)
        {
            CurrentPosition.Y++;
            _visitedPlaces.Add(new Coordinate(CurrentPosition.X, CurrentPosition.Y));
        }
    }
    
    private void MoveSouth(int steps)
    {
        for (var i = 1; i <= steps; i++)
        {
            CurrentPosition.Y--;
            _visitedPlaces.Add(new Coordinate(CurrentPosition.X, CurrentPosition.Y));
        }
    }
}