using Invoices.DAL.Contracts;
using Invoices.DAL.Data;
using Invoices.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> Create(Project project)
        {
            try
            {
                if (project != null)
                {
                    var obj = _context.Add<Project>(project);
                    //await _context.SaveChangesAsync();
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

        public void Delete(Project project)
        {
            try
            {
                if (project != null)
                {
                    var obj = _context.Remove(project);
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

        public IEnumerable<Project> GetAll()
        {
            try
            {
                var obj = _context.Projects.ToList();
                if (obj != null) return obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Project GetById(int? Id)
        {
            try
            {
                var Obj = _context.Projects.FirstOrDefault(x => x.ProjectId == Id);
                if (Obj != null) return Obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Project project)
        {
            try
            {
                if (project != null)
                {
                    var obj = _context.Update(project);
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
