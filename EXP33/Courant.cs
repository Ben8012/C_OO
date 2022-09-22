using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXP33
{
    internal class Courant
    {
        private string? _numero;
        private double _solde;
        private double _ligneDeCredit;

        public string? Numero 
        { 
            get { return _numero; } 
            set { _numero = value; } 
        }
        public double Solde 
        { 
            get { return _solde; } 
            private set { _solde = value; }
           
        }

        public double LigneDeCredit 
        { 
            get { return _ligneDeCredit; }
            set {
                    if (value > 0)
                    {
                        _ligneDeCredit = value;
                    }
                } 
        }
        internal Personne? Titulaire;

        

        public void Retrait(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant inferieur a 0");
                return;
            }
            //if(montant > Solde )
            //{
            //    Console.WriteLine(" solde insufisant ! ");
            //    return;
            //}
            if (Solde - montant <  -LigneDeCredit)
            {
                Console.WriteLine(" ligne de crédit inssufissante ! ");
                return;
            }
            Solde -= montant;    
        }
        public void Depot(double montant)
        {
            if(montant <= 0)
            {
                Console.WriteLine(" pas de valeur negative ! ");
                return;
            }  
            Solde += montant; 
        }

        public Courant(string? numero,double solde, double ligneDeCredit, Personne? titulaire)
        {
            this.Numero = numero;
            this.Solde = solde;
            this.LigneDeCredit = ligneDeCredit;
            this.Titulaire = titulaire;
        }

        public Courant(){}
    }
}
