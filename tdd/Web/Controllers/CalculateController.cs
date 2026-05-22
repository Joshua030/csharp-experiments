namespace Controllers;

using Domain;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]//NOTE - controller take the name of the calls as path
public class CalculateController : ControllerBase
{

    [HttpGet("add/{left}/{right}")]
    public int Get(int left, int right)
    {
        Calculator calculator = new();
        return calculator.Sum(left, right);

    }
}