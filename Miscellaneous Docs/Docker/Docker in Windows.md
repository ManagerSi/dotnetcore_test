# Docker in Windows 

## 本概念
先盘点以下这几个东西的相互关系应该是这样，Docker需要运行在LInux环境下，你的宿主机如果是Windows呢，同时又想要拥有一个Linux系统玩一玩（真贪心），那么此时就需要通过虚拟机（VMware、VirtualBox等）、WSL1, WSL2（Winddows实现虚拟化的）来实现了。还有一个Docker Desktop又是什么东东呢？

其实直接在Ubuntu中使用apt install命令就能安装docker，但是docker官方已经有了适用于Windows中WSL2环境的桌面版本的docker，比较方便，而且有图形界面，便于上手。其实简单理解，Docker Desktop就是使用WSL2作为后端引擎的一个桌面端管理Docker的工具。

所以本质上就是在windows环境安装一个linux子系统，在这个子系统上安装docker，windows上使用cmd/powershell 通过WSL技术直连docker。

##  安装WSL 及 Linux子系统

参考连接： 

[basic-commands]: 

[basic-commands]: https://docs.microsoft.com/en-us/windows/wsl/basic-commands	"wsl commands"

Install in PowerShell
```powershell
wsl --install
```
Update WSL
```powershell
wsl --update
```
Shutdown
```powershell
wsl --shutdown
```
Check WSL status
```powershell
wsl --status
```

List available Linux distributions 查询可在windows上安装的 linux 系统
```powershell
wsl --list --online
```
Install a specific Linux distribution 安装linux子系统
```powershell
wsl --install --distribution <Distribution Name>
```
List installed Linux distributions
```powershell
wsl --list --verbose
#or
wsl -l -v
```
Set default WSL version （要在安装Linux后设置，不然会有冲突）
```powershell
wsl --set-default-version 2 #设置为2
```

##  安装的Linux子系统可以直接从cmd里进入

这样我们即使不进入docker容器也能使用linux内核环境，记住是内核环境和子系统默认的windows内核区别很大。
用途主要是可以不使用docker情况，在windows里编译linux程序和使用linux。我们可以看到c盘和其他设备是挂载在/mnt里。就是我可以直接访问别的磁盘。 简单测试下。
打开vscode或terminal

```powershell
wsl -l -v
#  NAME                   STATE           VERSION
#* docker-desktop         Running         2      
#  Ubuntu                 Running         2      
#  docker-desktop-data    Running         2      
# 这时候我们默认* 是docker-desktop。如果我们输入wsl 就会进入docker-desktop， 但我们想进入Ubuntu呢？

# 运行分支
wsl -d Ubuntu
```
上面进入Ubuntu后，执行docker 命令后，结果和直接在cmd执行docker命令出来的结果一致，同时和docker desktop软件里面的内容一致。cmd命令就是通过wsl转化后传入了linux内部执行的。

修改wsl默认分支
```powershell
# 修改默认分支 
wsl  --shutdown  # 先停止所有分支的运行
wsl -s Ubuntu # 设置默认分支

wsl -l -v
#  NAME                   STATE           VERSION
# * Ubuntu                 Running         2
#  docker-desktop-data    Stopped         2
#  docker-desktop         Running         2
```

##  将默认安装在c盘的Linux移动到其他盘

因为这个Docker和子系统Ubuntu都是默认装在C盘 LOCALAPPDATA%/Docker/wsl/data/ext4.vhdx等，现在我们就要打包项目走别的磁盘这里用F盘。 这里可以提前创建号目录， 这样我们就不担心C盘会被占容量。。。。

```powershell
wsl --shutdown # 关闭所有分支
wsl --export docker-desktop-data F:\wsl\docker-desktop-data\docker-desktop-data.tar # 导出Docker Data镜像包
wsl --export Ubuntu F:\wsl\ubuntu\Ubuntu.tar # 导出Ubuntu镜像包
wsl --unregister docker-desktop-data # 注销docker镜像
wsl --unregister Ubuntu # 注销Ubuntu镜像
wsl --import docker-desktop-data F:\wsl\docker-desktop-data\ F:\wsl\docker-desktop-data\docker-desktop-data.tar --version 2 # 重新导入Docker data 打包好的镜像
wsl --import Ubuntu F:\wsl\ubuntu\ F:\wsl\ubuntu\Ubuntu.tar --version 2 # 重新导入Ubuntu打包好的镜像
```

## Mount a disk or device 挂载硬盘

WSL 系统可以通过 `/mnt/<盘号>/` 目录（[挂载](https://so.csdn.net/so/search?q=挂载&spm=1001.2101.3001.7020)点）来访问你计算机上的文件系统。举个例子，你的 Windows 上的 C:\ 和 D:\ 根目录可以在 WSL 中相应地通过 /mnt/c 和 /mnt/d 访问。当你要把你的 Windows 下的项目文件、下载的内容和其它文件用到 Linux/Bash 之中时这很有用。

下面是在Linux子系统中查看G盘内容

```shell
root@DESKTOP-16HJCLR:/# ls
bin   dev  home  lib    lost+found  mnt  proc  run   snap  sys  usr
boot  etc  init  lib64  media       opt  root  sbin  srv   tmp  var
root@DESKTOP-16HJCLR:/# ls /mnt/g
BaoMi   GitRepository     NET core      pcfollow.server  System Volume Information  yuan      书籍
Docker  html5boilerplate  pagefile.sys  $RECYCLE.BIN     tmp                        yuan.zip  视频
root@DESKTOP-16HJCLR:/# cd /mnt/g/docker
root@DESKTOP-16HJCLR:/mnt/g/docker# ls
wsl
```

Mount a disk or device command 

https://docs.microsoft.com/en-us/windows/wsl/wsl2-mount-disk

```powershell
wsl --mount <DiskPath>
```
Attach and mount a physical disk in all WSL2 distributions by replacing `<DiskPath>` with the directory\file path where the disk is located. See [Mount a Linux disk in WSL 2](https://docs.microsoft.com/en-us/windows/wsl/wsl2-mount-disk). Options include:

- `wsl --mount --bare`: Attach the disk to WSL2, but don't mount it.
- `wsl --mount --type <Filesystem>`: Filesystem type to use when mounting a disk, if not specified defaults to ext4. This command can also be entered as: `wsl --mount -t <Filesystem>`.You can detect the filesystem type using the command: `blkid <BlockDevice>`, for example: `blkid <dev/sdb1>`.
- `wsl --mount --partition <Partition Number>`: Index number of the partition to mount, if not specified defaults to the whole disk.
- `wsl --mount --options <MountOptions>`: There are some filesystem-specific options that can be included when mounting a disk. For example, [ext4 mount options](https://www.kernel.org/doc/Documentation/filesystems/ext4.txt) like: `wsl --mount -o "data-ordered"` or `wsl --mount -o "data=writeback`. However, only filesystem-specific options are supported at this time. Generic options, such as `ro`, `rw`, or `noatime`, are not supported.
- `wsl --unmount <DiskPath>`: Unmount and detach the disk from all WSL 2 distributions. If the `<DiskPath>` is not included, this command will unmount and detach ALL mounted disks.