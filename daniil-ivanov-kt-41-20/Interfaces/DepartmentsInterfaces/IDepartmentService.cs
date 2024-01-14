using daniil_ivanov_kt_41_20.Database;
using daniil_ivanov_kt_41_20.Filters.DepartmentsFilters;
using daniil_ivanov_kt_41_20.Model;
using Microsoft.EntityFrameworkCore;

namespace daniil_ivanov_kt_41_20.Interfaces.DepartmentsInterfaces;

public interface IDepartmentService
{
    public Task<Department[]> GetDepartmentsByCreateDate(DepartmentCreateDateFilter filter , CancellationToken cancellationToken);
    public Task<Department[]> GetDepartmentsByNumberOfTeachers(DepartmentNumberOfTeachersFilter filter, CancellationToken cancellationToken);
    public Dictionary<Department, Teacher> GetWithHeadTeacher(params Department[] departments);
}

public class DepartmentService : IDepartmentService
{
    private readonly TeacherDbContext _context;

    public DepartmentService(TeacherDbContext context)
    {
        _context = context;
    }

    public Task<Department[]> GetDepartmentsByCreateDate(DepartmentCreateDateFilter filter, CancellationToken cancellationToken = default)
    {
        filter.CreateDateStart ??= DateTime.MinValue;
        filter.CreateDateEnd ??= DateTime.MaxValue;

        return _context.Set<Department>()
            .Where(e => e.CreateDate >= filter.CreateDateStart && e.CreateDate <= filter.CreateDateEnd)
            .ToArrayAsync(cancellationToken);
    }

    public Task<Department[]> GetDepartmentsByNumberOfTeachers(DepartmentNumberOfTeachersFilter filter, CancellationToken cancellationToken = default)
    {
        filter.MinNumberOfTeachers ??= 0;
        filter.MaxNumberOfTeachers ??= int.MaxValue;

        return _context.Set<Department>()
            .Where(e => _context.Set<Teacher>().Count(t => t.DepartmentId == e.Id) >= filter.MinNumberOfTeachers &&
                        _context.Set<Teacher>().Count(t => t.DepartmentId == e.Id) <= filter.MaxNumberOfTeachers)
            .ToArrayAsync(cancellationToken);
    }

    public Dictionary<Department, Teacher> GetWithHeadTeacher(params Department[] departments)
    {
        var dict = new Dictionary<Department, Teacher>();
        departments.ToList().ForEach(e => dict.Add(e, _context.Set<Teacher>().First(t => t.DepartmentId == e.Id && t.isHeadTeacher)));
        
        return dict;
    }
}