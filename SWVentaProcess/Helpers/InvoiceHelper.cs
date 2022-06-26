using Newtonsoft.Json;
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
    class InvoiceHelper
    {
        public static string InvoiceGenerateTrama(Order order, int docEntryDelivery)
        {
            Document invoice = new Document();
            invoice.CardCode = order.CardCode;
            invoice.DocDate = order.DocDate;
            invoice.DocDueDate = order.DocDueDate;
            invoice.TaxDate = order.TaxDate;
            invoice.DocCurrency = order.DocCurrency;
            invoice.NumAtCard = "09-T001-00006845";
            invoice.U_SYP_MDTD = "09";
            invoice.U_SYP_MDSD = "T001";
            invoice.U_SYP_MDCD = "00006845";
            invoice.U_SYP_TVENTA = ConfigurationManager.AppSettings["U_SYP_TVENTA"].ToString();
            invoice.U_SYP_MDMT = ConfigurationManager.AppSettings["U_SYP_MDMT"].ToString();
            invoice.U_SYP_MDCT = ConfigurationManager.AppSettings["U_SYP_MDCT"].ToString();
            invoice.U_SYP_MDRT = ConfigurationManager.AppSettings["U_SYP_MDRT"].ToString();
            invoice.U_SYP_MDNT = ConfigurationManager.AppSettings["U_SYP_MDNT"].ToString();
            invoice.U_SYP_MDDT = ConfigurationManager.AppSettings["U_SYP_MDDT"].ToString();
            invoice.U_SYP_MDFN = ConfigurationManager.AppSettings["U_SYP_MDFN"].ToString();
            invoice.U_SYP_MDFC = ConfigurationManager.AppSettings["U_SYP_MDFC"].ToString();
            invoice.U_SYP_MDVN = ConfigurationManager.AppSettings["U_SYP_MDVN"].ToString();
            invoice.U_SYP_MDVC = ConfigurationManager.AppSettings["U_SYP_MDVC"].ToString();
            invoice.DocumentLines = InvoiceGenerateTramaDetail(order.DocumentLines, docEntryDelivery);

            return JsonConvert.SerializeObject(invoice);
        }



        private static List<DocumentDetail> InvoiceGenerateTramaDetail(List<OrderDetail> orderDetail, int docEntryBase)
        {
            List<DocumentDetail> documentDetails = new List<DocumentDetail>();

            foreach (var det in orderDetail)
            {
                DocumentDetail dt = new DocumentDetail();
                dt.ItemCode = det.ItemCode;
                dt.Quantity = det.Quantity;
                dt.WarehouseCode = det.WarehouseCode;
                dt.CostingCode = det.CostingCode;
                dt.CostingCode2 = det.CostingCode2;
                dt.CostingCode3 = det.CostingCode3;
                dt.CostingCode4 = det.CostingCode4;
                dt.CostingCode5 = det.CostingCode5;
                dt.TaxCode = det.TaxCode;
                dt.BaseType = 15;
                dt.BaseEntry = docEntryBase;
                dt.BaseLine = det.LineNum;

                documentDetails.Add(dt);
            }


            return documentDetails;
        }
    }
}
