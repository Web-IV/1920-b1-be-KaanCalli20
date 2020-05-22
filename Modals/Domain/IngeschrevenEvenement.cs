using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public class IngeschrevenEvenement
    {
        #region Properties
        public int GebruikerId { get; set; }

        public int EvenementId { get; set; }

        public Gebruiker Gebruiker { get; set; }

        public Evenement Evenement { get; set; }

        public IngeschrevenEvenement() { }

        public IngeschrevenEvenement(Evenement evenement, Gebruiker gebruiker)
        {
            this.Gebruiker = gebruiker;
            this.GebruikerId = gebruiker.GebruikerId;
            this.Evenement = evenement;
            this.EvenementId = evenement.Id;
        }
        #endregion
    }
}
