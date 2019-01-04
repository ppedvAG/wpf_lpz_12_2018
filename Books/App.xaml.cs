using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Books
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
    }

    //Erweiterungsmethoden
    public static class Erweiterungsmethoden
    {
        public static int Quersumme(this int zahl)
        {
            string zahlAlsString = zahl.ToString();
            int summe = 0;
            foreach (char item in zahlAlsString)
            {
                summe += (int)item;
            }
            return summe;
        }

        public static void ZeigeItems(this DataGrid grid)
        {
            //MessageBox.Show(grid.Items.Count.ToString());
        }
    }
}
