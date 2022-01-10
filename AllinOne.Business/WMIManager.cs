using AllinOne.Business.Common;
using AllinOne.Entity;
using AllinOne.Entity.ViewModel;
using AllinOne.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Business
{
    public class WMIManager
    {
        private WMIRepository wmiRepository = new WMIRepository();
        private GetOrderNumber getOrderNumber = new GetOrderNumber();
        /// <summary>
        /// 获取服务器列表
        /// </summary>
        /// <returns></returns>
        public List<WmiServerList> GetAll()
        {
            return wmiRepository.GetAll();
        }

        #region 获取服务器WMI信息
        /// <summary>
        /// 对host主机PING命令
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static RESTfulResult TryPing(string host)
        {
            bool online = false;
            try
            {
                Ping pingSender = new Ping();
                PingReply pingReply = pingSender.Send(hostNameOrAddress: host, timeout: 10);

                online = pingReply.Status == IPStatus.Success ? true : false;

                return new RESTfulResult { StatusCode = 200, Succeeded = true, Data = pingReply, Message = "" };
            }
            catch (Exception ex)
            {
                return new RESTfulResult { StatusCode = 404, Succeeded = false, Data = "", Message = ex.Message };
            }

        }
        ManagementScope scope;
        ObjectQuery objectQuery;
        public RESTfulResult GetServiceInfo(string sguid)
        {
            WmiServerList wmi = wmiRepository.GetById(sguid);
            if (wmi == null)
            {
                return new RESTfulResult { StatusCode = 404, Succeeded = false, Data = "", Message = "找不到这个服务器！" };
            }
            ConnectionOptions conn = new ConnectionOptions();
            conn.Timeout = new TimeSpan(0, 0, 10);

            if (wmi.ServerIP != "." || wmi.ServerIP != "127.0.0.1")
            {
                conn.Username = wmi.UserId;
                conn.Password = wmi.UserPwd;
            }
            else
            {
                conn.EnablePrivileges = true;
            }
            string path = string.Format("\\\\{0}\\root\\cimv2", wmi.ServerIP);
            ManagementScope scope = new ManagementScope(path, conn);
            scope.Connect();

            WmiServerMain wmiServerMain = GetMain(sguid, wmi);

            Dictionary<string, string> queryDic = new Dictionary<string, string>();
            queryDic.Add("CPU", "select * from Win32_Processor");
            queryDic.Add("MEM", "select * from Win32_PhysicalMemory");
            queryDic.Add("DISK", "select * from Win32_DiskDrive");
            queryDic.Add("LOGICALDISK", "select * from Win32_LogicalDisk");
            objectQuery = new ObjectQuery(queryDic["CPU"]);
            List<WmiServerCpu> cpus = GetCpus(scope, wmiServerMain.TicketNo);

            objectQuery = new ObjectQuery(queryDic["MEM"]);
            List<WmiServerMemory> Mems = GetMems(scope, wmiServerMain.TicketNo);

            objectQuery = new ObjectQuery(queryDic["DISK"]);
            List<WmiServerDisk> Disks = GetDisks(scope, wmiServerMain.TicketNo);

            objectQuery = new ObjectQuery(queryDic["LOGICALDISK"]);
            List<WmiServerLogicalDisk> LogicalDisks = GetLogicalDisks(scope, wmiServerMain.TicketNo);
            if (wmiRepository.SaveServiceInfo(wmiServerMain, cpus, Mems, Disks, LogicalDisks))
            {
                return new RESTfulResult { StatusCode = 200, Succeeded = true, Data = wmi, Message = wmi.ServerIP + " 获取成功！" };
            }
            return new RESTfulResult { StatusCode = 404, Succeeded = false, Data = "", Message = "数据库插入异常！" };
        }

        

        private WmiServerMain GetMain(string sguid, WmiServerList wmi)
        {
            WmiServerMain wmiServerMain = new WmiServerMain();
            wmiServerMain.TicketNo = AllinOne.Business.Common.GetOrderNumber.GetWMINumber("WMITicket");
            wmiServerMain.SGUID = sguid;
            wmiServerMain.ServerName = wmi.ServerName;
            wmiServerMain.ServerIP = wmi.ServerIP;
            wmiServerMain.ServerDesc = wmi.ServerDesc;
            wmiServerMain.UserId = wmi.UserId;
            wmiServerMain.CreateDate = DateTime.Now;
            wmiServerMain.Creator = "Unknow";
            return wmiServerMain;
        }

        private List<WmiServerCpu> GetCpus(ManagementScope scope, string TicketNo)
        {
            ManagementObjectSearcher searcher = GetObjectSearcher(objectQuery, scope);
            List<WmiServerCpu> cpus = new List<WmiServerCpu>();
            int seq = 1;
            foreach (ManagementObject item in searcher.Get())
            {
                WmiServerCpu cpu = new WmiServerCpu();
                cpu.Seq = seq;
                cpu.TicketNo = TicketNo;
                cpu.AddressWidth = Convert.ToInt32(item["AddressWidth"]);
                cpu.Architecture = Convert.ToInt32(item["Architecture"]);
                cpu.AssetTag = item["AssetTag"].ToString();
                cpu.Availability = Convert.ToInt32(item["Availability"]);
                cpu.Caption = item["Caption"].ToString();
                cpu.Characteristics = Convert.ToInt32(item["Characteristics"]);
                cpu.ConfigManagerErrorCode = Convert.ToInt32(item["ConfigManagerErrorCode"]);
                cpu.ConfigManagerUserConfig = item["ConfigManagerUserConfig"] == null ? false : (Boolean)item["ConfigManagerUserConfig"];
                cpu.CpuStatus = Convert.ToInt32(item["CpuStatus"]);
                cpu.CreationClassName = item["CreationClassName"].ToString();
                cpu.CurrentClockSpeed = Convert.ToInt32(item["CurrentClockSpeed"]);
                cpu.CurrentVoltage = Convert.ToInt32(item["CurrentVoltage"]);
                cpu.DataWidth = Convert.ToInt32(item["DataWidth"]);
                cpu.Description = item["Description"].ToString();
                cpu.DeviceID = item["DeviceID"].ToString();
                cpu.ErrorCleared = item["ErrorCleared"] == null ? false : (Boolean)item["ErrorCleared"];
                cpu.ErrorDescription = item["ErrorDescription"] == null ? null : item["ErrorDescription"].ToString();
                cpu.ExtClock = Convert.ToInt32(item["ExtClock"]);
                cpu.Family = Convert.ToInt16(item["Family"]);
                //DateTime? installdate = item["InstallDate"] == null ? null : Convert.ToDateTime(item["InstallDate"]);
                cpu.L2CacheSize = Convert.ToInt32(item["L2CacheSize"]);
                cpu.L2CacheSpeed = Convert.ToInt32(item["L2CacheSpeed"]);
                cpu.L3CacheSize = Convert.ToInt32(item["L3CacheSize"]);
                cpu.L3CacheSpeed = Convert.ToInt32(item["L3CacheSpeed"]);
                cpu.LastErrorCode = Convert.ToInt32(item["LastErrorCode"]);
                cpu.Level = Convert.ToInt16(item["Level"]);
                cpu.LoadPercentage = Convert.ToInt32(item["LoadPercentage"]);
                cpu.Manufacturer = item["Manufacturer"] == null ? null : item["Manufacturer"].ToString();
                cpu.MaxClockSpeed = Convert.ToInt32(item["MaxClockSpeed"]);
                cpu.Name = item["Name"] == null ? null : item["Name"].ToString();
                cpu.NumberOfCores = Convert.ToInt32(item["NumberOfCores"]);
                cpu.NumberOfEnabledCore = Convert.ToInt32(item["NumberOfEnabledCore"]);
                cpu.NumberOfLogicalProcessors = Convert.ToInt32(item["NumberOfLogicalProcessors"]);
                cpu.OtherFamilyDescription = item["OtherFamilyDescription"] == null ? null : item["OtherFamilyDescription"].ToString();
                cpu.PartNumber = item["PartNumber"] == null ? null : item["PartNumber"].ToString();
                cpu.PNPDeviceID = item["PNPDeviceID"] == null ? null : item["PNPDeviceID"].ToString();
                //UInt16 powermanagementcapabilities[] = Convert.ToInt32(item["PowerManagementCapabilities[]"]);
                cpu.PowerManagementSupported = item["PowerManagementSupported"] == null ? false : (Boolean)item["PowerManagementSupported"];
                cpu.ProcessorId = item["ProcessorId"] == null ? null : item["ProcessorId"].ToString();
                cpu.ProcessorType = Convert.ToInt32(item["ProcessorType"]);
                cpu.Revision = Convert.ToInt32(item["Revision"]);
                cpu.Role = item["Role"] == null ? null : item["Role"].ToString();
                cpu.SecondLevelAddressTranslationExtensions = item["SecondLevelAddressTranslationExtensions"] == null ? false : (Boolean)item["SecondLevelAddressTranslationExtensions"];
                cpu.SerialNumber = item["SerialNumber"] == null ? null : item["SerialNumber"].ToString();
                cpu.SocketDesignation = item["SocketDesignation"] == null ? null : item["SocketDesignation"].ToString();
                cpu.Status = item["Status"] == null ? null : item["Status"].ToString();
                cpu.StatusInfo = Convert.ToInt32(item["StatusInfo"]);
                cpu.Stepping = item["Stepping"] == null ? null : item["Stepping"].ToString();
                cpu.SystemCreationClassName = item["SystemCreationClassName"] == null ? null : item["SystemCreationClassName"].ToString();
                cpu.SystemName = item["SystemName"] == null ? null : item["SystemName"].ToString();
                cpu.ThreadCount = Convert.ToInt32(item["ThreadCount"]);
                cpu.UniqueId = item["UniqueId"] == null ? null : item["UniqueId"].ToString();
                cpu.UpgradeMethod = Convert.ToInt32(item["UpgradeMethod"]);
                cpu.Version = item["Version"] == null ? null : item["Version"].ToString();
                cpu.VirtualizationFirmwareEnabled = item["VirtualizationFirmwareEnabled"] == null ? false : (Boolean)item["VirtualizationFirmwareEnabled"];
                cpu.VMMonitorModeExtensions = item["VMMonitorModeExtensions"] == null ? false : (Boolean)item["VMMonitorModeExtensions"];
                cpu.VoltageCaps = Convert.ToInt32(item["VoltageCaps"]);
                cpus.Add(cpu);
                seq++;
            }

            return cpus;
        }

        private List<WmiServerMemory> GetMems(ManagementScope scope, string TicketNo)
        {
            ManagementObjectSearcher searcher = GetObjectSearcher(objectQuery, scope);
            List<WmiServerMemory> mems = new List<WmiServerMemory>();
            int seq = 1;
            foreach (ManagementObject item in searcher.Get())
            {
                WmiServerMemory mem = new WmiServerMemory();
                mem.Seq = seq;
                mem.TicketNo = TicketNo;
                mem.MemAttribute = Convert.ToInt32(item["Attributes"]);
                mem.Capacity = Convert.ToInt64(item["Capacity"]);
                mem.Caption = Convert.ToString(item["Caption"]);
                mem.ConfiguredClockSpeed = Convert.ToInt32(item["ConfiguredClockSpeed"]);
                mem.ConfiguredVoltage = Convert.ToInt32(item["ConfiguredVoltage"]);
                mem.CreationClassName = Convert.ToString(item["CreationClassName"]);
                mem.DataWidth = Convert.ToInt32(item["DataWidth"]);
                mem.Description = Convert.ToString(item["Description"]);
                mem.DeviceLocator = Convert.ToString(item["DeviceLocator"]);
                mem.FormFactor = Convert.ToInt32(item["FormFactor"]);
                mem.HotSwappable = item["HotSwappable"] == null ? false : (Boolean)item["HotSwappable"];
                mem.InterleaveDataDepth = Convert.ToInt32(item["InterleaveDataDepth"]);
                mem.InterleavePosition = Convert.ToInt32(item["InterleavePosition"]);
                mem.Manufacturer = Convert.ToString(item["Manufacturer"]);
                mem.MaxVoltage = Convert.ToInt32(item["MaxVoltage"]);
                mem.MemoryType = Convert.ToInt32(item["MemoryType"]);
                mem.MinVoltage = Convert.ToInt32(item["MinVoltage"]);
                mem.Model = Convert.ToString(item["Model"]);
                mem.OtherIdentifyingInfo = Convert.ToString(item["OtherIdentifyingInfo"]);
                mem.PartNumber = Convert.ToString(item["PartNumber"]);
                mem.PositionInRow = Convert.ToInt32(item["PositionInRow"]);
                mem.PoweredOn = item["PoweredOn"] == null ? false : (Boolean)item["PoweredOn"];
                mem.Removable = item["Removable"] == null ? false : (Boolean)item["Removable"];
                mem.Replaceable = item["Replaceable"] == null ? false : (Boolean)item["Replaceable"];
                mem.SerialNumber = Convert.ToString(item["SerialNumber"]);
                mem.SKU = Convert.ToString(item["SKU"]);
                mem.SMBIOSMemoryType = Convert.ToInt32(item["SMBIOSMemoryType"]);
                mem.Speed = Convert.ToInt32(item["Speed"]);
                mem.Status = Convert.ToString(item["Status"]);
                mem.Tag = Convert.ToString(item["Tag"]);
                mem.TotalWidth = Convert.ToInt32(item["TotalWidth"]);
                mem.TypeDetail = Convert.ToInt32(item["TypeDetail"]);
                mem.Version = Convert.ToString(item["Version"]);
                mems.Add(mem);
                seq++;
            }

            return mems;
        }

        private List<WmiServerDisk> GetDisks(ManagementScope scope, string TicketNo)
        {
            ManagementObjectSearcher searcher = GetObjectSearcher(objectQuery, scope);
            List<WmiServerDisk> disks = new List<WmiServerDisk>();
            int seq = 1;
            foreach (ManagementObject item in searcher.Get())
            {
                WmiServerDisk disk = new WmiServerDisk();
                disk.Seq = seq;
                disk.TicketNo = TicketNo;
                disk.Availability = Convert.ToInt32(item["Availability"]);
                disk.BytesPerSector = Convert.ToInt32(item["BytesPerSector"]);
                disk.Caption = Convert.ToString(item["Caption"]);
                disk.CompressionMethod = Convert.ToString(item["CompressionMethod"]);
                disk.ConfigManagerErrorCode = Convert.ToInt32(item["ConfigManagerErrorCode"]);
                disk.ConfigManagerUserConfig = item["ConfigManagerUserConfig"] == null ? false : (Boolean)item["ConfigManagerUserConfig"];
                disk.CreationClassName = Convert.ToString(item["CreationClassName"]);
                disk.DefaultBlockSize = Convert.ToInt64(item["DefaultBlockSize"]);
                disk.Description = Convert.ToString(item["Description"]);
                disk.DeviceID = Convert.ToString(item["DeviceID"]);
                disk.ErrorCleared = item["ErrorCleared"] == null ? false : (Boolean)item["ErrorCleared"];
                disk.ErrorDescription = Convert.ToString(item["ErrorDescription"]);
                disk.ErrorMethodology = Convert.ToString(item["ErrorMethodology"]);
                disk.FirmwareRevision = Convert.ToString(item["FirmwareRevision"]);
                disk.Index = Convert.ToInt32(item["Index"]);
                disk.InterfaceType = Convert.ToString(item["InterfaceType"]);
                disk.LastErrorCode = Convert.ToInt32(item["LastErrorCode"]);
                disk.Manufacturer = Convert.ToString(item["Manufacturer"]);
                disk.MaxBlockSize = Convert.ToInt64(item["MaxBlockSize"]);
                disk.MaxMediaSize = Convert.ToInt64(item["MaxMediaSize"]);
                disk.MediaLoaded = item["MediaLoaded"] == null ? false : (Boolean)item["MediaLoaded"];
                disk.MediaType = Convert.ToString(item["MediaType"]);
                disk.MinBlockSize = Convert.ToInt64(item["MinBlockSize"]);
                disk.Model = Convert.ToString(item["Model"]);
                disk.Name = Convert.ToString(item["Name"]);
                disk.NeedsCleaning = item["NeedsCleaning"] == null ? false : (Boolean)item["NeedsCleaning"];
                disk.NumberOfMediaSupported = Convert.ToInt32(item["NumberOfMediaSupported"]);
                disk.Partitions = Convert.ToInt32(item["Partitions"]);
                disk.PNPDeviceID = Convert.ToString(item["PNPDeviceID"]);
                disk.PowerManagementSupported = item["PowerManagementSupported"] == null ? false : (Boolean)item["PowerManagementSupported"];
                disk.SCSIBus = Convert.ToInt32(item["SCSIBus"]);
                disk.SCSILogicalUnit = Convert.ToInt32(item["SCSILogicalUnit"]);
                disk.SCSIPort = Convert.ToInt32(item["SCSIPort"]);
                disk.SCSITargetId = Convert.ToInt32(item["SCSITargetId"]);
                disk.SectorsPerTrack = Convert.ToInt32(item["SectorsPerTrack"]);
                disk.SerialNumber = Convert.ToString(item["SerialNumber"]);
                disk.Signature = Convert.ToInt32(item["Signature"]);
                disk.Size = Convert.ToInt64(item["Size"]);
                disk.Status = Convert.ToString(item["Status"]);
                disk.StatusInfo = Convert.ToInt32(item["StatusInfo"]);
                disk.SystemCreationClassName = Convert.ToString(item["SystemCreationClassName"]);
                disk.SystemName = Convert.ToString(item["SystemName"]);
                disk.TotalCylinders = Convert.ToInt64(item["TotalCylinders"]);
                disk.TotalHeads = Convert.ToInt32(item["TotalHeads"]);
                disk.TotalSectors = Convert.ToInt64(item["TotalSectors"]);
                disk.TotalTracks = Convert.ToInt64(item["TotalTracks"]);
                disk.TracksPerCylinder = Convert.ToInt32(item["TracksPerCylinder"]);
                disks.Add(disk);
                seq++;
            }

            return disks;
        }

        private List<WmiServerLogicalDisk> GetLogicalDisks(ManagementScope scope, string TicketNo)
        {
            ManagementObjectSearcher searcher = GetObjectSearcher(objectQuery, scope);
            List<WmiServerLogicalDisk> logicaldisks = new List<WmiServerLogicalDisk>();
            int seq = 1;
            foreach (ManagementObject item in searcher.Get())
            {
                WmiServerLogicalDisk logicaldisk = new WmiServerLogicalDisk();
                logicaldisk.Seq = seq;
                logicaldisk.TicketNo = TicketNo;
                logicaldisk.Access = Convert.ToInt32(item["Access"]);
                logicaldisk.Availability = Convert.ToInt32(item["Availability"]);
                logicaldisk.BlockSize = Convert.ToInt64(item["BlockSize"]);
                logicaldisk.Caption = Convert.ToString(item["Caption"]);
                logicaldisk.Compressed = item["Compressed"] == null ? false : (Boolean)item["Compressed"];
                logicaldisk.ConfigManagerErrorCode = Convert.ToInt32(item["ConfigManagerErrorCode"]);
                logicaldisk.ConfigManagerUserConfig = item["ConfigManagerUserConfig"] == null ? false : (Boolean)item["ConfigManagerUserConfig"];
                logicaldisk.CreationClassName = Convert.ToString(item["CreationClassName"]);
                logicaldisk.Description = Convert.ToString(item["Description"]);
                logicaldisk.DeviceID = Convert.ToString(item["DeviceID"]);
                logicaldisk.DriveType = Convert.ToInt32(item["DriveType"]);
                logicaldisk.ErrorCleared = item["ErrorCleared"] == null ? false : (Boolean)item["ErrorCleared"];
                logicaldisk.ErrorDescription = Convert.ToString(item["ErrorDescription"]);
                logicaldisk.ErrorMethodology = Convert.ToString(item["ErrorMethodology"]);
                logicaldisk.FileSystem = Convert.ToString(item["FileSystem"]);
                logicaldisk.FreeSpace = Convert.ToInt64(item["FreeSpace"]);
                logicaldisk.LastErrorCode = Convert.ToInt32(item["LastErrorCode"]);
                logicaldisk.MaximumComponentLength = Convert.ToInt32(item["MaximumComponentLength"]);
                logicaldisk.MediaType = Convert.ToInt32(item["MediaType"]);
                logicaldisk.Name = Convert.ToString(item["Name"]);
                logicaldisk.NumberOfBlocks = Convert.ToInt32(item["NumberOfBlocks"]);
                logicaldisk.PNPDeviceID = Convert.ToString(item["PNPDeviceID"]);
                logicaldisk.PowerManagementSupported = item["PowerManagementSupported"] == null ? false : (Boolean)item["PowerManagementSupported"];
                logicaldisk.ProviderName = Convert.ToString(item["ProviderName"]);
                logicaldisk.Purpose = Convert.ToString(item["Purpose"]);
                logicaldisk.QuotasDisabled = item["QuotasDisabled"] == null ? false : (Boolean)item["QuotasDisabled"];
                logicaldisk.QuotasIncomplete = item["QuotasIncomplete"] == null ? false : (Boolean)item["QuotasIncomplete"];
                logicaldisk.QuotasRebuilding= item["QuotasRebuilding"] == null ? false : (Boolean)item["QuotasRebuilding"];
                logicaldisk.Size = Convert.ToInt64(item["Size"]);
                logicaldisk.Status = Convert.ToString(item["Status"]);
                logicaldisk.StatusInfo = Convert.ToInt32(item["StatusInfo"]);
                logicaldisk.SupportsDiskQuotas = item["SupportsDiskQuotas"] == null ? false : (Boolean)item["SupportsDiskQuotas"];
                logicaldisk.SupportsFileBasedCompression = item["SupportsFileBasedCompression"] == null ? false : (Boolean)item["SupportsFileBasedCompression"];
                logicaldisk.SystemCreationClassName = Convert.ToString(item["SystemCreationClassName"]);
                logicaldisk.SystemName = Convert.ToString(item["SystemName"]);
                logicaldisk.VolumeDirty = item["VolumeDirty"] == null ? false : (Boolean)item["VolumeDirty"];
                logicaldisk.VolumeName = Convert.ToString(item["VolumeName"]);
                logicaldisk.VolumeSerialNumber = Convert.ToString(item["VolumeSerialNumber"]);
                logicaldisks.Add(logicaldisk);
                seq++;
            }

            return logicaldisks;
        }

        private ManagementObjectSearcher GetObjectSearcher(ObjectQuery query, ManagementScope scope)
        {
            return new ManagementObjectSearcher(scope, query);
        }
        #endregion
    }
}
