
using Invoices.BLL.Models.RequestDTO;
using Invoices.BLL.Services.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelApi_PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IServiceInvoice _serviceInvoice;

        public InvoiceController(IServiceInvoice serviceInvoice)
        {
            _serviceInvoice = serviceInvoice;
        }





        [HttpPost("CreateInvoice")]
        public async Task<IActionResult> CreateInvoice(InvoiceCreateVM createVM)

        {
            await _serviceInvoice.Create(createVM);


                return Ok("ok");

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_serviceInvoice.GetAllBookings());
        }


    }


    
}
