using Microsoft.EntityFrameworkCore;
using ReposituryPatternWithUOW.Core;
using ReposituryPatternWithUOW.Core.Interfaces;
using ReposituryPatternWithUOW.EF;
using ReposituryPatternWithUOW.EF.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
    b => b.MigrationsAssembly(typeof (ApplicationDBContext).Assembly.FullName)));


//builder.Services.AddTransient(typeof(IBaseRepositury<>), typeof(BaseRepositury<>));  NOT USING UNIT OF WORK
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>(); //USING UNIT OF WORK


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
