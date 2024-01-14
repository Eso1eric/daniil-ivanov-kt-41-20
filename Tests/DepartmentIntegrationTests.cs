using daniil_ivanov_kt_41_20.Database;
using daniil_ivanov_kt_41_20.Filters.TeacgersFilters;
using daniil_ivanov_kt_41_20.Interfaces.TeachersInterfaces;
using daniil_ivanov_kt_41_20.Model;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class DepartmentIntegrationTests
{
    public readonly DbContextOptions<TeacherDbContext> _ContextOptions;

    public DepartmentIntegrationTests()
    {
        _ContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
            .UseInMemoryDatabase(databaseName: "Teachers")
            .Options;
    }

    [Fact]
    public async void GetTeachersByDepartmentShortName_KT_TwoObjects()
    {
        var ctx = new TeacherDbContext(_ContextOptions);
        var service = new TeacherService(ctx);
        
        var departments = new Department[]
        {
            new()
            {
                ShortName = "ИВТ",
                FullName = "Информатика и вычислительная техника",
                CreateDate = DateTime.Now
            },
            new()
            {
                ShortName = "КТ",
                FullName = "Компьютерные технологии",
                CreateDate = DateTime.Now
            }
        };
        
        await ctx.Set<Department>().AddRangeAsync(departments);
        var degrees = new Degree[]
        {
            new() { Name = "Кандидат наук" },
            new() { Name = "Доктор наук" }
        };

        await ctx.Set<Degree>().AddRangeAsync(degrees);
        var positions = new Position[]
        {
            new() { Name = "Преподаватель" },
            new() { Name = "Старший преподаватель" },
            new() { Name = "Профессор" }
        };

        await ctx.Set<Position>().AddRangeAsync(positions);
        var teachers = new Teacher[]
        {
            new()
            {
                Name = "Иванов",
                Surname = "Иван",
                Lastname = "Иванович",
                isHeadTeacher = true,
                DegreeId = 1,
                Degree = degrees[0],
                PositionId = 1,
                Position = positions[0],
                DepartmentId = 1,
                Department = departments[0]
            },
            new()
            {
                Name = "Никита",
                Surname = "Васильев",
                Lastname = "Васильевич",
                isHeadTeacher = false,
                DegreeId = 1,
                Degree = degrees[0],
                PositionId = 1,
                Position = positions[0],
                DepartmentId = 2,
                Department = departments[1]
            },
            new()
            {
                Name = "Степанов",
                Surname = "Степан",
                Lastname = "Степанович",
                isHeadTeacher = true,
                DegreeId = 2,
                Degree = degrees[1],
                PositionId = 2,
                Position = positions[1],
                DepartmentId = 2,
                Department = departments[1]
            }
        };

        await ctx.Set<Teacher>().AddRangeAsync(teachers);
        await ctx.SaveChangesAsync();
        var filter = new TeacherFilter()
        {
            DepartmentShortName = "КТ"
        };

        var result = await service.GetTeachers(filter, CancellationToken.None);
        
        Assert.Equal(2, result.Length);
    }
}