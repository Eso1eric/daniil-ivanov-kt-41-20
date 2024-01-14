using daniil_ivanov_kt_41_20.Filters.DepartmentsFilters;
using daniil_ivanov_kt_41_20.Interfaces.DepartmentsInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace daniil_ivanov_kt_41_20.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly ILogger<TeachersController> _logger;
    private readonly IDepartmentService _service;

    public DepartmentsController(ILogger<TeachersController> logger, IDepartmentService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost]
    [Route("GetDepartmentsByCreateDate")]
    public async Task<IActionResult> GetDepartmentsByCreateDate(DepartmentCreateDateFilter filter, CancellationToken cancellationToken = default)
    {
        var departments = await _service.GetDepartmentsByCreateDate(filter, cancellationToken);
        var departmentsWithHeadTeachers = _service.GetWithHeadTeacher(departments);
        
        return Ok(departmentsWithHeadTeachers.Select(e =>
            new {
                e.Key.Id,
                e.Key.ShortName,
                e.Key.FullName,
                e.Key.CreateDate,
                HeadTeacher = e.Value
            }));
    }
    
    [HttpPost]
    [Route("GetDepartmentsByNumberOfTeachers")]
    public async Task<IActionResult> GetDepartmentsByNumberOfTeachers(DepartmentNumberOfTeachersFilter filter, CancellationToken cancellationToken = default)
    {
        var departments = await _service.GetDepartmentsByNumberOfTeachers(filter, cancellationToken);
        var departmentsWithHeadTeachers = _service.GetWithHeadTeacher(departments);
        
        return Ok(departmentsWithHeadTeachers.Select(e =>
            new {
                e.Key.Id,
                e.Key.ShortName,
                e.Key.FullName,
                e.Key.CreateDate,
                HeadTeacher = e.Value
            }));
    }
}