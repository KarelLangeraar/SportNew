using Microsoft.EntityFrameworkCore;
using MVC.Data;
using SportData.Data.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Sport");
builder.Services.AddDbContext<Sport.Data.SportContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Sport")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/", (IUnitOfWork UnitOfWork) =>
{
    return UnitOfWork.Club.GetAll();
});


app.UseHttpsRedirection();

app.Run();