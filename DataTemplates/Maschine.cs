using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplates
{
    public class Maschine : INotifyPropertyChanged
    {
        public enum RotationClasses { High, Medium, Low }

        public event PropertyChangedEventHandler PropertyChanged;

        public static Array RotationClassesValues = Enum.GetValues(typeof(RotationClasses));

        private string _hersteller;
        public string Hersteller
        {
            get { return _hersteller; }
            set
            {
                _hersteller = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hersteller)));
            }
        }

        private bool _lieferbar;
        public bool Lieferbar
        {
            get { return _lieferbar; }
            set { _lieferbar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lieferbar)));
            }
        }

        private RotationClasses _rotationClass;
        public RotationClasses RotationClass
        {
            get { return _rotationClass; }
            set { _rotationClass = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RotationClass)));
            }
        }


        private DateTime? _lieferDatum;
        public DateTime? LieferDatum
        {
            get { return _lieferDatum; }
            set { _lieferDatum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LieferDatum)));
            }
        }

        public Maschine()
        {

        }

        public Maschine(string hersteller, bool lieferbar = false, DateTime? lieferDatum = null, RotationClasses rotationClass = RotationClasses.Medium)
        {
            Hersteller = hersteller;
            Lieferbar = lieferbar;
            RotationClass = rotationClass;
            LieferDatum = lieferDatum;
        }
    }
}
