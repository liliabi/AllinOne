using AllinOne.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace AllinOne.Repository
{
    public class WinProviderRepository
    {
        private AllinOneModel db = new AllinOneModel();

        public bool RepoInsertProviderInfo(WinProviderList winProviderList)
        {
            db.WinProviderList.Add(winProviderList);
            int i = db.SaveChanges();
            return i > 0 ? true : false;
        }

        public bool RepoUpdateProviderInfo(WinProviderList winProviderList)
        {
            try
            {
                db.Entry<WinProviderList>(winProviderList).State = EntityState.Modified;
                int i = db.SaveChanges();
                return i > 0 ? true : false;
            }         
            catch (DbEntityValidationException dbex)
            {
                //EntityValidationErrors[0].ValidationErrors[0].ErrorMessage 查看实体异常
                throw dbex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RepoDeleteProviderInfo(int? id)
        {
            var Provider = db.WinProviderList.Find(id);
            db.WinProviderList.Remove(Provider);
            int i = db.SaveChanges();
            return i > 0 ? true : false;
        }

        public WinProviderList RepoGetOneProviderInfo(int? id)
        {
            return db.WinProviderList.Find(id);
        }

        public List<WinProviderList> RepoGetAllProviderInfo()
        {
            return db.WinProviderList.ToList();
        }

        public bool RepoDeleteStructuresInfo(int id)
        {
            try
            {
                var del = db.WinProviderStructure.Where(f => f.ID == id);
                del.ToList().ForEach(t => db.Entry(t).State = System.Data.Entity.EntityState.Deleted);
                int i = db.SaveChanges();
                return i > 0 ? true : false;
            }
            catch (DbEntityValidationException dbex)
            {
                //EntityValidationErrors[0].ValidationErrors[0].ErrorMessage 查看实体异常
                throw dbex;
            }

        }


        public bool RepoInsertStructuresInfo(List<WinProviderStructure> WinProviderStructures)
        {
            try
            {
                foreach (var item in WinProviderStructures)
                {
                    db.WinProviderStructure.Add(item);
                }
                int i = db.SaveChanges();
                return i > 0 ? true : false;
            }
            catch (DbEntityValidationException dbex)
            {
                //EntityValidationErrors[0].ValidationErrors[0].ErrorMessage 查看实体异常
                throw dbex;
            }
        }

        public void RepoUpdateReload(int id)
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
