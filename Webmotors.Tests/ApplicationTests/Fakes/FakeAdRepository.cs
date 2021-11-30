using System.Collections.Generic;
using Webmotors.Domain.Interfaces.Repositories;
using Webmotors.Domain.Models;

namespace Webmotors.Tests.ApplicationTests.Fakes
{
    public class FakeAdRepository : IAdRepository
    {
        private List<Ad> _records;

        public FakeAdRepository()
        {
            this._records = new List<Ad>();
        }

        public Ad Insert(Ad obj)
        {
            obj.ID = _records.Count + 1;
            _records.Add(obj);

            return this.Select(obj.ID);
        }

        public Ad Update(Ad obj)
        {
            _records[_records.FindIndex(r => r.ID == obj.ID)] = obj;

            return this.Select(obj.ID);
        }

        public IEnumerable<Ad> SelectAll()
        {
            return this._records;
        }

        public Ad Select(int id)
        {
            return _records.Find(r => r.ID == id);
        }

        public void Delete(Ad obj)
        {
            _records.Remove(obj);
        }
    }
}
