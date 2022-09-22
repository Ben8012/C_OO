using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1_Class_Props
{
    // internal 
    enum Cat { a, b, c };
    public enum Cat2 { a, b, c };

    internal partial class Class1
    {
        private string? _name;
        private int _age;
        public string? Name 
        {
            get
            {   
                if( _name == null)
                {
                    throw new ArgumentNullException($"la propriete Name est null");
                }
                else
                {
                    return _name;
                }
              
               
                
            }
            set
            {
                if( value == null)
                {
                    throw new ArgumentNullException($"l'argument est null");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public int Age { 
            get
            { 
                return _age;
            }
            set
            {
                _age = value < 18 ? 18 : value;  // si Age est inferieur a 18 on assigne 18 a _age
            }
        }

     

        public void Greetings()
        {
            Console.WriteLine($"Bienvenue {Name}");
        }

        public Class1(string name, int age = 14)
        {
            this.Name = name;
            this.Age = age;
            
        }

        //public Class1() : this("Marie",20)  // appel l'autre constructeur et lui met des parametre par defaut
        //{

        //}

        public Class1() 
        {

        }
    }
    internal partial class Class1
    {
        public string Hello;
    }
}

