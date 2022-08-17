using ExampleLifecycleDI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExampleLifecycleDI.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ITransientService _transientService1;
    private readonly ITransientService _transientService2;
    private readonly IScopedService _scopedService1;
    private readonly IScopedService _scopedService2;
    private readonly ISingletonService _singletonService1;
    private readonly ISingletonService _singletonService2;

    public HomeController(ITransientService transientService1,
                          ITransientService transientService2,
                          IScopedService scopedService1,
                          IScopedService scopedService2,
                          ISingletonService singletonService1,
                          ISingletonService singletonService2)
    {
        _transientService1 = transientService1;
        _transientService2 = transientService2;
        _scopedService1 = scopedService1;
        _scopedService2 = scopedService2;
        _singletonService1 = singletonService1;
        _singletonService2 = singletonService2;
    }

    [HttpGet("GetAllServices")]
    public IActionResult GetAllServices()
    {
        var result = new
        {
            serviceType1 = "Transient",
            firstOperationId1 = _transientService1.GetOperationID(),
            secondOperationId1 = _transientService2.GetOperationID(),
            serviceType2 = "Scoped",
            firstOperationId2 = _scopedService1.GetOperationID(),
            secondOperationId2 = _scopedService1.GetOperationID(),
            serviceType3 = "Singleton",
            firstOperationId3 = _singletonService1.GetOperationID(),
            secondOperationId3 = _singletonService2.GetOperationID()
        };

        return Ok(result);
    }

    [HttpGet("GetSingleton")]
    public IActionResult GetSingleton()
    {
        return Ok(new { singletonId = _singletonService1.GetId() });
    }

    [HttpPost("PostSingleton/{id}")]
    public IActionResult PostSingleton(int id)
    {
        _singletonService1.SetId(id);

        return Ok("Ok");
    }

    [HttpGet("GetTransient")]
    public IActionResult GetTransient()
    {
        return Ok(new { transientId = _transientService1.GetId() });
    }

    [HttpPost("PostTransient/{id}")]
    public IActionResult PostTransient(int id)
    {
        _transientService1.SetId(id);

        return Ok("Ok");
    }
}
