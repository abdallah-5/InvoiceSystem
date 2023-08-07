using Invoices.DAL.Contracts;
using Invoices.DAL.Data;
using Invoices.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.DAL.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;
        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Property> Create(Property property)
        {
            try
            {
                if (property != null)
                {
                    var obj = _context.Add<Property>(property);
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

        public void Delete(Property property)
        {
            try
            {
                if (property != null)
                {
                    var obj = _context.Remove(property);
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

        public IEnumerable<Property> GetAll()
        {
            try
            {
                var obj = _context.Properties.ToList();
                if (obj != null) return obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Property GetById(int? Id)
        {
            try
            {
                var Obj = _context.Properties.FirstOrDefault(x => x.PropertyId == Id);
                if (Obj != null) return Obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Property property)
        {
            try
            {
                if (property != null)
                {
                    var obj = _context.Update(property);
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
