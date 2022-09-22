using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_Indexeur
{
    internal class Dictionnaire_Indexeur
    {
        private Dictionary<Guid, Personne> _locataires;
        public Dictionary<Guid, Personne> Locataires 
        { get 
            {
                return _locataires ?? (_locataires = new Dictionary<Guid, Personne>());
            }
            
        }

        public Personne this[Guid key]
        {
            get 
            {
                Personne personne;
                Locataires.TryGetValue(key, out personne);
                return personne;
            }
            set
            {
                Locataires[key] = value;
            }
        }
    }
}
