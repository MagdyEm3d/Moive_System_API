using Microsoft.EntityFrameworkCore;
using Web_API_Assigmnet.Connection;
using Web_API_Assigmnet.Reposatoty;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//change in gitewdew

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connection));
builder.Services.AddScoped<IMoiveReposatory,MoiveReposatory>();
builder.Services.AddScoped<IDirectorReposatory,DirectorReposatory>();
builder.Services.AddScoped<ICategoryReposatory,CategoryReposatory>();
builder.Services.AddScoped<INationalityReposatory,NationatilyReposatory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
