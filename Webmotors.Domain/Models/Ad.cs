using FluentValidation;
using Webmotors.Domain.Interfaces.Requests;
using Webmotors.Domain.Validators;

namespace Webmotors.Domain.Models
{
    public class Ad : Entity
    {
        private AdValidator _validator = new AdValidator();

        private Ad()
        {
        }

        public Ad(IAdRequest request)
        {
            this.Update(request);
        }

        public string Make { get; private set; }
        public string Model { get; private set; }
        public string Version { get; private set; }
        public int Year { get; private set; }
        public int Mileage { get; private set; }
        public string Note { get; private set; }

        public Ad Update(IAdRequest request)
        {
            _validator.ValidateAndThrow(request);

            this.Make = request.Make;
            this.Model = request.Model;
            this.Version = request.Version;
            this.Year = request.Year;
            this.Mileage = request.Mileage;
            this.Note = request.Note;

            return this;
        }
    }
}
