using AllinOne.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Business.Common
{
    public class GetOrderNumber
    {
        private int padleft = 10;
        public string GetWMINumber(string _Project)
        {
            UniqueNumber unique = new UniqueNumber();
            string wmi = "WMI" + unique.GetYourSerialNumber(_Project).ToString().PadLeft(padleft);
            return wmi;
        }
    }
}
