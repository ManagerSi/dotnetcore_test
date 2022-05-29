using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Kafka_Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task PublishWeather(WeatherForecast orderCreateDto)
        {
            #region 2���첽��������
            {
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = "127.0.0.1:9092",
                    MessageTimeoutMs = 50000
                };

                var builder = new ProducerBuilder<string, string>(producerConfig);
                using (var producer = builder.Build())
                {
                    try
                    {
                        var WeatherJson = JsonConvert.SerializeObject(orderCreateDto);
                        var dr = await producer.ProduceAsync("Weather-create", new Message<string, string> { Key = "Weather", Value = WeatherJson });
                        _logger.LogInformation("�����¼� {0} �� {1} �ɹ�", dr.Value, dr.TopicPartitionOffset);
                    }
                    catch (ProduceException<string, string> ex)
                    {
                        _logger.LogError(ex, "�����¼��� {0} ʧ�ܣ�ԭ�� {1} ", "order", ex.Error.Reason);
                    }
                }
            }
            #endregion
        }

    }
}