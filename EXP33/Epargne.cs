using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXP33
{
    internal class Epargne : Compte
    {
        
        public Epargne( string? numero, double solde, Personne? titulaire) : base(numero, solde, titulaire)
        {
            
        }
        public Epargne() { }
    
        private DateTime _dateDernierRetrait;
        public DateTime DateDernierRetrait
        {
            get { return _dateDernierRetrait; }
            set { _dateDernierRetrait = value; }
        }


        public override void Retrait(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant inferieur a 0");
                return;
            }
            DateDernierRetrait = DateTime.Now;
            base.Retrait(montant);  
        }

        protected override double CalculInteret()
        {
            return Solde * 0.045;
        }
    }
}
