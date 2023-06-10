using Microsoft.EntityFrameworkCore;
using MyList.Api.DAL;
using MyList.Api.DAL.Repositories;
using MyList.Api.Services;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("postgres");

builder.Services.AddCors();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<MyListDbContext>(x => x.UseNpgsql(connectionString));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IListService, ListService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3001", "http://localhost:3000"));
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpMetrics();

app.MapControllers();
app.MapMetrics();

app.Run();
