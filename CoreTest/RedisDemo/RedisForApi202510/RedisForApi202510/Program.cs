using Microsoft.Extensions.DependencyInjection; // ��Ӵ� using ָ��
using Microsoft.Extensions.Caching.StackExchangeRedis; // ��Ӵ� using ָ��

namespace RedisForApi202510
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
            });

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
        }
    }
}
