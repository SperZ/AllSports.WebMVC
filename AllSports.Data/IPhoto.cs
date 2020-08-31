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
        string FileName { get; set; }
        byte[] FileContent { get; set; }
        HttpPostedFileBase File { get; set; }
    }
}
