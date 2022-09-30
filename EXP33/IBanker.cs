using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXP33
{
    internal interface IBanker : ICustomer
    {
        public double AppliquerInteret();
        public Personne Titulaire { get;  }

        public string Numero { get; }
    }
}
