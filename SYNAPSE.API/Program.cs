using Microsoft.VisualBasic;
using SYNAPSE.API.Model;
using SYNAPSE.API.Utilidade;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

builder.Configuration.AddJsonFile("appsettings.json",
    optional: false,
    reloadOnChange: true); //NECESSÁRIO PARA ADICIONAR O appsettings.json

var configPath = builder.Configuration["ConfigPath"];
if (!String.IsNullOrEmpty(configPath))
{
    try
    {
        var constant = new Constant();
        constant.ConfigFilePath = configPath;
    }
    catch
    {
        throw;
    }
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3001", "http://192.168.1.101:3001")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
