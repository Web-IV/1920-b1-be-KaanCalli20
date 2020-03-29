using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.DTOs
{
    public class EvenementDTO
    {
        [Required(ErrorMessage = "Naam van het evenement is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "Naam moet minstens 3 karakters bevatten!")]
        public string NaamEvent { get; set; }

        [Required(ErrorMessage = "StartMoment is verplicht")]
        [DataType(DataType.DateTime)]
        public DateTime StartMoment { get; set; }

        [Required(ErrorMessage = "AantalDagen is verplicht")]
        [DataType(DataType.DateTime)]
        public DateTime EindMoment { get; set; }

        [Required(ErrorMessage = "Aantal deelnemers is verplicht")]
        //[DataType(DataType.Text)]
        public int MaxAantalDeelnemers { get; set; }

        public int LocatieId { get; set; }

        public ICollection<int> AttractiesIDs { get; set; }
    }
}
