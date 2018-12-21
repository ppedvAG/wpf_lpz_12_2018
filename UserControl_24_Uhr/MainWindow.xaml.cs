using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControl_24_Uhr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Timezone> Zeitzonen;

        public MainWindow()
        {
            InitializeComponent();
            Zeitzonen = new ObservableCollection<Timezone>()
            {
                new Timezone("Berlin", 0),
                new Timezone("Moskau", 2),
                new Timezone("Tokyo", 8),
                new Timezone("New York", -4)
            };

            this.DataContext = Zeitzonen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            uhr.MoveTimeForward = false;
        }
    }

    public class Timezone : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;

        private int _offset;

        public Timezone(string name, int offset)
        {
            Name = name;
            Offset = offset;
        }


        public TimeSpan CurrentTime
        {
            get
            {
                DateTime currentTime = DateTime.Now;
                return new TimeSpan(currentTime.Hour + Offset, currentTime.Minute, currentTime.Second);
            }
        }

        public int Offset
        {
            get { return _offset; }
            set { _offset = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public Timezone()
        {

        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
    }
}
