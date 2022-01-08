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
            string strQueryCpu = "select * from Win32_Processor";
            objectQuery = new ObjectQuery(strQueryCpu);
            try
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

                ManagementObjectSearcher searcherCpu = GetObjectSearcher(objectQuery, scope);
                List<WmiServerCpu> cpus = new List<WmiServerCpu>();
                int seq = 1;
                foreach (ManagementObject item in searcherCpu.Get())
                {
                    WmiServerCpu cpu = new WmiServerCpu();
                    cpu.Seq = seq;
                    cpu.TicketNo = wmiServerMain.TicketNo;
                    cpu.AddressWidth = Convert.ToUInt16(item["AddressWidth"]);
                    cpu.Architecture = Convert.ToUInt16(item["Architecture"]);
                    cpu.AssetTag = item["AssetTag"].ToString();
                    cpu.Availability = Convert.ToUInt16(item["Availability"]);
                    cpu.Caption = item["Caption"].ToString();
                    cpu.Characteristics = Convert.ToInt32(item["Characteristics"]);
                    cpu.ConfigManagerErrorCode = Convert.ToInt32(item["ConfigManagerErrorCode"]);
                    cpu.ConfigManagerUserConfig = item["ConfigManagerUserConfig"] == null ? false : (Boolean)item["ConfigManagerUserConfig"];
                    cpu.CpuStatus = Convert.ToUInt16(item["CpuStatus"]);
                    cpu.CreationClassName = item["CreationClassName"].ToString();
                    cpu.CurrentClockSpeed = Convert.ToInt32(item["CurrentClockSpeed"]);
                    cpu.CurrentVoltage = Convert.ToUInt16(item["CurrentVoltage"]);
                    cpu.DataWidth = Convert.ToUInt16(item["DataWidth"]);
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
                    cpu.LoadPercentage = Convert.ToUInt16(item["LoadPercentage"]);
                    cpu.Manufacturer = item["Manufacturer"] == null ? null : item["Manufacturer"].ToString();
                    cpu.MaxClockSpeed = Convert.ToInt32(item["MaxClockSpeed"]);
                    cpu.Name = item["Name"] == null ? null : item["Name"].ToString();
                    cpu.NumberOfCores = Convert.ToInt32(item["NumberOfCores"]);
                    cpu.NumberOfEnabledCore = Convert.ToInt32(item["NumberOfEnabledCore"]);
                    cpu.NumberOfLogicalProcessors = Convert.ToInt32(item["NumberOfLogicalProcessors"]);
                    cpu.OtherFamilyDescription = item["OtherFamilyDescription"] == null ? null : item["OtherFamilyDescription"].ToString();
                    cpu.PartNumber = item["PartNumber"] == null ? null : item["PartNumber"].ToString();
                    cpu.PNPDeviceID = item["PNPDeviceID"] == null ? null : item["PNPDeviceID"].ToString();
                    //UInt16 powermanagementcapabilities[] = Convert.ToUInt16(item["PowerManagementCapabilities[]"]);
                    cpu.PowerManagementSupported = item["PowerManagementSupported"] == null ? false : (Boolean)item["PowerManagementSupported"];
                    cpu.ProcessorId = item["ProcessorId"] == null ? null : item["ProcessorId"].ToString();
                    cpu.ProcessorType = Convert.ToUInt16(item["ProcessorType"]);
                    cpu.Revision = Convert.ToUInt16(item["Revision"]);
                    cpu.Role = item["Role"] == null ? null : item["Role"].ToString();
                    cpu.SecondLevelAddressTranslationExtensions = item["SecondLevelAddressTranslationExtensions"] == null ? false : (Boolean)item["SecondLevelAddressTranslationExtensions"];
                    cpu.SerialNumber = item["SerialNumber"] == null ? null : item["SerialNumber"].ToString();
                    cpu.SocketDesignation = item["SocketDesignation"] == null ? null : item["SocketDesignation"].ToString();
                    cpu.Status = item["Status"] == null ? null : item["Status"].ToString();
                    cpu.StatusInfo = Convert.ToUInt16(item["StatusInfo"]);
                    cpu.Stepping = item["Stepping"] == null ? null : item["Stepping"].ToString();
                    cpu.SystemCreationClassName = item["SystemCreationClassName"] == null ? null : item["SystemCreationClassName"].ToString();
                    cpu.SystemName = item["SystemName"] == null ? null : item["SystemName"].ToString();
                    cpu.ThreadCount = Convert.ToInt32(item["ThreadCount"]);
                    cpu.UniqueId = item["UniqueId"] == null ? null : item["UniqueId"].ToString();
                    cpu.UpgradeMethod = Convert.ToUInt16(item["UpgradeMethod"]);
                    cpu.Version = item["Version"] == null ? null : item["Version"].ToString();
                    cpu.VirtualizationFirmwareEnabled = item["VirtualizationFirmwareEnabled"] == null ? false : (Boolean)item["VirtualizationFirmwareEnabled"];
                    cpu.VMMonitorModeExtensions = item["VMMonitorModeExtensions"] == null ? false : (Boolean)item["VMMonitorModeExtensions"];
                    cpu.VoltageCaps = Convert.ToInt32(item["VoltageCaps"]);
                    cpus.Add(cpu);
                    seq++;
                }
                if (wmiRepository.InsertServiceInfo(wmiServerMain, cpus))
                {
                    return new RESTfulResult { StatusCode = 200, Succeeded = true, Data = wmi, Message = wmi.ServerIP + " 获取成功！" };
                }
                return new RESTfulResult { StatusCode = 404, Succeeded = false, Data = "", Message = "数据库插入异常！" };
            }
            catch (Exception ex)
            {
                return new RESTfulResult { StatusCode = 404, Succeeded = false, Data = "", Message = ex.Message };
            }

        }
        private ManagementObjectSearcher GetObjectSearcher(ObjectQuery query, ManagementScope scope)
        {
            return new ManagementObjectSearcher(scope, query);
        }

        private void GetDisk()
        {

        }
        private void GetNetwork()
        {

        }
        #endregion
    }
}
