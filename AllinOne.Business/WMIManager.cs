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
                ManagementObjectSearcher searcherCpu = GetObjectSearcher(objectQuery, scope);

                foreach (ManagementObject item in searcherCpu.Get())
                {
                    UInt16 addresswidth = Convert.ToUInt16(item["AddressWidth"]);
                    UInt16 architecture = Convert.ToUInt16(item["Architecture"]);
                    string assettag = item["AssetTag"].ToString();
                    UInt16 availability = Convert.ToUInt16(item["Availability"]);
                    string caption = item["Caption"].ToString();
                    UInt32 characteristics = Convert.ToUInt32(item["Characteristics"]);
                    UInt32 configmanagererrorcode = Convert.ToUInt32(item["ConfigManagerErrorCode"]);
                    Boolean configmanageruserconfig = item["ConfigManagerUserConfig"]==null?false: (Boolean)item["ConfigManagerUserConfig"];
                    UInt16 cpustatus = Convert.ToUInt16(item["CpuStatus"]);
                    string creationclassname = item["CreationClassName"].ToString();
                    UInt32 currentclockspeed = Convert.ToUInt32(item["CurrentClockSpeed"]);
                    UInt16 currentvoltage = Convert.ToUInt16(item["CurrentVoltage"]);
                    UInt16 datawidth = Convert.ToUInt16(item["DataWidth"]);
                    string description = item["Description"].ToString();
                    string deviceid = item["DeviceID"].ToString();
                    Boolean errorcleared = item["ErrorCleared"] == null ? false : (Boolean)item["ErrorCleared"];
                    string errordescription = item["ErrorDescription"] == null ? null : item["ErrorDescription"].ToString();
                    UInt32 extclock = Convert.ToUInt32(item["ExtClock"]);
                    UInt16 family = Convert.ToUInt16(item["Family"]);
                    //DateTime? installdate = item["InstallDate"] == null ? null : Convert.ToDateTime(item["InstallDate"]);
                    UInt32 l2cachesize = Convert.ToUInt32(item["L2CacheSize"]);
                    UInt32 l2cachespeed = Convert.ToUInt32(item["L2CacheSpeed"]);
                    UInt32 l3cachesize = Convert.ToUInt32(item["L3CacheSize"]);
                    UInt32 l3cachespeed = Convert.ToUInt32(item["L3CacheSpeed"]);
                    UInt32 lasterrorcode = Convert.ToUInt32(item["LastErrorCode"]);
                    UInt16 level = Convert.ToUInt16(item["Level"]);
                    UInt16 loadpercentage = Convert.ToUInt16(item["LoadPercentage"]);
                    string manufacturer = item["Manufacturer"] == null ? null : item["Manufacturer"].ToString();
                    UInt32 maxclockspeed = Convert.ToUInt32(item["MaxClockSpeed"]);
                    string name = item["Name"] == null ? null : item["Name"].ToString();
                    UInt32 numberofcores = Convert.ToUInt32(item["NumberOfCores"]);
                    UInt32 numberofenabledcore = Convert.ToUInt32(item["NumberOfEnabledCore"]);
                    UInt32 numberoflogicalprocessors = Convert.ToUInt32(item["NumberOfLogicalProcessors"]);
                    string otherfamilydescription = item["OtherFamilyDescription"] == null ? null : item["OtherFamilyDescription"].ToString();
                    string partnumber = item["PartNumber"] == null ? null : item["PartNumber"].ToString();
                    string pnpdeviceid = item["PNPDeviceID"] == null ? null : item["PNPDeviceID"].ToString();
                    //UInt16 powermanagementcapabilities[] = Convert.ToUInt16(item["PowerManagementCapabilities[]"]);
                    Boolean powermanagementsupported = item["PowerManagementSupported"] == null ? false : (Boolean)item["PowerManagementSupported"];
                    string processorid = item["ProcessorId"] == null ? null : item["ProcessorId"].ToString();
                    UInt16 processortype = Convert.ToUInt16(item["ProcessorType"]);
                    UInt16 revision = Convert.ToUInt16(item["Revision"]);
                    string role = item["Role"] == null ? null : item["Role"].ToString();
                    Boolean secondleveladdresstranslationextensions = item["SecondLevelAddressTranslationExtensions"] == null ? false : (Boolean)item["SecondLevelAddressTranslationExtensions"];
                    string serialnumber = item["SerialNumber"] == null ? null : item["SerialNumber"].ToString();
                    string socketdesignation = item["SocketDesignation"] == null ? null : item["SocketDesignation"].ToString();
                    string status = item["Status"] == null ? null : item["Status"].ToString();
                    UInt16 statusinfo = Convert.ToUInt16(item["StatusInfo"]);
                    string stepping = item["Stepping"] == null ? null : item["Stepping"].ToString();
                    string systemcreationclassname = item["SystemCreationClassName"] == null ? null : item["SystemCreationClassName"].ToString();
                    string systemname = item["SystemName"] == null ? null : item["SystemName"].ToString();
                    UInt32 threadcount = Convert.ToUInt32(item["ThreadCount"]);
                    string uniqueid = item["UniqueId"] == null ? null : item["UniqueId"].ToString();
                    UInt16 upgrademethod = Convert.ToUInt16(item["UpgradeMethod"]);
                    string version = item["Version"] == null ? null : item["Version"].ToString();
                    Boolean virtualizationfirmwareenabled = item["VirtualizationFirmwareEnabled"] == null ? false : (Boolean)item["VirtualizationFirmwareEnabled"];
                    Boolean vmmonitormodeextensions = item["VMMonitorModeExtensions"] == null ? false : (Boolean)item["VMMonitorModeExtensions"];
                    UInt32 voltagecaps = Convert.ToUInt32(item["VoltageCaps"]);

                }
                return new RESTfulResult { StatusCode = 200, Succeeded = true, Data = strQueryCpu, Message = "" };
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
