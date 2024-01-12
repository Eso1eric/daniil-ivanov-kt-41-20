using daniil_ivanov_kt_41_20.Filters.TeacgersFilters;
using daniil_ivanov_kt_41_20.Interfaces.TeachersInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace daniil_ivanov_kt_41_20.Controllers;

[ApiController]
[Route("[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ILogger<TeachersController> _logger;
    private readonly ITeacherService _service;

    public TeachersController(ILogger<TeachersController> logger, ITeacherService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost(Name = "GetTeachers")]
    public async Task<IActionResult> GetTeachers(TeacherFilter filter, CancellationToken cancellationToken = default)
    {
        var teachers = await _service.GetTeachers(filter, cancellationToken);
        
        return Ok(teachers);
    }
}