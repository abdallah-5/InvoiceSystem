using Invoices.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DAL.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
