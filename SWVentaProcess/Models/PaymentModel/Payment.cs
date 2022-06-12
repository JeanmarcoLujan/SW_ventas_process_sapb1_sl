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
        public string CashAccount { get; set; }
        public string DocCurrency { get; set; }
        public double DocRate { get; set; }
        public double CashSum { get; set; }
        public string DocType { get; set; }
        public string U_MAR_MEPA { get; set; }
        public string U_MAR_METJ { get; set; }
        public string U_SYP_MPPG { get; set; }
        public List<PaymentInvoice> PaymentInvoices { get; set; }
    }
}
