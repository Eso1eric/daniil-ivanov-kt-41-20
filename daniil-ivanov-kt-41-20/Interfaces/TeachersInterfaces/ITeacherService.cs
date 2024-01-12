using daniil_ivanov_kt_41_20.Database;
using daniil_ivanov_kt_41_20.Filters.TeacgersFilters;
using daniil_ivanov_kt_41_20.Model;
using Microsoft.EntityFrameworkCore;

namespace daniil_ivanov_kt_41_20.Interfaces.TeachersInterfaces;

public interface ITeacherService
{
    public Task<Teacher[]> GetTeachers(TeacherFilter teacherFilter, CancellationToken cancellationToken);
}

public class TeacherService : ITeacherService
{
    private readonly TeacherDbContext _context;

    public TeacherService(TeacherDbContext context)
    {
        _context = context;
    }

    public Task<Teacher[]> GetTeachers(TeacherFilter teacherFilter, CancellationToken cancellationToken = default)
    {
        return _context.Set<Teacher>().Where(e =>
            string.IsNullOrEmpty(teacherFilter.DegreeName)
                ? string.IsNullOrEmpty(teacherFilter.PositionName)
                    ? e.Department.ShortName == teacherFilter.DepartmentShortName
                    : e.Position.Name == teacherFilter.PositionName
                : e.Degree.Name == teacherFilter.DegreeName).ToArrayAsync(cancellationToken);
    }
}