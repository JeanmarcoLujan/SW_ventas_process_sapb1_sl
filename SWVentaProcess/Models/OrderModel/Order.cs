using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Models.OrderModel
{
    public class OrderDTO
    {
   
        public string OdataMetadata { get; set; }
        public virtual List<Order> value { get; set; }
    }
    public class Order
    {
        public string DocEntry { get; set; }
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string TaxDate { get; set; }
        public string CardCode { get; set; }
        public string DocCurrency { get; set; }
        public string NumAtCard { get; set; }
        public string U_SYP_MDTD { get; set; }
        public string U_SYP_MDSD { get; set; }
        public string U_SYP_MDCD { get; set; }
        public string U_SYP_TVENTA { get; set; }
        public string U_SYP_MDMT { get; set; }
        public virtual List<OrderDetail> DocumentLines { get; set; }
    }
}
