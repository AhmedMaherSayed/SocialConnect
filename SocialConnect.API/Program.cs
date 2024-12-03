
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SocialConnect.API.Helpers;
using SocialConnect.Repository.Data;
using SocialConnect.Service;
using System.Security.Claims;
using System.Text;

namespace SocialConnect.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            // Register DbContext Service
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"))

            );

            builder.Services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Social Media System Project",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = " Bearer 1safsfsdfdfd",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        new string[] {}
                 }
            });
                c.EnableAnnotations();
            });
            builder.Services.AddScoped<UnitOfwork>();

            // Register Identity Service
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(
            // validate token
            op =>
            {
                op.SaveToken = true;
                #region secret key
                string key = "My Complex Secret Key My Complex Secret Key My Complex Secret Key";
                var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                #endregion
                op.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true; // Must contain at least one digit
                options.Password.RequiredLength = 3;  // Minimum length of 3 characters
                options.Password.RequireNonAlphanumeric = false; //not Must contain at least one special character
                options.Password.RequireUppercase = false; // not Must contain at least one uppercase letter
                options.Password.RequireLowercase = false; // not Must contain at least one lowercase letter
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
            });



            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("JustAdmins", policy => policy
                    .RequireClaim(ClaimTypes.Role, "Admin")
                    .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy("UsersorAdmins", policy => policy
                    .RequireClaim(ClaimTypes.Role, "Admin", "User")
                    .RequireClaim(ClaimTypes.NameIdentifier));
            });
            // Configure Session
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10); // Session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseAuthentication();  // Added Authentication middleware before Authorization
            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<MyHub>("/myhub");

            app.Run();
        }
    }
}