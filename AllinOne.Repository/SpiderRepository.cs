using AllinOne.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace AllinOne.Repository
{
    public class SpiderRepository
    {
        private AllinOneModel db = new AllinOneModel();
        public bool SaveServiceInfo(List<WinProviderStructure> WinProviderStructures)
        {
            try
            {
                foreach (var item in WinProviderStructures)
                {
                    db.WinProviderStructure.Add(item);
                }
                int i = db.SaveChanges();
                //
                return i > 0 ? true : false;
            }
            catch (DbEntityValidationException dbex)
            {
                //EntityValidationErrors[0].ValidationErrors[0].ErrorMessage 查看实体异常
                throw dbex;
            }

        }

        public bool DeleteServiceInfo(int id)
        {
            try
            {
                var del = db.WinProviderStructure.Where(f => f.ID == id);
                del.ToList().ForEach(t => db.Entry(t).State = System.Data.Entity.EntityState.Deleted);
                int i = db.SaveChanges();
                //
                return i > 0 ? true : false;
            }
            catch (DbEntityValidationException dbex)
            {
                //EntityValidationErrors[0].ValidationErrors[0].ErrorMessage 查看实体异常
                throw dbex;
            }

        }

        public void UpdateReload(int id)
        {
            var WinProviderList = db.WinProviderList.Where(f => f.ID == id).FirstOrDefault();
            if (WinProviderList != null)
            {
                WinProviderList.FieldsReLoad = "N";
                
            }
            
            db.SaveChanges();
        }
    }
}
