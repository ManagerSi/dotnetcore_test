# Test rabbitmq

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

### Transaction 事务测试

- 测试publish

  - RabbitMqDemo.Program.Main() 方法中 打开注释

    ```c#
    var transactionPublish = host.Services.GetService(typeof(TransactionPublish)) as TransactionPublish;
                transactionPublish.PublishWithTransaction()
                .ConfigureAwait(false).GetAwaiter().GetResult();
    ```

    进入目录 RabbitMqDemo\RabbitMqDemo\bin\Debug\netcoreapp3.1

  - 打开cmd， 输入命令 **dotnet RabbitMqDemo.dll**

- 测试consumer

  - 进入目录 RabbitMqDemo\RabbitMqConsumerDemo\bin\Debug\net5.0
  - 双击RabbitMqConsumerDemo.exe，可多次双击启动多个实例

