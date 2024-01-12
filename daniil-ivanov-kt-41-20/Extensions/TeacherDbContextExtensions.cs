using daniil_ivanov_kt_41_20.Database;
using daniil_ivanov_kt_41_20.Model;

namespace daniil_ivanov_kt_41_20.Extensions;

public static class TeacherDbContextExtensions
{
    public static void InitializeWithDefaultValues(this TeacherDbContext context)
    {
        context.Database.EnsureCreated();
        
        if (context.Teachers.Any())
            return;

        var departments = new Department[]
        {
            new()
            {
                ShortName = "КТ",
                FullName = "Компьютерные технологии",
                CreateDate = DateTime.Now
            },
            new()
            {
                ShortName = "ИВТ",
                FullName = "Информатика и вычислительная техника",
                CreateDate = DateTime.Now
            }
        };

        var degrees = new Degree[]
        {
            new() { Name = "Кандидат наук" },
            new() { Name = "Доктор наук" }
        };

        var positions = new Position[]
        {
            new() { Name = "Преподаватель" },
            new() { Name = "Старший преподаватель" },
            new() { Name = "Профессор" }
        };

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

        var subjects = new Subject[]
        {
            new()
            {
                Name = "Объектно-ориентированное программирование",
                TeacherId = 1,
                Teacher = teachers[0]
            },
            new()
            {
                Name = "Программная инженерия",
                TeacherId = 2,
                Teacher = teachers[1]
            }
        };

        var workloads = new Workload[]
        {
            new()
            {
                Hours = 26,
                DepartmentId = 1,
                Department = departments[0],
                TeacherId = 1,
                Teacher = teachers[0],
                SubjectId = 1,
                Subject = subjects[0]
            },
            new()
            {
                Hours = 52,
                DepartmentId = 2,
                Department = departments[1],
                TeacherId = 2,
                Teacher = teachers[1],
                SubjectId = 2,
                Subject = subjects[1]
            }
        };

        foreach (var department in departments)
            context.Departments.Add(department);

        foreach (var degree in degrees)
            context.Degrees.Add(degree);

        foreach (var position in positions)
            context.Positions.Add(position);

        foreach (var teacher in teachers)
            context.Teachers.Add(teacher);

        foreach (var subject in subjects)
            context.Subjects.Add(subject);

        foreach (var workload in workloads)
            context.Workloads.Add(workload);

        context.SaveChanges();
    }
}