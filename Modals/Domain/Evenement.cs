using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public class Evenement
    {
        public int Id { get; set; }
        public string NaamEvent { get; set; }
        public DateTime StartMoment { get; set; }
        public int MaxAantalDeelnemers { get; set; }
        public StatusEvenement Status { get; set; }
        public Locatie Locatie { get; set; }
        public ICollection<Attractie> Attracties{get;set;}
        
        public Evenement()
        {
            Attracties = new List<Attractie>();
        }
    }
}
