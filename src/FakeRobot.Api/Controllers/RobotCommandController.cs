using FakeRobot.Application.Interface;
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
    public async Task<bool> PostCommand(RobotCommandSet robotCommandSet)
    {
        await _robotCommandService.ProcessCommand(robotCommandSet);
        return true;
    } 
}