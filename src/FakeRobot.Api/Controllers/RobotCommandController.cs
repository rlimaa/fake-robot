using FakeRobot.Api.Helpers;
using FakeRobot.Application.Interface;
using FakeRobot.Contracts;
using FakeRobot.Models;
using Microsoft.AspNetCore.Mvc;

namespace FakeRobot.Api.Controllers;

[ApiController]
public class RobotCommandController : ControllerBase
{
    private IRobotCommandService _robotCommandService;
    
    public RobotCommandController(IRobotCommandService robotCommandService)
    {
        _robotCommandService = robotCommandService;
    }
    
    [HttpPost]
    [Route("pyyne-cleaning-robot/enter-path")]
    public IActionResult PostCommand(RobotCommandSet robotCommandSet)
    {
        try
        {
            var validation = ValidationHelper.ValidateCommandSet(robotCommandSet);
            if (!validation.IsValid)
            {
                return BadRequest(string.Join(';', validation.Messages));
            }
            
            var res = _robotCommandService.ProcessCommand(robotCommandSet);
            return Ok(res);

        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    } 
}