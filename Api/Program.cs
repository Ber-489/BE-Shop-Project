using Api;
using Application;
using Infrastructure.DependencyInjection;
using Api.Middlewares;
using Microsoft.AspNetCore.Mvc;

// Khởi tạo Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // xây môi trường 
    builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
        optional: true);

    // Gắn Serilog vào host
    builder.Host.UseSerilog();
    Log.Information("Application starting...");

    // Thêm carter
    builder.Services.AddCarter();

    // Thêm MediatR
    builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CheckPhoneExistsQuery).Assembly));

    // Add layers (đúng vai trò)
    builder.Services
        .AddApi()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    // Cấu hình phản hồi lỗi validation
    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var response = ApiResponse<string>.Fail(
                "400",
                "Validation failed",
                context.ModelState);

            return new BadRequestObjectResult(response);
        };
    });

    // Cấu hình OtpSettings
    builder.Services.Configure<OtpSettings>(
    builder.Configuration.GetSection("OtpSettings"));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // HTTP pipeline
    app.UseAuthentication();
    app.UseAuthorization();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionHandlingMiddleware>();
    
    app.UseHangfireDashboard("/hangfire", new DashboardOptions
    {
        Authorization = new[] { new Hangfire.Dashboard.LocalRequestsOnlyAuthorizationFilter() }
    });

    // Map endpoints (Users)
    app.MapCarter();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}