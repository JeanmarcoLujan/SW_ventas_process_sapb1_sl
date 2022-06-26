using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Models.PaymentModel
{
    class PaymentCreditCard
    {
        public int CreditCard { get; set; }
        public string CreditAcct { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardValidUntil { get; set; }
        public string VoucherNum { get; set; }
        public int PaymentMethodCode { get; set; }
        public double CreditSum { get; set; }
        public string CreditCur { get; set; }
        public double CreditRate { get; set; }
        public int NumOfCreditPayments { get; set; }
        public string CreditType { get; set; }
    }
}
