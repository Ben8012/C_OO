using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXP33
{
    public class Personne
    {

        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;

        public string Nom
        {    get{ return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public DateTime DateNaissance {
            get { return _dateNaissance; } 
            set { _dateNaissance = value; } 
        }


        public Personne(string nom, string prenom, DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }
        public Personne(){ }

    }
}
