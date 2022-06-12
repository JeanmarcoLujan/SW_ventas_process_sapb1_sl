using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Models
{
    class Response
    {
        public string DocEntry { get; set; }
        public double DocTotal { get; set; }
        public bool Registered { get; set; }
        public string Message { get; set; }
    }
}
