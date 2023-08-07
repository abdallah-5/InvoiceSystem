using Invoices.BLL.Models.RequestDTO;
using Invoices.BLL.Models.ResponseDTO;
using Invoices.DAL.Data;
using Invoices.DAL.Data.Models;

namespace Invoices.BLL.Services.Client
{
    public interface IServiceInvoice
    {
        //IEnumerable<InvoicesVM> GetAllInvoice();

        //public InvoiceHDR GetByInvoiceNum(int InvoiceNumber);

        public Task Create(InvoiceCreateVM createVM);

        public IEnumerable<BookingWithDetails> GetAllBookings();

    }
}