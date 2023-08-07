using Invoices.DAL.Contracts;
using Invoices.DAL.Data;
using Invoices.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> Create(Booking booking)
        {
            try
            {
                if (booking != null)
                {
                    var obj = _context.Add<Booking>(booking);
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

        public void Delete(Booking booking)
        {
            try
            {
                if (booking != null)
                {
                    var obj = _context.Remove(booking);
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

        public IEnumerable<Booking> GetAll()
        {
            try
            {
                var obj = _context.Bookings
                   .Include(b => b.Customer)
                   .Include(b => b.Property)
                   .ThenInclude(p => p.Project)
                   .ToList();
                if (obj != null) return obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public Booking GetById(int? Id)
        {
            try
            {
                var Obj = _context.Bookings.FirstOrDefault(x => x.BookingId == Id);
                if (Obj != null) return Obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Booking booking)
        {
            try
            {
                if (booking != null)
                {
                    var obj = _context.Update(booking);
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
