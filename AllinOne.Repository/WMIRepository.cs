using AllinOne.Entity;
using System.Collections.Generic;
using System.Linq;

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
            return db.WmiServerList.Where(f => f.SGUID == sguid).FirstOrDefault();
        }

        public bool InsertServiceInfo(WmiServerMain wmiServerMain, List<WmiServerCpu> listCpus)
        {
            db.WmiServerMain.Add(wmiServerMain);
            foreach (var cpu in listCpus)
            {
                db.WmiServerCpu.Add(cpu);
            }
            int i = db.SaveChanges();

            return i > 0 ? true : false;
        }
    }
}
