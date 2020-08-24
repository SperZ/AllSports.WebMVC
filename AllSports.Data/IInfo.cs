using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Data
{
    interface IInfo
    {
        DateTime DateSigned { get; set; }
        string College { get; set; }
    }
}
