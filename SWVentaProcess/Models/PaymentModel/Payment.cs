using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Models.PaymentModel
{
    class Payment
    {
        public string DocDate { get; set; }
        public string CardCode { get; set; }
        public string DocCurrency { get; set; }
       // public double DocRate { get; set; }
        //public double CashSum { get; set; }
        public string DocType { get; set; }
        public string U_SYP_MPPG { get; set; }
        public string U_SYP_TPOOPERI { get; set; }
        public List<PaymentInvoice> PaymentInvoices { get; set; }
        public List<PaymentCreditCard> PaymentCreditCards { get; set; }
    }
}
