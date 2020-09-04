using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AllSports.Data
{
    interface IPhoto
    {
        byte[] Contents { get; set; }
        [NotMapped]
        HttpPostedFileBase File { get; set; }
    }
}
