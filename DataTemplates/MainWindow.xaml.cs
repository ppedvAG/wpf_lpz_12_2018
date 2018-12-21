using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataTemplates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Maschine> _maschinenListe;

        public MainWindow()
        {
            InitializeComponent();

            //Startwerte generieren (z.B. aus Datenbank/Webservice/Datei)
            _maschinenListe = new ObservableCollection<Maschine>()
            {
                new Maschine("Geschirrspüler"),
                new Maschine("Kaffeemaschine"),
                new Maschine("Herd")
            };
            this.DataContext = _maschinenListe;
        }

        private void Button_Neu_Click(object sender, RoutedEventArgs e)
        {
            _maschinenListe.Add(new Maschine("..."));
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            int index = listbox1.SelectedIndex;
            if (index < 0)
                return;
     
            _maschinenListe.RemoveAt(index);
        }

        private void Button_Lieferstop_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _maschinenListe)
            {
                item.Lieferbar = false;
            }
        }
    }
}