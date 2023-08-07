using Invoices.BLL.Models.RequestDTO;
using Invoices.BLL.Services.Client;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.PL.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IServiceInvoice _serviceInvoice;
        public InvoiceController(IServiceInvoice serviceInvoice)
        {
            _serviceInvoice = serviceInvoice;
        }

       

       

        public async Task<IActionResult> Index()
        {
            
            return View(_serviceInvoice.GetAllBookings());
        }

       

        




    }
}