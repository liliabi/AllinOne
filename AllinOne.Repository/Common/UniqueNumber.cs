using AllinOne.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Repository.Common
{
    public class UniqueNumber
    {
        private AllinOneModel db = new AllinOneModel();
        public long GetYourSerialNumberByDate(string _project)
        {
            ParaCheck(_project);
            SqlParameter Project = new SqlParameter("@Project", _project);
            SqlParameter YourSerialNumber = new SqlParameter("@YourSerialNumber", System.Data.SqlDbType.BigInt);
            YourSerialNumber.Direction = System.Data.ParameterDirection.Output;

            db.Database.ExecuteSqlCommand("exec [GetNextSerialNumberD] @Project,@YourSerialNumber out", Project, YourSerialNumber);
            long i = Convert.ToInt64(YourSerialNumber.Value);
            return i;
        }

        public long GetYourSerialNumber(string _project)
        {
            ParaCheck(_project);
            SqlParameter Project = new SqlParameter("@Project", _project);
            SqlParameter YourSerialNumber = new SqlParameter("@YourSerialNumber", System.Data.SqlDbType.BigInt);
            YourSerialNumber.Direction = System.Data.ParameterDirection.Output;

            db.Database.ExecuteSqlCommand("exec [GetNextSerialNumber] @Project,@YourSerialNumber out", Project, YourSerialNumber);
            long i = Convert.ToInt64(YourSerialNumber.Value);
            return i;
        }

        public static void ParaCheck(string _project)
        {
            if (_project.Trim().Length < 2 || _project.Trim().Length > 50)
            {
                throw new Exception("project长度范围应为2~50");
            }
        }
    }
}
