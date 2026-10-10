using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Configurations;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Data.Repository;
using ProjectManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectManagementDBConnection"));
});

builder.Services.AddAutoMapper(cfg => { }, typeof(AutoMapperConfig));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
