using System.Collections.Generic;
using Webmotors.Domain.Interfaces.Repositories;
using Webmotors.Domain.Models;

namespace Webmotors.Infrastructure.Repositories
{
    public class AdRepository : IAdRepository
    {
        private WebmotorsContext _context;

        public AdRepository(WebmotorsContext context)
        {
            this._context = context;
        }

        public Ad Insert(Ad obj)
        {
            _context.Set<Ad>().Add(obj);
            _context.SaveChanges();

            return this.Select(obj.ID);
        }

        public Ad Update(Ad obj)
        {
            _context.Set<Ad>().Update(obj);
            _context.SaveChanges();

            return this.Select(obj.ID);
        }

        public IEnumerable<Ad> SelectAll()
        {
            return _context.Set<Ad>();
        }

        public Ad Select(int id)
        {
            return _context.Set<Ad>().Find(id);
        }

        public void Delete(Ad obj)
        {
            _context.Set<Ad>().Remove(obj);
            _context.SaveChanges();
        }
    }
}
