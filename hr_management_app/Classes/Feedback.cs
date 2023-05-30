using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_management_app
{
    public class Feedback
    {
        private string _detalii;
        private DateTime _data;

        public Feedback(string detalii, DateTime data)
        {
            _detalii = detalii;
            _data = data;
        }

        public string Detalii { get { return _detalii; } set { _detalii = value; } }
        public DateTime Data { get { return _data;} set { _data = value; } }

        public override string ToString()
        {
            return "Data";
        }
    }
}
