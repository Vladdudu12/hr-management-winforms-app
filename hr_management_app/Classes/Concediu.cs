using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_management_app
{
    public class Concediu
    {
        private DateTime _dataInceput;
        private int _durata;

        public Concediu(DateTime dataInceput, int durata) 
        {
            _dataInceput = dataInceput;
            _durata = durata;
        }

        public DateTime DataInceput { get { return _dataInceput; } set { _dataInceput = value; } }
        public int Durata { get { return _durata; } set { _durata = value; } }

        public override string ToString()
        {
            return "Concediu";
        }
    }
}
