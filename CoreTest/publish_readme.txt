iis配置网站
（先安装AspNetCoreModuleV2模块，此模块可以处理core代码）

（直接新建网站指定bin目录不能跑）
1. 需要发布（发布过程中添加web.config文件）
2. iis指定发布后的文件夹
3. 启动浏览即可

将发布生成web.config文件，内部指定了modules，所以将此文件放在bin目录，在iis添加网站并指定bin目录也可以跑起来。

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath="dotnet" arguments=".\CacheDemo.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess" />
    </system.webServer>
  </location>
</configuration>
<!--ProjectGuid: 057e6491-e84c-4042-a977-089999de5f29-->