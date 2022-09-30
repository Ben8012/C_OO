using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXP33
{
    public interface ICustomer
    {
        public double Solde { get;  }
        public void Retrait(double montant);
        public void Depot(double montant);
    }
}
