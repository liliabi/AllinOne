USE [master]
GO

/****** Object:  Database [AllinOne]    Script Date: 2022/01/04 17:07:53 ******/
CREATE DATABASE [AllinOne] ON  PRIMARY 
( NAME = N'AllinOne', FILENAME = N'D:\DB\AllinOne.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AllinOne_log', FILENAME = N'D:\DB\AllinOne_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [AllinOne] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AllinOne].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [AllinOne] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [AllinOne] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [AllinOne] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [AllinOne] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [AllinOne] SET ARITHABORT OFF 
GO

ALTER DATABASE [AllinOne] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [AllinOne] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [AllinOne] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [AllinOne] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [AllinOne] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [AllinOne] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [AllinOne] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [AllinOne] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [AllinOne] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [AllinOne] SET  DISABLE_BROKER 
GO

ALTER DATABASE [AllinOne] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [AllinOne] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [AllinOne] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [AllinOne] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [AllinOne] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [AllinOne] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [AllinOne] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [AllinOne] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [AllinOne] SET  MULTI_USER 
GO

ALTER DATABASE [AllinOne] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [AllinOne] SET DB_CHAINING OFF 
GO

ALTER DATABASE [AllinOne] SET  READ_WRITE 
GO


USE [AllinOne]
GO

/****** Object:  Table [dbo].[SysSerialNumber]    Script Date: 2022/01/04 17:08:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SysSerialNumber](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Project] [nvarchar](50) NOT NULL,
	[SeqNoDate] [date] NULL,
	[MaxSeqNo] [bigint] NOT NULL,
 CONSTRAINT [PK_SysSerialNumber] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [AllinOne]
GO

/****** Object:  Table [dbo].[WmiServerList]    Script Date: 2022/01/04 17:08:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WmiServerList](
	[SGUID] [nvarchar](100) NOT NULL,
	[ServerName] [nvarchar](max) NOT NULL,
	[ServerIP] [nvarchar](max) NOT NULL,
	[ServerDesc] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[UserPwd] [nvarchar](max) NOT NULL,
	[ServerType] [nvarchar](max) NOT NULL,
	[Creator] [nvarchar](max) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Updator] [nvarchar](max) NULL,
	[UpdateTime] [datetime] NULL,
	[Ver] [timestamp] NOT NULL,
 CONSTRAINT [PK_WmiServerList] PRIMARY KEY CLUSTERED 
(
	[SGUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerList', @level2type=N'COLUMN',@level2name=N'ServerType'
GO

USE [AllinOne]
GO
/****** Object:  Table [dbo].[WmiServerMain]    Script Date: 2022/01/08 11:43:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WmiServerMain](
	[TicketNo] [nvarchar](50) NOT NULL,
	[SGUID] [nvarchar](100) NOT NULL,
	[ServerName] [nvarchar](max) NULL,
	[ServerIP] [nvarchar](max) NULL,
	[ServerDesc] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WmiServerMain] PRIMARY KEY CLUSTERED 
(
	[TicketNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


USE [AllinOne]
GO

/****** Object:  Table [dbo].[WmiServerCpu]    Script Date: 2022/01/08 11:45:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WmiServerCpu](
	[TicketNo] [nvarchar](50) NOT NULL,
	[Seq] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DeviceID] [nvarchar](max) NOT NULL,
	[AddressWidth] [int] NULL,
	[Architecture] [int] NULL,
	[AssetTag] [nvarchar](max) NULL,
	[Availability] [int] NULL,
	[Caption] [nvarchar](max) NULL,
	[Characteristics] [int] NULL,
	[ConfigManagerErrorCode] [int] NULL,
	[ConfigManagerUserConfig] [bit] NULL,
	[CpuStatus] [int] NULL,
	[CreationClassName] [nvarchar](max) NULL,
	[CurrentClockSpeed] [int] NULL,
	[CurrentVoltage] [int] NULL,
	[DataWidth] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[ErrorCleared] [bit] NULL,
	[ErrorDescription] [nvarchar](max) NULL,
	[ExtClock] [int] NULL,
	[Family] [int] NULL,
	[L2CacheSize] [int] NULL,
	[L2CacheSpeed] [int] NULL,
	[L3CacheSize] [int] NULL,
	[L3CacheSpeed] [int] NULL,
	[LastErrorCode] [int] NULL,
	[Level] [int] NULL,
	[LoadPercentage] [int] NULL,
	[Manufacturer] [nvarchar](max) NULL,
	[MaxClockSpeed] [int] NULL,
	[NumberOfCores] [int] NULL,
	[NumberOfEnabledCore] [int] NULL,
	[NumberOfLogicalProcessors] [int] NULL,
	[OtherFamilyDescription] [nvarchar](max) NULL,
	[PartNumber] [nvarchar](max) NULL,
	[PNPDeviceID] [nvarchar](max) NULL,
	[PowerManagementCapabilities] [int] NULL,
	[PowerManagementSupported] [bit] NULL,
	[ProcessorId] [nvarchar](max) NULL,
	[ProcessorType] [int] NULL,
	[Revision] [int] NULL,
	[Role] [nvarchar](max) NULL,
	[SecondLevelAddressTranslationExtensions] [bit] NULL,
	[SerialNumber] [nvarchar](max) NULL,
	[SocketDesignation] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[StatusInfo] [int] NULL,
	[Stepping] [nvarchar](max) NULL,
	[SystemCreationClassName] [nvarchar](max) NULL,
	[SystemName] [nvarchar](max) NULL,
	[ThreadCount] [int] NULL,
	[UniqueId] [nvarchar](max) NULL,
	[UpgradeMethod] [int] NULL,
	[Version] [nvarchar](max) NULL,
	[VirtualizationFirmwareEnabled] [bit] NULL,
	[VMMonitorModeExtensions] [bit] NULL,
	[VoltageCaps] [int] NULL,
 CONSTRAINT [PK_WmiServerCpu] PRIMARY KEY CLUSTERED 
(
	[TicketNo] ASC,
	[Seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器的名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在系统上的处理器的唯一标识符' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'DeviceID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'AddressWidth'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所使用的平台的处理器架构' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Architecture'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'该处理器的资产标签' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'AssetTag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备的状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Availability'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CPU的简短描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Caption'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器支持定义的功能' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Characteristics'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Windows API的配置管理器错误代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'ConfigManagerErrorCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果为TRUE，该装置是使用用户定义的配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'ConfigManagerUserConfig'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器的当前状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'CpuStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出现在用来创建一个实例继承链的第一个具体类的名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'CreationClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器的当前速度，以MHz为单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'CurrentClockSpeed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器的电压' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'CurrentVoltage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在32位处理器，该值是32，在64位处理器是64' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'DataWidth'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CPU的简短描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果为真，报上一个错误代码的被清除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'ErrorCleared'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误的代码描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'ErrorDescription'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部时钟频率，以MHz为单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'ExtClock'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器系列类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Family'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'二级缓存大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'L2CacheSize'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'二级缓存处理器的时钟速度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'L2CacheSpeed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'三级缓存的大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'L3CacheSize'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'三级缓存处理器的时钟速度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'L3CacheSpeed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报告的逻辑设备上一个错误代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'LastErrorCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器类型的定义。该值取决于处理器的体系结构' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Level'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'每个处理器的负载能力，平均到最后一秒' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'LoadPercentage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器的制造商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Manufacturer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器的最大速度，以MHz为单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'MaxClockSpeed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'为处理器的当前实例的数目。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'NumberOfCores'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'每个处理器插槽启用的内核数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'NumberOfEnabledCore'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用于处理器的当前实例逻辑处理器的数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'NumberOfLogicalProcessors'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器系列类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'OtherFamilyDescription'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'这款处理器的产品编号制造商所设置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'PartNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'即插即用逻辑设备的播放设备标识符' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'PNPDeviceID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'逻辑设备的特定功率相关的能力阵列' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'PowerManagementCapabilities'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果为TRUE，该装置的功率可以被管理，这意味着它可以被放入挂起模式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'PowerManagementSupported'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述处理器功能的处理器的信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'ProcessorId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器的主要功能' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'ProcessorType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统修订级别取决于体系结构' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Revision'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所述处理器的作用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Role'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果为True，该处理器支持用于虚拟地址转换扩展' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'SecondLevelAddressTranslationExtensions'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理器的序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'SerialNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'芯片插座的线路上使用的类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'SocketDesignation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对象的当前状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对象的当前状态信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'StatusInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在处理器家族处理器的版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Stepping'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建类名属性的作用域计算机的价值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'SystemCreationClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统的名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'SystemName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'每个处理器插槽的线程数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'ThreadCount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'全局唯一标识符的处理器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'UniqueId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CPU插槽的信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'UpgradeMethod'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'依赖于架构处理器的版本号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'Version'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果真，固件可以虚拟化扩展' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'VirtualizationFirmwareEnabled'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果为True，该处理器支持Intel或AMD虚拟机监控器扩展。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'VMMonitorModeExtensions'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'该处理器的电压的能力' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerCpu', @level2type=N'COLUMN',@level2name=N'VoltageCaps'
GO


