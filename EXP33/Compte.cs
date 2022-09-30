using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXP33
{
    internal abstract class Compte : IBanker
    {

        private string? _numero;
        private double _solde;
        public double Solde
        {
            get { return _solde; }
            private set { _solde = value; }

        }

        public string? Numero
        {
            get { return _numero; }
            set {// mettre une condition pour que le numero de compte Epargne soit different du numero de compte Courant 
                _numero = value; 
            }
        }
       
        public Personne? Titulaire { get; set; }

        public Compte() { }

        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }
        public Compte(string? numero, double solde, Personne? titulaire)
        {
            Numero = numero;
            Solde = solde;
            Titulaire = titulaire;
        }
       

        public virtual void Retrait(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant inferieur a 0");
                return;
            }
 
            Solde -= montant;
        }
        public virtual void Depot(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine(" pas de valeur negative ! ");
                return;
            }
            Solde += montant;
        }

        public static double operator +(Compte c1, double d)
        {
            if (c1.Solde > 0)
            {
                return c1.Solde + d;
            }
            return d;

        }

        protected abstract double CalculInteret();

        public double AppliquerInteret()
        {
            return Solde + CalculInteret();
        }

    }
}
