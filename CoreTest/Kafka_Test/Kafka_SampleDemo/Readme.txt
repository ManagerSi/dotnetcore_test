步骤：
1. 先创建电商项目
2. 准备Kafka
	2.1 下载Kafka
	2.2 进入bin\windows目录，启动zookeeper
		zookeeper-server-start.bat ../../config/zookeeper.properties
	2.3 进入bin\windows目录，启动Kafka
		kafka-server-start.bat ../../config/server.properties

	执行命令时会出现以下错误，是因为执行目录太深或目录名太长导致，请将Kafka目录移动到如D盘根目录下执行！
	    输入行太长。
	    命令语法不正确。

3. 启动Kafka_Publisher 和 Kafka_Consumer
4. 打开Kafka_Publisher 的swagger，调用post方法，发送消息
5. 查看两个控制台显示的内容
