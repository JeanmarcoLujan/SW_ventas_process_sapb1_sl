using SWVentaProcess.Helpers;
using SWVentaProcess.Models;
using SWVentaProcess.Models.OrderModel;
using SWVentaProcess.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SWVentaProcess
{
    public partial class VentasProcess : ServiceBase
    {
        Timer timer = new Timer();
        public VentasProcess()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Servicio para generar documentos de venta " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; 
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToFile("Servicio parar generar documentos de venta se ha detenido" + DateTime.Now);
        }


        private static object _intervalSync = new object();
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {


            if (System.Threading.Monitor.TryEnter(_intervalSync))
            {
                try
                {
                    VentaService ventaService = new VentaService();
                    //Login
                    string token = ventaService.Login();

                    //Obtener ordenes
                    List<Order> orders = ventaService.getOrders(token);

                    //Generar entregas, factura y pago
                    foreach (var doc in orders)
                    {
                        //create delivery
                        Response resDelivery = ventaService.createDelivery(token, DeliveryHelper.DeliveryGenerateTrama(doc));

                        //create invoice
                        Response resInvoice = ventaService.createDelivery(token, InvoiceHelper.InvoiceGenerateTrama(doc, int.Parse(resDelivery.DocEntry)));

                        //create payment
                        Response resPayment = ventaService.createPayment(token, PaymentHelper.PaymentGenerateTrama(doc, resInvoice));

                    }

                   




                    WriteToFile(DateTime.Now + ": " + "ASDF");
                }
                finally
                {
                    // Make sure Exit is always called
                    System.Threading.Monitor.Exit(_intervalSync);
                }
            }


        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
