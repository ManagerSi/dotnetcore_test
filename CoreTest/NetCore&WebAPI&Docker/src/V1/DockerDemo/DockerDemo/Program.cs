using NLog.Web;
using NLog.Targets;

var builder = WebApplication.CreateBuilder(args);

//use nlog
builder.WebHost.ConfigureAppConfiguration(webBuilder =>
{
    NLogBuilder.ConfigureNLog($"nlog.config");
    //NLog.LogManager.Setup().LoadConfigurationFromAppSettings("nlog.config", optional: false);
});
builder.WebHost.UseNLog(); 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
