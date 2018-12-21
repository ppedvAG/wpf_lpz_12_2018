using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Validierung
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(sender is TextBox box)
            {
                
                if (box.Text.Length < 3 && (box.Tag as bool?) != true)
                {
                    Validation.SetErrorTemplate(box, null);
                    
                }
                else
                {
                    Validation.SetErrorTemplate(box, this.Resources["errorTemplate"] as ControlTemplate);
                    box.Tag = true;
                }
            }
        }
    }
}
