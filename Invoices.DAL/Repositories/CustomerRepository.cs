using Invoices.DAL.Contracts;
using Invoices.DAL.Data;
using Invoices.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    var obj = _context.Add<Customer>(customer);
                    await _context.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null!;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    var obj = _context.Remove(customer);
                    if (obj != null)
                    {
                        _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                var obj = _context.Customers.ToList();
                if (obj != null) return obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Customer GetById(int? Id)
        {
            try
            {
                var Obj = _context.Customers.FirstOrDefault(x => x.CustomerId == Id);
                if (Obj != null) return Obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    var obj = _context.Update(customer);
                    if (obj != null) _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


       
    }
}
