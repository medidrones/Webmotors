using Webmotors.Application.Requests;
using Webmotors.Domain.Interfaces.Requests;

namespace Webmotors.Tests.ApplicationTests.Factories
{
    public class AdRequestFactory
    {
        public IAdRequest GetAdRequest(bool valid = true)
        {
            return valid ? ValidRequest : InvalidRequest;
        }

        private AdRequest ValidRequest 
        {
            get
            {
                var request = new AdRequest();
                request.Make = "Mitsubishi";
                request.Model = "Pajero";
                request.Version = "Sport GLS V6";
                request.Year = 2002;
                request.Mileage = 185550;
                request.Note = "Único dono, e está bem cuidado";

                return request;
            }
        }

        private AdRequest InvalidRequest
        {
            get
            {
                var request = new AdRequest();
                request.Make = "Campo marca excedo o limite de quarenta e cinco caracteres";
                request.Model = "";
                request.Version = null;

                return request;
            }
        }
    }
}
