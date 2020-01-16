using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.DataLayerSql
{
    public class CommonUtility
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
    }

    public static class StoreProcedure
    {
        // Users
        public static string GetUserByUsernamePassword = "sp_user_getuserbyusernamenpassword";
    }
}