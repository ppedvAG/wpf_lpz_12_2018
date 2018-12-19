using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplates
{
    public class Maschine
    {
        public enum RotationClasses { High, Medium, Low } 

        private string _hersteller;

        public string Hersteller
        {
            get { return _hersteller; }
            set { _hersteller = value; }
        }

        private bool _lieferbar;

        public bool Lieferbar
        {
            get { return _lieferbar; }
            set { _lieferbar = value; }
        }

        private RotationClasses _rotationClass;

        public RotationClasses RotationClass
        {
            get { return _rotationClass; }
            set { _rotationClass = value; }
        }

        
    }
}
