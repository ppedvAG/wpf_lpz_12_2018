using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validierung
{
    public class Person
    {

        private DateTime _geburtsdatum = new DateTime(1960, 2, 2);
        public DateTime Geburtsdatum
        {
            get { return _geburtsdatum; }
            set
            {
                if(value > DateTime.Now)
                {
                    throw new Exception("Datum in Zukunft!");
                }
                _geburtsdatum = value;
            }
        }

        private int _größe;

        public int Größe
        {
            get { return _größe; }
            set { _größe = value; }
        }
    }
}
