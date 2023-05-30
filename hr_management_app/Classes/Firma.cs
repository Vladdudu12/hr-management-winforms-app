using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_management_app.Classes
{
    internal class Firma
    {

        private string _denumire;
        private List<Angajat> _angajati = new List<Angajat>();

        public Firma(string denumire, List<Angajat> angajati)
        {
            _denumire = denumire;
            _angajati.AddRange(angajati);
        }

        public string Denumire
        {
            get { return _denumire; }
            set { _denumire = value; }
        }

        public List<Angajat> Angajati
        {
            get { return _angajati; }
            set 
            {
                if(value.Count > 0)
                {
                    _angajati.Clear();
                    _angajati.AddRange(value);
                }
            }
        }
    }
}
