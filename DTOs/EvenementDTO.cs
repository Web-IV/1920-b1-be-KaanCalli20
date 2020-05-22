using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

        [Required(ErrorMessage = "Omschrijving van het evenement is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(10, ErrorMessage = "Omschrijving moet minstens 10 karakters bevatten!")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "StartMoment is verplicht")]
        [DataType(DataType.Date)]
        public string StartMoment { get; set; }

        [Required(ErrorMessage = "AantalDagen is verplicht")]
        [DataType(DataType.Date)]
        public string EindMoment { get; set; }

        [Required(ErrorMessage = "Aantal deelnemers is verplicht")]
        //[DataType(DataType.Text)]
        public int MaxAantalDeelnemers { get; set; }

        [Required(ErrorMessage = "Locatie is verplicht")]
        public int LocatieId { get; set; }

        [Required(ErrorMessage = "Attracties zijn verplicht")]
        public ICollection<int> AttractiesIds { get; set; }

        public DateTime getStartMoment()
        {
            string datum = StartMoment;
            CultureInfo provider = CultureInfo.InvariantCulture;
            //datum = StartMoment.Split('T').Join(" ");
            //datum = datum.Split('Z').Join("");
            Console.WriteLine(datum);
            //return DateTime.ParseExact(datum, "yyyy-MM-dd HH:mm:ss.fff", provider);
            return Convert.ToDateTime(datum);
        }
        public DateTime getEindMoment()
        {
            string datum = EindMoment;
            Console.WriteLine(EindMoment);
            CultureInfo provider = CultureInfo.GetCultureInfo("en-GB");
            //provider.mo
            //List<string> names = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
            //    DateTimeFormatInfo.GetInstance(new CultureInfo("en-GB")).get
;
            Console.WriteLine(datum.Substring(5, 2));
            //Console.WriteLine(names.IndexOf(datum.Substring(5, 2)));
            //datum = EindMoment.Split('T').Join(" ");
            //datum = datum.Split('Z').Join("");
            Console.WriteLine(datum);
            //return DateTime.ParseExact(datum, "yyyy-MM-dd HH:mm:ss.fff", provider);
            return Convert.ToDateTime(datum); 
        }
    }
}
