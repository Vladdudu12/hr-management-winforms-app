using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_management_app
{
    internal class Angajat : Persoana, ICloneable, IComparable<Angajat>
    {
        private int _id = 0;
        private int[] _nrOreLucrateSaptamanal;
        private Job _job;
        private List<Feedback> _feedbacks = new List<Feedback>();
        private List<Concediu> _concedii = new List<Concediu>();

        public Angajat() { }
        public Angajat(int id, int[] nrOreLucrateSaptamanal, Job job, List<Feedback> feedbacks, List<Concediu> concedii, string nume, string prenume, int varsta) : base(nume, prenume, varsta)
        { 
            _id = id;
            _nrOreLucrateSaptamanal = new int[nrOreLucrateSaptamanal.Length];
            for(int i =0; i<_nrOreLucrateSaptamanal.Length; i++)
            {
                _nrOreLucrateSaptamanal[i] = nrOreLucrateSaptamanal[i];
            }

            _job = job;

            foreach(Feedback f in feedbacks)
            {
                _feedbacks.Add(f);
            }
            foreach (Concediu c in concedii)
            {
                _concedii.Add(c);
            }
        }

        public int Id { get { return _id; }  set { _id = value; } }
        public int[] NrOreLucrateSaptamanal { 
            get 
            { 
                return _nrOreLucrateSaptamanal; 
            } 
            set 
            { 
                if (value.Length > 0) 
                {
                    _nrOreLucrateSaptamanal = new int[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        _nrOreLucrateSaptamanal[i] = value[i];
                    }           
                } 
            } 
        }
        public Job Job { get { return _job; }  set { _job = value; } }
        public List<Feedback> Feedbacks { 
            get { return _feedbacks; } 
            set 
            {
                if (value.Count > 0)
                {
                    _feedbacks.Clear();
                    foreach(var f in value)
                    {
                        _feedbacks.Add(f);
                    }
                }
            } 
        } 
        public List<Concediu> Concedii
        {
            get { return _concedii; }
            set
            {
                if (value.Count > 0)
                {
                    _concedii.Clear();
                    foreach (var c in value)
                    {
                        _concedii.Add(c);
                    }
                }
            }
        }

        public object Clone()
        {
            Angajat a = new Angajat();
            a.Id = _id;
            a.NrOreLucrateSaptamanal = new int[_nrOreLucrateSaptamanal.Length];
            for(int i = 0; i < a.NrOreLucrateSaptamanal.Length; i++)
            {
                a.NrOreLucrateSaptamanal[i] = _nrOreLucrateSaptamanal[i];
            }

            a.Job = _job;

            foreach (Feedback f in _feedbacks)
            {
                a.Feedbacks.Add(f);
            }
            foreach (Concediu c in _concedii)
            {
                a.Concedii.Add(c);
            }

            return a;
        }

        public int CompareTo(Angajat other)
        {
            int totalOreLucrateThis = 0;
            int totalOreLucrateOther = 0;

            for (int i = 0; i < _nrOreLucrateSaptamanal.Length; i++)
            {
                totalOreLucrateThis += _nrOreLucrateSaptamanal[i];
            }

            for (int i = 0; i < other.NrOreLucrateSaptamanal.Length; i++)
            {
                totalOreLucrateOther += other.NrOreLucrateSaptamanal[i];
            }

            if (totalOreLucrateThis > totalOreLucrateOther)
            {
                return 1;
            }
            else if (totalOreLucrateThis == totalOreLucrateOther)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " Angajat cu jobul " + _job.ToString();
        }

    }
}
