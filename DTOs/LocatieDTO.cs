using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.DTOs
{
    public class LocatieDTO
    {
        [Required(ErrorMessage = "Locatie naam is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(2, ErrorMessage = "Naam moet minstens 2 karakters bevatten!")]
        public string LocatieNaam { get; set; }


        [Required(ErrorMessage = "Straat is verplicht")]
        [DataType(DataType.Text)]
        public string Straat { get; set; }

        [Required(ErrorMessage = "Nr is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(1, ErrorMessage = "Nr 1 karakters bevatten!")]
        public string Nr { get; set; }

        [Required(ErrorMessage = "Postcpde is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(4, ErrorMessage = "Naam moet minstens 4 karakters bevatten!")]
        [MaxLength(4, ErrorMessage = "Naam moet minstens 4 karakters bevatten!")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Plaatsnaam is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "Naam moet minstens 3 karakters bevatten!")]
        public string PlaatsNaam { get; set; }
    }
}
