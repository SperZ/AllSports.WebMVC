using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AllSports.Data
{
    interface IPhoto
    {
        byte[] Contents { get; set; }
        HttpPostedFileBase File { get; set; }
    }
}
