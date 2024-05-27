using FakeRobot.Contracts;

namespace FakeRobot.Api.Helpers;

public class ValidationResult
{
    public bool IsValid { get; set; } = true;
    public IList<string> Messages { get; set; } = new List<string>();
}


public static class ValidationHelper
{
    public static ValidationResult ValidateCommandSet(RobotCommandSet commandSet)
    {
        var res = new ValidationResult();

        if (commandSet.Start.X == null)
        {
            res.IsValid = false;
            res.Messages.Add("Starting position `X` can not be null");
        }
        else if (commandSet.Start.X is < -100000 or > 100000)
        {
            res.IsValid = false;
            res.Messages.Add("Starting position `X` must be greater than -100000 and less than 100000");
        }
        
        if (commandSet.Start.Y == null)
        {
            res.IsValid = false;
            res.Messages.Add("Starting position `Y` can not be null");
        }
        else if (commandSet.Start.Y is < -100000 or > 100000)
        {
            res.IsValid = false;
            res.Messages.Add("Starting position `Y` must be greater than -100000 and less than 100000");
        }

        if (commandSet.Commands.Count() > 10000)
        {
            res.IsValid = false;
            res.Messages.Add("Number of `Commands` can not be greater than 10000");
        }

        if (commandSet.Commands.Any(x => x.Steps is < 0 or > 100000))
        {
            res.IsValid = false;
            res.Messages.Add("Number of `Steps` must be greater than 0 and less than 100000");
        }
        
        
        return res;
    }
}