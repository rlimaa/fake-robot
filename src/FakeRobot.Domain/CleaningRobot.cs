using FakeRobot.Enums;
using FakeRobot.Models;

namespace FakeRobot;

public class CleaningRobot(Coordinate start)
{
    private Coordinate CurrentPosition { get; set; } = start;

    public int ProcessCommands(IEnumerable<RobotCommand> commands)
    {
        return commands.Sum(ProcessCommand);
    }

    private int ProcessCommand(RobotCommand command)
    {
        switch (command.Direction)
        {
            case Direction.East:
                return MoveEast(command.Steps);
            case Direction.West:
                return MoveWest(command.Steps);
            case Direction.North:
                return MoveNorth(command.Steps);
            case Direction.South:
                return MoveSouth(command.Steps);
            default:
                return 0;
        }
    }

    private int MoveEast(int steps)
    {
        CurrentPosition.X += steps;
        //TODO COUNT NUMBER OF UNIQUE PLACES CLEANED
        return 1;
    }
    
    private int MoveWest(int steps)
    {
        CurrentPosition.X -= steps;
        //TODO COUNT NUMBER OF UNIQUE PLACES CLEANED
        return 1;
    } 
    
    private int MoveNorth(int steps)
    {
        CurrentPosition.Y += steps;
        //TODO COUNT NUMBER OF UNIQUE PLACES CLEANED
        return 1;
    }
    
    private int MoveSouth(int steps)
    {
        CurrentPosition.Y -= steps;
        //TODO COUNT NUMBER OF UNIQUE PLACES CLEANED
        return 1;
    }
}