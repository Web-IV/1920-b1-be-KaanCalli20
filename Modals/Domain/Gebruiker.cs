using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public class Gebruiker
    {
        #region Properties
        public int GebruikerId { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<IngeschrevenEvenement> IngeschrevenEvenementen { get; set; }

        //public IEnumerable<Evenement>
        #endregion

        #region Ctor

        public Gebruiker()
        {
            IngeschrevenEvenementen = new List<IngeschrevenEvenement>();
        }
        #endregion

        #region Methods

        public void VoegIngeschrevenEvenementToe(Evenement evenement){

            IngeschrevenEvenementen.Add(new IngeschrevenEvenement(evenement,this) );
        }
        #endregion
    }
}