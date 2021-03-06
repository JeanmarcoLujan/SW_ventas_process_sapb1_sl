using Newtonsoft.Json;
using SWVentaProcess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Data
{
    class SLData
    {
        public static HttpWebResponse PostInfo(string obj, string document, string route)
        {
            var httpWebGetRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ip_route"].ToString() + route);
            httpWebGetRequest.ContentType = "application/json";
            httpWebGetRequest.Method = "POST";
            httpWebGetRequest.KeepAlive = true;
            httpWebGetRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            httpWebGetRequest.Headers.Add("B1S-WCFCompatible", "true");
            httpWebGetRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
            httpWebGetRequest.Accept = "*/*";
            httpWebGetRequest.ServicePoint.Expect100Continue = false;
            httpWebGetRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            httpWebGetRequest.AutomaticDecompression = DecompressionMethods.GZip;
            CookieContainer cookies = new CookieContainer();
            cookies.Add(new Cookie("B1SESSION", obj.ToString()) { Domain = ConfigurationManager.AppSettings["ip_value"].ToString() });
            cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = ConfigurationManager.AppSettings["ip_value"].ToString() });
            httpWebGetRequest.CookieContainer = cookies;

            using (var streamWriter = new StreamWriter(httpWebGetRequest.GetRequestStream()))
            { streamWriter.Write(document); }

            return (HttpWebResponse)httpWebGetRequest.GetResponse();
        }

        public static HttpWebResponse GetInfoLogin(string data, string route)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ip_route"].ToString() + "Login");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.KeepAlive = true;
            httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
            httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
            httpWebRequest.Accept = "*/*";
            httpWebRequest.ServicePoint.Expect100Continue = false;
            httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            { streamWriter.Write(data); }

            return (HttpWebResponse)httpWebRequest.GetResponse();
        }


        public static HttpWebResponse GetInfo(string obj, string route)
        {
            var sdfsdf = ConfigurationManager.AppSettings["ip_route"].ToString() + route;
            var httpWebGetRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ip_route"].ToString() + route);
            httpWebGetRequest.ContentType = "application/json";
            httpWebGetRequest.Method = "GET";
            httpWebGetRequest.KeepAlive = true;
            httpWebGetRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            httpWebGetRequest.Headers.Add("B1S-WCFCompatible", "true");
            httpWebGetRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
            httpWebGetRequest.Accept = "*/*";
            httpWebGetRequest.ServicePoint.Expect100Continue = false;
            httpWebGetRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            httpWebGetRequest.AutomaticDecompression = DecompressionMethods.GZip;
            CookieContainer cookies = new CookieContainer();
            cookies.Add(new Cookie("B1SESSION", obj.ToString()) { Domain = ConfigurationManager.AppSettings["ip_value"].ToString() });
            cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = ConfigurationManager.AppSettings["ip_value"].ToString() });
            httpWebGetRequest.CookieContainer = cookies;

            //using (var streamWriter = new StreamWriter(httpWebGetRequest.GetRequestStream()))
            //{ streamWriter.Write(document); }

            return (HttpWebResponse)httpWebGetRequest.GetResponse();
        }

        public static List<Lote> getInfoLote(string url)
        {
            List<Lote> result = new List<Lote>();
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<Lote>>(json);
            }

            return result;
        }
    }
}
