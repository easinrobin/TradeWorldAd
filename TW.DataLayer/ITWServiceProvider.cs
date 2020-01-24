using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.Models;

namespace TW.DataLayer
{
    public interface ITWServiceProvider
    {
        List<OurService> GetAllService();
        OurService GetServiceById(long Id);
        long InsertService(OurService service);
        bool UpdateService(OurService services);
        bool DeleteService(long Id);
    }
}
