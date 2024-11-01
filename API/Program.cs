using Application.Services;
using Core.Abstractions;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<KpoDbContext>(
    options =>
    {
        options.UseNpgsql(
            builder.Configuration.GetConnectionString("postgre"),
            b => b.MigrationsAssembly("API")
        );
    });

builder.Services.AddScoped<IAccounting, AccountingRepository>();
builder.Services.AddScoped<IAccountingService, AccountingService>();
builder.Services.AddScoped<IStore, StoreRepository>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAttendance, AttendanceRepository>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();

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
