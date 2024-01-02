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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
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
