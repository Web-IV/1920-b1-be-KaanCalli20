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
        public string Omschrijving { get; set; }
        public DateTime StartMoment { get; set; }
        public DateTime EindMoment { get; set; }
        public int MaxAantalDeelnemers { get; set; }
        public Locatie Locatie { get; set; }
        public ICollection<Attractie> Attracties { get; set; }
        public ICollection<IngeschrevenEvenement> Deelnemers { get; set; }
        #endregion
        public Evenement()
        {
            Attracties = new List<Attractie>();
            Deelnemers = new List<IngeschrevenEvenement>();
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
        public void SchrijfIn(Gebruiker gebruiker)
        {

            if (Deelnemers.FirstOrDefault(m => m.GebruikerId == gebruiker.GebruikerId && m.EvenementId == this.Id) != null)
            {
                throw new ArgumentException("U bent al ingeschreven");
               
            }
            else
            {
                IngeschrevenEvenement deelnemer = new IngeschrevenEvenement(this, gebruiker);
                Deelnemers.Add(deelnemer);
            }
        }
        public void SchrijfUit(Gebruiker gebruiker)
        {
            IngeschrevenEvenement deelnemer = Deelnemers.FirstOrDefault(m => m.GebruikerId == gebruiker.GebruikerId && m.EvenementId == this.Id);
            if ( deelnemer != null)
            {
                Deelnemers.Remove(deelnemer);
            }
            else
            {
                throw new ArgumentException("U bent nog niet ingeschreven");
            }
        }

        public Boolean isIngeschreven(Gebruiker gebruiker)
        {
            IngeschrevenEvenement deelnemer = Deelnemers.FirstOrDefault(m => m.GebruikerId == gebruiker.GebruikerId && m.EvenementId == this.Id);
            if (deelnemer == null) return false;
            else return true;
        }
    }
}
