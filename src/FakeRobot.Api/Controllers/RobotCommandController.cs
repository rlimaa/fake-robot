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
            var res = _robotCommandService.ProcessCommand(robotCommandSet);
            return Ok(res);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    } 
}