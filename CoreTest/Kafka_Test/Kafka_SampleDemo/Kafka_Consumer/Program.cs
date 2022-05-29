// See https://aka.ms/new-console-template for more information

using Confluent.Kafka;

Console.WriteLine("Hello, World!");

//等publisher先启动
Thread.Sleep(TimeSpan.FromSeconds(10));

new Task(() => {
    var consumerConfig = new ConsumerConfig
    {
        BootstrapServers = "127.0.0.1:9092",
        AutoOffsetReset = AutoOffsetReset.Earliest,
        GroupId = Guid.NewGuid().ToString(),
        EnableAutoCommit = true,
    };
    var builder = new ConsumerBuilder<string, string>(consumerConfig);
    var consumer = builder.Build();
    // 1、订阅
    consumer.Subscribe("Weather-create");
    Console.WriteLine($"已订阅Weather-create");
    while (true)
    {
        // 2、消费
        var result = consumer.Consume();//拉消息
        string key = result.Key;
        string value = result.Value;

        Console.WriteLine($"key:{key}, weather:{value}");
    }
}).Start();

Console.ReadKey();