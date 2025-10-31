using Microsoft.AspNetCore.Diagnostics;
using NLog.Targets;
using NLog.Web;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    // 监听所有 IP 地址的 8080 端口（HTTP）
    serverOptions.ListenAnyIP(8080);
    // 监听本地回环地址的 5001 端口（HTTPS），并指定证书
    //serverOptions.Listen(IPAddress.Loopback, 5001, listenOptions =>
    //{
    //    listenOptions.UseHttps("certificate.pfx", "password");
    //});
});

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
}

//捕获异常中间件


app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        // using static System.Net.Mime.MediaTypeNames;
        //context.Response.ContentType = Text.Plain;
        //await context.Response.WriteAsync("api: An exception was thrown.");

        Console.WriteLine("api: An exception was thrown.");

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error is not null)
        {
            Console.WriteLine(exceptionHandlerPathFeature?.Error);
        }

        
    });
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
