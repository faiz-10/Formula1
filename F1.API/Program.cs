using F1.API.Data;
using F1.API.Mappings;
using F1.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "F1 API", Version = "v1" });
});

builder.Services.AddDbContext<F1DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Register Repositories
builder.Services.AddScoped<ITeamsRepository, TeamsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
