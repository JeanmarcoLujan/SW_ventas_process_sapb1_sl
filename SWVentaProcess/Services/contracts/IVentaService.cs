using SWVentaProcess.Models;
using SWVentaProcess.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVentaProcess.Services.contracts
{
    interface IVentaService
    {
        string Login();
        OrderDTO getOrders(string token);
        Response createDelivery(string token, string document);
        Response createInvoice(string token, string document);
        Response createPayment(string token, string document);
        List<Lote> getLote(string itemCode, string whsCode);
    }
}
