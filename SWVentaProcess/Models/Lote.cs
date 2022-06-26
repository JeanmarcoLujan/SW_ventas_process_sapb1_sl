using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Models
{
    class Lote
    {
        public string FechaEmision { get; set; }
        public string ItemCode { get; set; }
        public string WhsCode { get; set; }
        public string BatchNum { get; set; }
        public double Stock { get; set; }
    }
}
