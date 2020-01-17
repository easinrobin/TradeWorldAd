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

        // About Us
        public static string GetAboutDetails = "sp_GetAboutUDetails";
        public static string UpdateAbout = "sp_UpdateAboutU";

        // Clients
        public static string GetAllClients = "sp_GetOurClient";
        public static string GetClientById = "sp_GetOurClientDetails";
        public static string InsertClient = "sp_InsertOurClient";
        public static string UpdateClient = "sp_UpdateOurClient";
        public static string DeleteClient = "sp_DeleteOurClient";

        // Company Setting
        public static string GetCompanySetting = "sp_GetCompanySettingDetails";
        public static string UpdateCompanySettings = "sp_UpdateCompanySetting";

        // Machines
        public static string GetAllMachines = "sp_GetOurMachine";
        public static string GetMachineById = "sp_GetOurMachineDetails";
        public static string InsertMachine = "sp_InsertOurMachine";
        public static string UpdateMachine = "sp_UpdateOurMachine";
        public static string DeleteMachine = "sp_DeleteOurMachine";
    }
}