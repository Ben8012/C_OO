using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXP33
{
    internal class Banque
    {
        public string Nom { get; set; }

        private Dictionary<string, Compte> _banques = new Dictionary<string, Compte>();
        public Dictionary<string, Compte> Banques
        {
            get
            {
                return _banques;
            }

        }

        public Compte this[string key]
        {
            get
            {
                Compte? c;
                Banques.TryGetValue(key, out c);
                return c;
            }
            set
            {
                Banques[key] = value;
            }
        }

        public void Ajouter(Compte compte)
        {
            if (compte.Numero == null)
            {
                throw new ArgumentNullException("Ce compte n'existe pas");
            }
            Banques.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero)
        {
            bool testDel = Banques.Remove(numero);
            if (!testDel)
            {
                throw new KeyNotFoundException("Clée non trouvée");
            }
        }

        public double AvoirDesComptes(Personne p)
        {
            double soldeTotal = 0.0;

            // Exemple sans LinQ
            // foreach (KeyValuePair<string,Courant> kvp in Banques)
            //{
            //    if(kvp.Value.Titulaire == p)
            //    {
            //        soldeTotal =  kvp.Value.Solde + soldeTotal;
            //    }
            //}

            // Exemple avec LinQ 
            foreach (Compte c in Banques.Values.Where(c => c.Titulaire == p))
            {
                soldeTotal = c + soldeTotal;
            }

            return soldeTotal;  
        }
    }
}
