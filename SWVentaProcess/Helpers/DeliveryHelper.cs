using SWVentaProcess.Models;
using SWVentaProcess.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Helpers
{
    class DeliveryHelper
    {
        public static string DeliveryGenerateTrama(Order order)
        {
            Document delivery = new Document();
            delivery.CardCode = order.CardCode;
            delivery.DocDate = order.DocDate;
            delivery.DocDueDate = order.DocDueDate;
            delivery.TaxDate = order.TaxDate;
            delivery.DocCurrency = order.DocCurrency;
            delivery.NumAtCard = "09-T001-00006845";
            delivery.U_SYP_MDTD = "09";
            delivery.U_SYP_MDSD = "T001";
            delivery.U_SYP_MDCD = "00006845";
            delivery.U_SYP_TVENTA = ConfigurationManager.AppSettings["U_SYP_TVENTA"].ToString();
            delivery.U_SYP_MDMT = ConfigurationManager.AppSettings["U_SYP_MDMT"].ToString();
            delivery.DocumentLines = DeliveryGenerateTramaDetail(order.DocumentLines);

            return "sdff";
        }



        public static List<DocumentDetail> DeliveryGenerateTramaDetail(List<OrderDetail> order)
        {
            List<DocumentDetail> documentDetails = new List<DocumentDetail>();

            Document delivery = new Document();
            delivery.CardCode = order.CardCode;
            delivery.DocDate = order.DocDate;
            delivery.DocDueDate = order.DocDueDate;
            delivery.TaxDate = order.TaxDate;
            delivery.DocCurrency = order.DocCurrency;
            delivery.NumAtCard = "09-T001-00006845";
            delivery.U_SYP_MDTD = "09";
            delivery.U_SYP_MDSD = "T001";
            delivery.U_SYP_MDCD = "00006845";
            delivery.U_SYP_TVENTA = ConfigurationManager.AppSettings["U_SYP_TVENTA"].ToString();
            delivery.U_SYP_MDMT = ConfigurationManager.AppSettings["U_SYP_MDMT"].ToString();

            return documentDetails;
        }
    }
}
