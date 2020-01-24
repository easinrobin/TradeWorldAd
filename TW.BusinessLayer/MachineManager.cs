using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.DataLayerSql;
using TW.Models;

namespace TW.BusinessLayer
{
    public class MachineManager
    {
        public static List<OurMachine> GetAllMachines()
        {
            SqlMachinesProvider provider = new SqlMachinesProvider();
            return provider.GetAllMachines();
        }

        public static OurMachine GetMachineById(long Id)
        {
            SqlMachinesProvider provider = new SqlMachinesProvider();
            return provider.GetMachineById(Id);
        }

        public static bool UpdateMachine(OurMachine machine)
        {
            SqlMachinesProvider provider = new SqlMachinesProvider();
            return provider.UpdateMachine(machine);
        }

        public static long InsertMachine(OurMachine machine)
        {
            SqlMachinesProvider provider = new SqlMachinesProvider();
            return provider.InsertMachine(machine);
        }

        public static bool DeleteMachine(long Id)
        {
            SqlMachinesProvider provider = new SqlMachinesProvider();
            return provider.DeleteMachine(Id);
        }
    }
}
