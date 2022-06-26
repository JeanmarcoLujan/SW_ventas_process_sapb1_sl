using Newtonsoft.Json;
using SWVentaProcess.Data;
using SWVentaProcess.Models;
using SWVentaProcess.Models.OrderModel;
using SWVentaProcess.Services.contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Services
{
    class VentaService : IVentaService
    {
        

        public string Login()
        {
            string data = "{    \"CompanyDB\": \"" + ConfigurationManager.AppSettings["CompanyDB"].ToString() + "\",  \"UserName\": \"" + ConfigurationManager.AppSettings["UserName"].ToString() + "\", \"Password\": \"" + ConfigurationManager.AppSettings["Password"].ToString() + "\", \"Language\":\"23\"}";

            B1Session obj = null;
            try
            {
                using (var streamReader = new StreamReader(SLData.GetInfoLogin(data, "Login").GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<B1Session>(result);
                }
            }
            catch (Exception e)
            {
                obj = JsonConvert.DeserializeObject<B1Session>("");
            }

            return obj.SessionId.ToString();
        }

        public Response createDelivery(string token, string document)
        {
            Response documentResult = new Response();
            try
            {
                using (var streamReader = new StreamReader(SLData.PostInfo(token, document, "DeliveryNotes").GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    documentResult = JsonConvert.DeserializeObject<Response>(result);
                    documentResult.Registered = true;
                    documentResult.Message = "Se registro con exito";
                }
            }
            catch (WebException e)
            {
                ErrorSL errorMessage = null;
                errorMessage = JsonConvert.DeserializeObject<ErrorSL>(new StreamReader(e.Response.GetResponseStream()).ReadToEnd());
                documentResult.DocEntry = "0";
                documentResult.Registered = false;
                documentResult.Message = errorMessage.error.message.value.ToString();
            }


            return documentResult;
        }

        public Response createInvoice(string token, string document)
        {
            Response documentResult = new Response();
            try
            {
                using (var streamReader = new StreamReader(SLData.PostInfo(token, document, "Invoices").GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    documentResult = JsonConvert.DeserializeObject<Response>(result);
                    documentResult.Registered = true;
                    documentResult.Message = "Se registro con exito";
                }
            }
            catch (WebException e)
            {
                ErrorSL errorMessage = null;
                errorMessage = JsonConvert.DeserializeObject<ErrorSL>(new StreamReader(e.Response.GetResponseStream()).ReadToEnd());
                documentResult.DocEntry = "0";
                documentResult.Registered = false;
                documentResult.Message = errorMessage.error.message.value.ToString();
            }


            return documentResult;
        }

        public Response createPayment(string token, string document)
        {
            Response documentResult = new Response();
            try
            {
                using (var streamReader = new StreamReader(SLData.PostInfo(token, document, "IncomingPayments").GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    documentResult = JsonConvert.DeserializeObject<Response>(result);
                    documentResult.Registered = true;
                    documentResult.Message = "Se registro con exito";
                }
            }
            catch (WebException e)
            {
                ErrorSL errorMessage = null;
                errorMessage = JsonConvert.DeserializeObject<ErrorSL>(new StreamReader(e.Response.GetResponseStream()).ReadToEnd());
                documentResult.DocEntry = "0";
                documentResult.Registered = false;
                documentResult.Message = errorMessage.error.message.value.ToString();
            }


            return documentResult;
        }

        public OrderDTO getOrders(string token)
        {
            OrderDTO documentResult = new OrderDTO();
            try
            {
                using (var streamReader = new StreamReader(SLData.GetInfo(token, "Orders?$filter=U_CALI_VTEX eq 'Y' AND DocumentStatus eq 'bost_Open' ").GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    
                    documentResult = JsonConvert.DeserializeObject<OrderDTO>(result);
                }
            }
            catch (WebException e)
            {
                ErrorSL errorMessage = null;
                errorMessage = JsonConvert.DeserializeObject<ErrorSL>(new StreamReader(e.Response.GetResponseStream()).ReadToEnd());

                string sdf = errorMessage.error.message.value.ToString();
            }


            return documentResult;
        }

        public List<Lote> getLote(string itemCode, string whsCode)
        {
            string url = $"" + ConfigurationManager.AppSettings["ip_xs"].ToString() + "GetLote.xsjs?database=" + ConfigurationManager.AppSettings["CompanyDB"].ToString() + "&itemCode='" + itemCode + "'&whsCode='" + whsCode + "'";
            return SLData.getInfoLote(url);
        }
    }
}
