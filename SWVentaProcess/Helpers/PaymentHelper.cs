using Newtonsoft.Json;
using SWVentaProcess.Models;
using SWVentaProcess.Models.OrderModel;
using SWVentaProcess.Models.PaymentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Helpers
{
    class PaymentHelper
    {
        public static string PaymentGenerateTrama(Order order, Response responseInvoice)
        {
            Payment payment = new Payment();

            payment.DocDate = order.DocDate;
            payment.CardCode = order.CardCode;
            payment.DocCurrency = order.DocCurrency;
            payment.DocType = "rCustomer";
            payment.U_SYP_MPPG = "006";
            payment.U_SYP_TPOOPERI = "01";

            List<PaymentInvoice> paymentInvoices = new List<PaymentInvoice>();
            PaymentInvoice paymentInvoice = new PaymentInvoice();
            paymentInvoice.DocEntry = int.Parse(responseInvoice.DocEntry);
            if (responseInvoice.DocCurrency == "S/")
            {
                paymentInvoice.SumApplied = double.Parse(responseInvoice.DocTotal.ToString());
                paymentInvoice.AppliedFC = 0.0;
            }
            else
            {
                paymentInvoice.SumApplied = 0.0;
                paymentInvoice.AppliedFC = double.Parse(responseInvoice.DocTotal.ToString());
            }
            //paymentInvoice.AppliedFC = 0.0;
            paymentInvoice.InvoiceType = "it_Invoice";
            paymentInvoice.InstallmentId = 1;

            paymentInvoices.Add(paymentInvoice);
            payment.PaymentInvoices = paymentInvoices;


            List<PaymentCreditCard> paymentCreditCards = new List<PaymentCreditCard>();
            PaymentCreditCard paymentCreditCard = new PaymentCreditCard();
            paymentCreditCard.CreditCard = 1;
            paymentCreditCard.CreditAcct = ConfigurationManager.AppSettings["CreditAcct"].ToString();
            paymentCreditCard.CardValidUntil = ConfigurationManager.AppSettings["CardValidUntil"].ToString();
            paymentCreditCard.CreditCardNumber = ConfigurationManager.AppSettings["CreditCardNumber"].ToString();
            paymentCreditCard.VoucherNum = ConfigurationManager.AppSettings["VoucherNum"].ToString();
            paymentCreditCard.PaymentMethodCode = 1;
            paymentCreditCard.CreditSum = responseInvoice.DocTotal;
            paymentCreditCard.CreditCur = responseInvoice.DocCurrency;
            paymentCreditCard.CreditRate = responseInvoice.DocRate == null ? 0: double.Parse(responseInvoice.DocRate);
            paymentCreditCard.NumOfCreditPayments = 1;
            paymentCreditCard.CreditType = "cr_Regular";

            paymentCreditCards.Add(paymentCreditCard);
            payment.PaymentCreditCards = paymentCreditCards;


            return JsonConvert.SerializeObject(payment);
        }
    }
}
