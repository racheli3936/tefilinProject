using core;
using core.IRepositories;
using core.IServices;
using data;
using data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using service;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

var connectionString = builder.Configuration["ConnectionString:connectDB"];
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString,  options => options.CommandTimeout(6000)));

builder.Services.AddCors(opt => opt.AddPolicy("MyPolicy", policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository,AuthRepository>();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository,CityRepository>();

builder.Services.AddScoped<IStoreOwnerService,StoreOwnerService>();
builder.Services.AddScoped<IStoreOwnerRepository, StoreOwnerRepository>();

builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();


builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "Hello World!");


app.Run();
