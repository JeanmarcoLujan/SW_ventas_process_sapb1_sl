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
            delivery.U_SYP_MDCT = ConfigurationManager.AppSettings["U_SYP_MDCT"].ToString();
            delivery.U_SYP_MDRT = ConfigurationManager.AppSettings["U_SYP_MDRT"].ToString();
            delivery.U_SYP_MDNT = ConfigurationManager.AppSettings["U_SYP_MDNT"].ToString();
            delivery.U_SYP_MDDT = ConfigurationManager.AppSettings["U_SYP_MDDT"].ToString();
            delivery.U_SYP_MDFN = ConfigurationManager.AppSettings["U_SYP_MDFN"].ToString();
            delivery.U_SYP_MDFC = ConfigurationManager.AppSettings["U_SYP_MDFC"].ToString();
            delivery.U_SYP_MDVN = ConfigurationManager.AppSettings["U_SYP_MDVN"].ToString();
            delivery.U_SYP_MDVC = ConfigurationManager.AppSettings["U_SYP_MDVC"].ToString();

            delivery.DocumentLines = DeliveryGenerateTramaDetail(order.DocumentLines, int.Parse(order.DocEntry));

            return  JsonConvert.SerializeObject(delivery);
        }



        private static List<DocumentDetail> DeliveryGenerateTramaDetail(List<OrderDetail> orderDetail, int docEntryBase)
        {
            List<DocumentDetail> documentDetails = new List<DocumentDetail>();

            foreach (var det in orderDetail)
            {
                DocumentDetail dt = new DocumentDetail();
                dt.ItemCode = det.ItemCode;
                dt.Quantity = det.Price;
                dt.WarehouseCode = det.WarehouseCode;
                dt.CostingCode = det.CostingCode;
                dt.CostingCode2 = det.CostingCode2;
                dt.CostingCode3 = det.CostingCode3;
                dt.CostingCode4 = det.CostingCode4;
                dt.CostingCode5 = det.CostingCode5;
                dt.TaxCode = det.TaxCode;
                dt.BaseType = 17;
                dt.BaseEntry = docEntryBase;
                dt.BaseLine = det.LineNum;

                documentDetails.Add(dt);
            }
            

            return documentDetails;
        }
    }
}
