using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace RestAPI
{
    public static class ApiExtensions
    {
        public static void AddApiAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["tasty-cookies"];

                        return Task.CompletedTask;
                    },
                };

            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
                options.AddPolicy("MethodistOnly", policy => policy.RequireRole("Методист"));
                options.AddPolicy("RectorOnly", policy => policy.RequireRole("Проректор"));
                options.AddPolicy("ResponWarehouseOnly", policy => policy.RequireRole("Ответственный за склад"));
                options.AddPolicy("EngineerOnly", policy => policy.RequireRole("Инженер коммуникационного центра"));
            });

            

        }
    }
}
