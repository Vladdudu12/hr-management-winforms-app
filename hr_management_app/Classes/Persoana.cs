using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_management_app
{
    internal class Persoana
    {
        private string _nume;
        private string _prenume;
        private int _varsta;

        public Persoana() { }
        public Persoana(string nume, string prenume, int varsta)
        {
            _nume = nume;
            _prenume = prenume;
            _varsta = varsta;
        }

        public string Nume { get { return _nume; } set { _nume = value; } }
        public string Prenume { get { return _prenume; } set { _prenume =value; } }
        public int Varsta { get { return _varsta; } set { _varsta = value; } }
    
        public override string ToString()
        {
            return "Persoana";
        }
    }
}
