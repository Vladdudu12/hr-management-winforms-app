using hr_management_app.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_management_app
{
    public class Job: ICalculabil
    {
        private string _denumire;
        private float _salariuBaza;
        private int _nrOreSaptamana;
        
        public Job() { }

        public Job(string denumire, float salariuBaza, int nrOreSaptamana) 
        {
            _denumire = denumire;
            _salariuBaza = salariuBaza;
            _nrOreSaptamana = nrOreSaptamana;
        }

        public string Denumire { get { return _denumire; } set { _denumire = value; } }
        public float SalariuBaza { get { return _salariuBaza; } set { _salariuBaza = value; } }
        public int NrOreSaptamana { get { return _nrOreSaptamana; } set { _nrOreSaptamana = value; } }

        public float CalculSalariuOra()
        {
            return _salariuBaza / _nrOreSaptamana;
        }

        public override string ToString()
        {
            return "Job";
        }

    }
}
