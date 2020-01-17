using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TW.Models
{
    public class AdminViewModel
    {
        public Banner Banner { get; set; }
        public AboutUs AboutUs { get; set; }
        public OurClient Clients { get; set; }
        public List<OurClient> ClientList { get; set; }
        public CompanySetting CompanySetting { get; set; }
        public OurMachine Machines { get; set; }
        public List<OurMachine> MachineList { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Image Required")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Image Required")]
        public HttpPostedFileBase File { get; set; }
    }
}
