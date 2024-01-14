using daniil_ivanov_kt_41_20.Database;
using daniil_ivanov_kt_41_20.Extensions;
using daniil_ivanov_kt_41_20.Middlewares;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<TeacherDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddServices();
    
    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<TeacherDbContext>();
            context.InitializeWithDefaultValues();
        }
        catch (Exception ex)
        {
            var log = services.GetRequiredService<ILogger<Program>>();
            log.LogError(ex, "Error while initializing database");
        }
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    logger.Error(e, "Exception");
}
finally
{
    LogManager.Shutdown();
}