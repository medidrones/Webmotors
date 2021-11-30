using System.ComponentModel.DataAnnotations;
using Webmotors.Domain.Interfaces.Requests;

namespace Webmotors.Application.Requests
{
    public class AdRequest : IAdRequest
    {
        [Required, MaxLength(45)]
        public string Make { get; set; }

        [Required, MaxLength(45)]
        public string Model { get; set; }

        [Required, MaxLength(45)]
        public string Version { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public string Note { get; set; }
    }
}
