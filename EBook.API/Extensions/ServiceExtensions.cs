namespace EBook.API.Extensions
{
    using EBook.Persistence;
    using EBook.Persistence.Contracts;
    using EBook.Services;
    using EBook.Services.Contracts;
    using EBook.Services.Contracts.Convert;
    using EBook.Services.Convert;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public static class ServiceExtensions
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEBooksSearchService, EBooksSearchService>();
            services.AddScoped<IEBooksFilterService, EBooksFilterService>();
            services.AddScoped<IEBookRepositoryService, EBookRepositoryService>();
            services.AddScoped<IEBookServicesWrapper, EBookServicesWrapper>();

            services.AddScoped<IFilePdfConverter, PdfConverter>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IEBooksRepository, EBooksRepository>();
        }

        public static void ConfigureCors(this IServiceCollection services)
            => services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        public static void ConfigureAuthorization(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = config
                            .GetSection(ConfigurationSettings.JwtConfigKey)
                            .GetValue<string>(ConfigurationSettings.IssuerConfigKey),

                        ValidateAudience = true,
                        ValidAudience = config
                            .GetSection(ConfigurationSettings.JwtConfigKey)
                            .GetValue<string>(ConfigurationSettings.AudienceConfigKey),

                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config
                                .GetSection(ConfigurationSettings.JwtConfigKey)
                                .GetValue<string>(ConfigurationSettings.SecretConfigKey))
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

    }
}
