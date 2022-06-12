using SWVentaProcess.Models;
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
        Response createDelivery(string token, string document);

        Response createInvoice(string token, string document);

        Response createPayment(string token, string document);
    }
}
