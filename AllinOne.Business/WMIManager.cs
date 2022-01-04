using AllinOne.Entity;
using AllinOne.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Business
{
    public class WMIManager
    {
        private WMIRepository wmiRepository = new WMIRepository();
        public List<WmiServerList> GetAll()
        { 
            return wmiRepository.GetAll();
        }
    }
}
