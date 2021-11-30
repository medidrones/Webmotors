using System.Collections.Generic;
using Webmotors.Domain.Interfaces.Requests;
using Webmotors.Domain.Interfaces.Responses;

namespace Webmotors.Domain.Interfaces.Services
{
    public interface IAdService
    {
        IAdResponse Add(IAdRequest request);
        IAdResponse Update(int id, IAdRequest request);
        IEnumerable<IAdResponse> Get();
        IAdResponse Get(int id);
        void Remove(int id);
    }
}
