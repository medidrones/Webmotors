using System.Collections.Generic;
using System.Linq;
using Webmotors.Application.Responses;
using Webmotors.Domain.Interfaces.Repositories;
using Webmotors.Domain.Interfaces.Requests;
using Webmotors.Domain.Interfaces.Responses;
using Webmotors.Domain.Interfaces.Services;
using Webmotors.Domain.Models;

namespace Webmotors.Application.Services
{
    public class AdService : IAdService
    {
        IAdRepository _repository;
        WebMotorsAPI _api;

        public AdService(IAdRepository repository)
        {
            this._repository = repository;
            this._api = new WebMotorsAPI();
        }

        public IAdResponse Add(IAdRequest request)
        {
            var dbObj = _repository.Insert(new Ad(request));

            return new AdResponse(dbObj);
        }

        public IAdResponse Update(int id, IAdRequest request)
        {
            var dbObj = _repository.Select(id);

            var obj = dbObj.Update(request);

            dbObj = _repository.Update(obj);

            return new AdResponse(dbObj);
        }

        public IEnumerable<IAdResponse> Get()
        {
            var dbObjs = _repository.SelectAll();

            return dbObjs.Select(o => new AdResponse(o)).ToList();
        }

        public IAdResponse Get(int id)
        {
            var dbObj = _repository.Select(id);

            return dbObj != null ? new AdResponse(dbObj) : null;
        }

        public void Remove(int id)
        {
            _repository.Delete(_repository.Select(id));
        }
    }
}
