using AllinOne.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Repository
{
    public class WMIRepository
    {
        private AllinOneModel db = new AllinOneModel();
        public List<WmiServerList> GetAll()
        {
            return db.WmiServerList.OrderBy(f => f.CreateTime).ToList();
        }

        public WmiServerList GetById(string sguid)
        {
            return db.WmiServerList.Where(f=>f.SGUID == sguid).FirstOrDefault();
        }
    }
}
