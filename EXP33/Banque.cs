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

        private Dictionary<string, Courant> _banques = new Dictionary<string, Courant>();
        public Dictionary<string, Courant> Banques
        {
            get
            {
                return _banques;
            }

        }

        public Courant this[string key]
        {
            get
            {
                Courant c;
                Banques.TryGetValue(key, out c);
                return c;
            }
            set
            {
                Banques[key] = value;
            }
        }

        public void Ajouter(Courant compte)
        {
            if(compte.Numero == null)
            {
                throw new ArgumentNullException("ce compte n'existe pas");
            }
            Banques.Add(compte.Numero,compte);
        }

        public void Supprimer(string numero)
        {        
            bool testDel = Banques.Remove(numero);
            if (!testDel)
            {
                throw new KeyNotFoundException(" clée non trouvée");
            }
        }
    }
}
