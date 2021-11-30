using System.Collections.Generic;
using System.Linq;
using Webmotors.Application.Services;
using Webmotors.Domain.Interfaces.Services;

namespace Webmotors.UI.Data
{
    public class Service
    {
        private IAdService _adService;
        private WebMotorsAPI _api;
        private List<WebMotorsOptions> _makes;
        private List<WebMotorsOptions> _models;
        private List<WebMotorsOptions> _versions;

        public Service(IAdService service, WebMotorsAPI api)
        {
            this._adService = service;
            this._api = api;
            this._makes = new List<WebMotorsOptions>();
            this._models = new List<WebMotorsOptions>();
            this._versions = new List<WebMotorsOptions>();
        }

        public Ad Load(int? ID)
        {
            return ID.HasValue ? new Ad(_adService.Get(ID.Value)) : new Ad();
        }

        public Ad Save(Ad ad)
        {
            var request = ad.ToRequest();

            if (ad.ID > 0)
            {
                _adService.Update(ad.ID, request);
            }
            else
            {
                _adService.Add(request);
            }

            return ad;
        }

        public void Delete(Ad ad)
        {
            _adService.Remove(ad.ID);
        }

        public IEnumerable<string> GetMakes()
        {
            this._makes = _api.GetMakes().Result.ToList();

            return this._makes.Select(m => m.Name);
        }

        public IEnumerable<string> GetModels(string make)
        {
            WebMotorsOptions currentMake = this._makes.FirstOrDefault(m => m.Name == make);

            if (currentMake != null)
            {
                this._models = _api.GetModels(currentMake.ID).Result.ToList();
            }

            return this._models.Select(m => m.Name);
        }

        public IEnumerable<string> GetVersions(string model)
        {
            WebMotorsOptions currentModel = this._models.FirstOrDefault(m => m.Name == model);

            if (currentModel != null)
            {
                this._versions = _api.GetVersions(currentModel.ID).Result.ToList();
            }

            return this._versions.Select(m => m.Name);
        }
    }
}
