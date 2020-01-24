using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.Models;

namespace TW.DataLayer
{
    public interface IMachineProvider
    {
        List<OurMachine> GetAllMachines();
        OurMachine GetMachineById(long Id);
        long InsertMachine(OurMachine machines);
        bool UpdateMachine(OurMachine machines);
        bool DeleteMachine(long Id);
    }
}
