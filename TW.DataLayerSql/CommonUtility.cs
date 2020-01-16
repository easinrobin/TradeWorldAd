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

        // Banner
        public static string GetBannerById = "sp_GetBannerDetails";
        public static string InsertBanner = "sp_InsertBanner";
        public static string UpdateBanner = "sp_UpdateBanner";
        public static string GetAllBanners = "sp_GetBanner";
        public static string DeleteBanner = "sp_DeleteBanner";
    }
}