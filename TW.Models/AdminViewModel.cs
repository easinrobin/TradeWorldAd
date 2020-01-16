using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TW.Models
{
    public class AdminViewModel
    {
        public Banner Banner { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Image Required")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
