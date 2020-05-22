using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.DTOs
{
    public class AttractieDTO
    {
        [Required(ErrorMessage = "Naam van de attractie is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "Naam moet minstens 3 karakters bevatten!")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Omschrijving van de attractie is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(10, ErrorMessage = "Omschrijving moet minstens 10 karakters bevatten!")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage ="Type is verplicht!")]
        public TypeAttractie TypeAttractie { get; set; }
    }
}
