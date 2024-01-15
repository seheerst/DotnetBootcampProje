using DotnetBootcampProje.Core.Repositories;
using DotnetBootcampProje.Core.Services;
using DotnetBootcampProje.Core.UnitOfWork;
using DotnetBootcampProje.Repository;
using DotnetBootcampProje.Repository.Repositories;
using DotnetBootcampProje.Repository.UnitOfWork;
using DotnetBootcampProje.Service;
using DotnetBootcampProje.Service.Mapping;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DotnetBootcampProje.Service.Validations;
using DotnetBootcampProje.Service.Services;
using Microsoft.OpenApi.Models;
using Autofac;
using DotnetBootcampProje.Api.Modules;
using Autofac.Extensions.DependencyInjection;
using DotnetBootcampProje.Service.Authorization.Abstraction;
using DotnetBootcampProje.Service.Authorization.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoModuleService()));

builder.Services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();

builder.Services.AddAutoMapper(typeof(MapProfile));

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers()
    .AddFluentValidation(x =>
    {
        x.RegisterValidatorsFromAssemblyContaining<ClassDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<TeacherDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<StudentDtoValidator>();
    });
#pragma warning restore CS0618 // Type or member is obsolete

builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
