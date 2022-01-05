using AllinOne.Business.Common;
using AllinOne.Entity;
using AllinOne.Entity.ViewModel;
using AllinOne.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Business
{
    public class WMIManager
    {
        private WMIRepository wmiRepository = new WMIRepository();
        private GetOrderNumber getOrderNumber = new GetOrderNumber();
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
        public void GetCpu()
        {

        }

        public void GetDisk()
        {

        }
        public void GetNetwork()
        {

        }
        #endregion
    }
}
