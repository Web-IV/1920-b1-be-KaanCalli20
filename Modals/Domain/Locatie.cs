using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public class Locatie
    {
        public int Id { get; set; }
        public string LocatieNaam { get; set; }
        public string Straat { get; set; }
        public string Nr { get; set; }
        public string Postcode { get; set; }
        public string PlaatsNaam { get; set; }

    }
}
