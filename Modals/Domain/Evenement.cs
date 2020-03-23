using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public class Evenement
    {
        #region Properties
        public int Id { get; set; }
        public string NaamEvent { get; set; }
        public DateTime StartMoment { get; set; }
        public int AantalDagen { get; set; }
        public int MaxAantalDeelnemers { get; set; }
        public Locatie Locatie { get; set; }
        public ICollection<Attractie> Attracties { get; set; }
        public ICollection<IngeschrevenEvenement> IngeschrevenGebruikers{get;set;}
        #endregion
        public Evenement()
        {
            Attracties = new List<Attractie>();
        }
        
        public void VoegAttractieToe(Attractie attractie)
        {
            if (!Attracties.Contains(attractie))
            {
                Attracties.Add(attractie);
            }
        }
        public void VerwijderAttractie(Attractie attractie)
        {
            if (Attracties.Contains(attractie))
            {
                Attracties.Remove(attractie);
            }
        }
        public Attractie GetAttractie(int attractieId)
        {
            return Attracties.SingleOrDefault(m => m.Id == attractieId);
        }
    }
}
