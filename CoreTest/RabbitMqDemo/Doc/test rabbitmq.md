# test rabbitmq

### BasicPublish / BasicConsume

- 测试publish

  - RabbitMqDemo.Program.Main() 方法中 打开注释

    ```c#
    basicPublish.PublishToDefaultExchange()
    ```
    进入目录 RabbitMqDemo\RabbitMqDemo\bin\Debug\netcoreapp3.1
  - 打开cmd， 输入命令 **dotnet RabbitMqDemo.dll**
- 测试consumer

  - RabbitMqConsumerDemo.Program.Main() 方法中 打开注释

    ```c#
    BasicConsume.ConsumeFromDefaultExchange();
    ```
  - 进入目录 RabbitMqDemo\RabbitMqConsumerDemo\bin\Debug\net5.0
  - 打开cmd， 输入命令 **dotnet RabbitMqConsumerDemo.dll**
