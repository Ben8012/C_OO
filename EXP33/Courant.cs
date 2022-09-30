using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXP33
{
    internal class Courant : Compte
    {
        public Courant( string? numero, double solde, double ligneDeCredit, Personne? titulaire) : base(numero, solde, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }
        public Courant(){ }

        

        private double _ligneDeCredit;
        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set
            {
                if (value > 0)
                {
                    _ligneDeCredit = value;
                }
                else
                {
                    Console.WriteLine("ligne de crédit ne peut etre inferieur a 0");
                }
            }
        }


        public override void Retrait(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant inferieur a 0");
                return;
            }

            if (Solde - montant < -LigneDeCredit)
            {
                Console.WriteLine(" ligne de crédit inssufissante ! ");
                return;
            }
            base.Retrait(montant);  
            
        }


        protected override double CalculInteret()
        {
            if (Solde > 0)
            {
                return Solde * 0.03;
            }
            else
            {
                return Solde * 0.0975;
            }
        }
    }
}
