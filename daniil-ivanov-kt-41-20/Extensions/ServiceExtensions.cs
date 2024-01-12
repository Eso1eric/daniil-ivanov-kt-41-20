using daniil_ivanov_kt_41_20.Interfaces.TeachersInterfaces;

namespace daniil_ivanov_kt_41_20.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITeacherService, TeacherService>();

        return services;
    }
}