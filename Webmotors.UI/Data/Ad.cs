using System.ComponentModel.DataAnnotations;
using Webmotors.Application.Requests;
using Webmotors.Domain.Interfaces.Requests;
using Webmotors.Domain.Interfaces.Responses;

namespace Webmotors.UI.Data
{
    public class Ad
    {
        public Ad()
        {
        }

        public Ad(IAdResponse response)
        {
            this.ID = response.ID;
            this.Make = response.Make;
            this.Model = response.Model;
            this.Version = response.Version;
            this.Year = response.Year;
            this.Mileage = response.Mileage;
            this.Note = response.Note;
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Campo {0} é obrigatório."), MaxLength(45, ErrorMessage = "Campo {0} excede limite permitido.")]
        [Display(Name = "Marca")]
        public string Make { get; set; }
                  
        [Required(ErrorMessage = "Campo {0} é obrigatório."), MaxLength(45, ErrorMessage = "Campo {0} excede limite permitido.")]
        [Display(Name = "Modelo")]
        public string Model { get; set; }     

        [Required(ErrorMessage = "Campo {0} é obrigatório."), MaxLength(45, ErrorMessage = "Campo {0} excede limite permitido.")]
        [Display(Name = "Versão")]
        public string Version { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Ano")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Quilometragem")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Observação")]
        public string Note { get; set; }

        public IAdRequest ToRequest()
        {
            var request = new AdRequest();

            request.Make = this.Make;
            request.Model = this.Model;
            request.Version = this.Version;
            request.Year = this.Year;
            request.Mileage = this.Mileage;
            request.Note = this.Note;

            return request;
        }
    }
}
