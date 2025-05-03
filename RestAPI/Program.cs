
using BLL;
using BLL.Interface;
using BLL.Service;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(5001); // ”казываем нужный порт
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();
            builder.Services.AddScoped<ITokenService, TokenService>();  

            builder.Services.AddBusinessLogical();
            builder.Services.AddApiAuthentication(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowUI", policy =>
                {
                    policy.WithOrigins("https://localhost:7216") 
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            app.UseCors("AllowUI");
            app.UseAuthentication();
            app.UseAuthorization();

            

            app.MapControllers();

            app.Run();
        }
    }
}
