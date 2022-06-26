using SWVentaProcess.Helpers;
using SWVentaProcess.Models;
using SWVentaProcess.Models.OrderModel;
using SWVentaProcess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess
{
    class TestApp
    {
        public void ExecuteProcess()
        {
            VentaService ventaService = new VentaService();
            //Login
            string token = ventaService.Login();

            //Obtener ordenes
            OrderDTO orders = ventaService.getOrders(token);

            //Generar entregas, factura y pago
            foreach (var doc in orders.value)
            {
                var SDF = DeliveryHelper.DeliveryGenerateTrama(doc);
                //create delivery
                Response resDelivery = ventaService.createDelivery(token, DeliveryHelper.DeliveryGenerateTrama(doc));

                //create invoice
                Response resInvoice = ventaService.createInvoice(token, InvoiceHelper.InvoiceGenerateTrama(doc, int.Parse(resDelivery.DocEntry)));

                //create payment
                Response resPayment = ventaService.createPayment(token, PaymentHelper.PaymentGenerateTrama(doc, resInvoice));

            }
        }

    }


}
