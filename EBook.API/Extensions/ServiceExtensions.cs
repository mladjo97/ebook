namespace EBook.API.Extensions
{
    using EBook.Persistence;
    using EBook.Persistence.Contracts;
    using EBook.Services;
    using EBook.Services.Contracts;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public static class ServiceExtensions
    {
        private static string JwtConfigKey = "jwt";
        private static string IssuerConfigKey = "issuer";
        private static string SecretConfigKey = "secret";
        private static string AudienceConfigKey = "audience";

        public static void ConfigureCors(this IServiceCollection services)
            => services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

        public static void ConfigureAuthorization(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = config.GetSection(JwtConfigKey).GetValue<string>(IssuerConfigKey),

                        ValidateAudience = true,
                        ValidAudience = config.GetSection(JwtConfigKey).GetValue<string>(AudienceConfigKey),

                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config.GetSection(JwtConfigKey).GetValue<string>(SecretConfigKey))
                        )
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse();

                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                            return context.Response.WriteAsync("Unauthorized");
                        }
                    };
                });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthenticationService>();
        }
    }
}
