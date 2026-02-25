using FluentValidation.AspNetCore;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddFluentValidationAutoValidation();

        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = false
                };
            });

        services.AddAuthorization();

        return services;
    }
}