using Webmotors.Domain.Interfaces.Responses;
using Webmotors.Domain.Models;

namespace Webmotors.Application.Responses
{
    public class AdResponse : IAdResponse
    {
        public AdResponse(Ad obj)
        {
            this.ID = obj.ID;
            this.Make = obj.Make;
            this.Model = obj.Model;
            this.Version = obj.Version;
            this.Year = obj.Year;
            this.Mileage = obj.Mileage;
            this.Note = obj.Note;
        }

        public int ID { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string Version { get; private set; }
        public int Year { get; private set; }
        public int Mileage { get; private set; }
        public string Note { get; private set; }
    }
}
