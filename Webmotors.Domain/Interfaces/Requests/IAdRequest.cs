using System.ComponentModel.DataAnnotations;

namespace Webmotors.Domain.Interfaces.Requests
{
    public interface IAdRequest
    {
        [Required, MaxLength(45)]
        string Make { get; set; }

        [Required, MaxLength(45)]
        string Model { get; set; }

        [Required, MaxLength(45)]
        string Version { get; set; }

        [Required]
        int Year { get; set; }

        [Required]
        int Mileage { get; set; }

        [Required]
        string Note { get; set; }
    }
}
