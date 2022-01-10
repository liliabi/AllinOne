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

USE [AllinOne]
GO

/****** Object:  Table [dbo].[WmiServerMemory]    Script Date: 2022/01/10 09:48:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WmiServerMemory](
	[TicketNo] [nvarchar](50) NOT NULL,
	[Seq] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[MemAttribute] [int] NULL,
	[Capacity] [bigint] NULL,
	[Caption] [nvarchar](max) NULL,
	[ConfiguredClockSpeed] [int] NULL,
	[ConfiguredVoltage] [int] NULL,
	[CreationClassName] [nvarchar](max) NULL,
	[DataWidth] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[DeviceLocator] [nvarchar](max) NULL,
	[FormFactor] [int] NULL,
	[HotSwappable] [bit] NULL,
	[InterleaveDataDepth] [int] NULL,
	[InterleavePosition] [int] NULL,
	[Manufacturer] [nvarchar](max) NULL,
	[MaxVoltage] [int] NULL,
	[MemoryType] [int] NULL,
	[MinVoltage] [int] NULL,
	[Model] [nvarchar](max) NULL,
	[OtherIdentifyingInfo] [nvarchar](max) NULL,
	[PartNumber] [nvarchar](max) NULL,
	[PositionInRow] [int] NULL,
	[PoweredOn] [bit] NULL,
	[Removable] [bit] NULL,
	[Replaceable] [bit] NULL,
	[SerialNumber] [nvarchar](max) NULL,
	[SKU] [nvarchar](max) NULL,
	[SMBIOSMemoryType] [int] NULL,
	[Speed] [int] NULL,
	[Status] [nvarchar](max) NULL,
	[Tag] [nvarchar](max) NULL,
	[TotalWidth] [int] NULL,
	[TypeDetail] [int] NULL,
	[Version] [nvarchar](max) NULL,
 CONSTRAINT [PK_WmiServerMemory] PRIMARY KEY CLUSTERED 
(
	[TicketNo] ASC,
	[Seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'MemAttribute'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'获取内存容量（单位KB）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Capacity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物理内存还是虚拟内存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Caption'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置时钟速度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'ConfiguredClockSpeed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置电压' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'ConfiguredVoltage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建类名（就是更换这个类的名字）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'CreationClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'获取内存带宽' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'DataWidth'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述信息与Caption一样' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'获取设备定位器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'DeviceLocator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'构成因素' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'FormFactor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否支持热插拔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'HotSwappable'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据交错深度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'InterleaveDataDepth'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交错的位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'InterleavePosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Manufacturer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大电压' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'MaxVoltage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内存类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'MemoryType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小电压' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'MinVoltage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Model'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他识别信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'OtherIdentifyingInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'零件编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'PartNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'PositionInRow'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否接通电源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'PoweredOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可拆卸' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Removable'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可更换' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Replaceable'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'SerialNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SKU号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'SKU'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SMBIOS内存类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'SMBIOSMemoryType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'速率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Speed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一标识符的物理存储器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Tag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总宽' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'TotalWidth'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型详细信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'TypeDetail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerMemory', @level2type=N'COLUMN',@level2name=N'Version'
GO


USE [AllinOne]
GO

/****** Object:  Table [dbo].[WmiServerDisk]    Script Date: 2022/01/10 09:47:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WmiServerDisk](
	[TicketNo] [nvarchar](50) NOT NULL,
	[Seq] [int] NOT NULL,
	[Availability] [int] NULL,
	[BytesPerSector] [int] NULL,
	[Caption] [nvarchar](max) NULL,
	[CompressionMethod] [nvarchar](max) NULL,
	[ConfigManagerErrorCode] [int] NULL,
	[ConfigManagerUserConfig] [bit] NULL,
	[CreationClassName] [nvarchar](max) NULL,
	[DefaultBlockSize] [bigint] NULL,
	[Description] [nvarchar](max) NULL,
	[DeviceID] [nvarchar](max) NULL,
	[ErrorCleared] [bit] NULL,
	[ErrorDescription] [nvarchar](max) NULL,
	[ErrorMethodology] [nvarchar](max) NULL,
	[FirmwareRevision] [nvarchar](max) NULL,
	[Index] [int] NULL,
	[InterfaceType] [nvarchar](max) NULL,
	[LastErrorCode] [int] NULL,
	[Manufacturer] [nvarchar](max) NULL,
	[MaxBlockSize] [bigint] NULL,
	[MaxMediaSize] [bigint] NULL,
	[MediaLoaded] [bit] NULL,
	[MediaType] [nvarchar](max) NULL,
	[MinBlockSize] [bigint] NULL,
	[Model] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[NeedsCleaning] [bit] NULL,
	[NumberOfMediaSupported] [int] NULL,
	[Partitions] [int] NULL,
	[PNPDeviceID] [nvarchar](max) NULL,
	[PowerManagementSupported] [bit] NULL,
	[SCSIBus] [int] NULL,
	[SCSILogicalUnit] [int] NULL,
	[SCSIPort] [int] NULL,
	[SCSITargetId] [int] NULL,
	[SectorsPerTrack] [int] NULL,
	[SerialNumber] [nvarchar](max) NULL,
	[Signature] [int] NULL,
	[Size] [bigint] NULL,
	[Status] [nvarchar](max) NULL,
	[StatusInfo] [int] NULL,
	[SystemCreationClassName] [nvarchar](max) NULL,
	[SystemName] [nvarchar](max) NULL,
	[TotalCylinders] [bigint] NULL,
	[TotalHeads] [int] NULL,
	[TotalSectors] [bigint] NULL,
	[TotalTracks] [bigint] NULL,
	[TracksPerCylinder] [int] NULL,
 CONSTRAINT [PK_WmiServerDisk] PRIMARY KEY CLUSTERED 
(
	[TicketNo] ASC,
	[Seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备的状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Availability'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在每个扇区的物理磁盘驱动器的字节数）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'BytesPerSector'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对象的序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Caption'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备所使用的算法或工具，以支持压缩。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'CompressionMethod'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Windows配置管理器错误代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'ConfigManagerErrorCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果为True，该设备使用用户定义的配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'ConfigManagerUserConfig'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代表所在的类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'CreationClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'此设备默认块大小，以字节为单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'DefaultBlockSize'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'磁盘驱动器与系统中的其他设备的唯一标识符' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'DeviceID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果为True，报告LastErrorCode错误现已清除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'ErrorCleared'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关于可能采取的纠正措施记录在LastErrorCode错误，和信息的详细信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'ErrorDescription'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'误差检测和校正的类型被此设备支持' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'ErrorMethodology'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修订制造商分配的磁盘驱动器固件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'FirmwareRevision'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'给定的驱动器的物理驱动器号。此属性由GetDriveMapInfo方法填补。 0xFF的值表示给定的驱动器不映射到物理驱动器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Index'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物理磁盘驱动器的类型 （IDE、sata）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'InterfaceType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报告的逻辑设备上一个错误代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'LastErrorCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造商名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Manufacturer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大块的大小，以字节为单位，通过该设备访问的媒体' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'MaxBlockSize'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大介质尺寸的介质，以KB为单位，由该设备支持' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'MaxMediaSize'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果真，媒体为一磁盘驱动器加载，这意味着该设备具有一个可读的文件系统和可访问。对于固定磁盘驱动器，该属性将始终为TRUE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'MediaLoaded'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由该设备使用或访问的媒体类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'MediaType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小的块大小，以字节为单位，通过该设备访问的媒体' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'MinBlockSize'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'磁盘驱动器的制造商的型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Model'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果真，媒体接入设备需要清洁。不论手动或自动清洗是可能显示在Capabilities属性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'NeedsCleaning'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可被支持的或插入的介质最大数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'NumberOfMediaSupported'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'此物理磁盘驱动器上的分区是由操作系统识别的数目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Partitions'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'即插即用逻辑设备的播放设备标识符' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'PNPDeviceID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果为True，该设备可以是电源管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'PowerManagementSupported'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘驱动器的SCSI总线号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'SCSIBus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SCSI逻辑单元的磁盘驱动器的号码（LUN）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'SCSILogicalUnit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘驱动器的SCSI端口号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'SCSIPort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SCSI标识符号码的磁盘驱动器的' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'SCSITargetId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在每个轨道此物理磁盘驱动器扇区数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'SectorsPerTrack'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由制造商分配的号来识别物理介质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'SerialNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'磁盘识别。该属性可以被用于识别一个共享资源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Signature'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'磁盘大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Size'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对象的当前状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'逻辑设备的状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'StatusInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'该作用域计算机的CreationClassName属性的值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'SystemCreationClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'SystemName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物理磁盘驱动器上柱面总数。该值可能不准确' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'TotalCylinders'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'磁盘驱动器上磁头总数。该值可能不准确' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'TotalHeads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物理磁盘驱动器上的扇区总数。该值可能不准确' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'TotalSectors'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物理磁盘驱动器上的曲目总数。该值可能不准确' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'TotalTracks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在物理磁盘驱动器上的每个柱面轨迹的数量。该值可能不准确' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmiServerDisk', @level2type=N'COLUMN',@level2name=N'TracksPerCylinder'
GO


USE [AllinOne]
GO

/****** Object:  Table [dbo].[WmiServerLogicalDisk]    Script Date: 2022/01/10 14:22:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WmiServerLogicalDisk](
	[TicketNo] [nvarchar](50) NOT NULL,
	[Seq] [int] NOT NULL,
	[Access] [int] NULL,
	[Availability] [int] NULL,
	[BlockSize] [bigint] NULL,
	[Caption] [nvarchar](max) NULL,
	[Compressed] [bit] NULL,
	[ConfigManagerErrorCode] [int] NULL,
	[ConfigManagerUserConfig] [bit] NULL,
	[CreationClassName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DeviceID] [nvarchar](max) NULL,
	[DriveType] [int] NULL,
	[ErrorCleared] [bit] NULL,
	[ErrorDescription] [nvarchar](max) NULL,
	[ErrorMethodology] [nvarchar](max) NULL,
	[FileSystem] [nvarchar](max) NULL,
	[FreeSpace] [bigint] NULL,
	[LastErrorCode] [int] NULL,
	[MaximumComponentLength] [int] NULL,
	[MediaType] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[NumberOfBlocks] [bigint] NULL,
	[PNPDeviceID] [nvarchar](max) NULL,
	[PowerManagementSupported] [bit] NULL,
	[ProviderName] [nvarchar](max) NULL,
	[Purpose] [nvarchar](max) NULL,
	[QuotasDisabled] [bit] NULL,
	[QuotasIncomplete] [bit] NULL,
	[QuotasRebuilding] [bit] NULL,
	[Size] [bigint] NULL,
	[Status] [nvarchar](max) NULL,
	[StatusInfo] [int] NULL,
	[SupportsDiskQuotas] [bit] NULL,
	[SupportsFileBasedCompression] [bit] NULL,
	[SystemCreationClassName] [nvarchar](max) NULL,
	[SystemName] [nvarchar](max) NULL,
	[VolumeDirty] [bit] NULL,
	[VolumeName] [nvarchar](max) NULL,
	[VolumeSerialNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_WmiServerLogicalDisk] PRIMARY KEY CLUSTERED 
(
	[TicketNo] ASC,
	[Seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


