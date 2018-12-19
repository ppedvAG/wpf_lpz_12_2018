using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Maschinenmanager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RotationClasses? _lastRotationValue = null;

        public MainWindow()
        {
            InitializeComponent();
            cleanButton.AddHandler(Button.PreviewMouseUpEvent,new MouseButtonEventHandler(Clean_Button_Click), true);
        }

        private void Erzeugen_Button_Click(object sender, RoutedEventArgs e)
        {
            string hersteller = tbHersteller.Text;
            bool lieferbar = (bool)cbLieferbar.IsChecked;
            double preis = sliderPreis.Value;

            //Interpolated Strings
            MessageBox.Show($"{hersteller} ({preis} Euro), Lieferbar: {lieferbar}, RotationClass: {_lastRotationValue}");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //OriginalSource steht für das Control, welches das Event initial geworfen hat
            if (e.OriginalSource is RadioButton rbutton)
            {
                if (rbutton.Content is RotationClasses classe)
                {
                    _lastRotationValue = classe;
                }
            }
        }

        int _clicks = 0;
        bool _cleaningMode = false;

        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _clicks++;
            this.Title = _clicks.ToString();
            e.Handled = _cleaningMode;
        }

        CancellationTokenSource _cts;

        private void Clean_Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if(_cleaningMode)
                {
                    //Cleaning-Modus abbrechen
                    _cts.Cancel();
                }
                else
                {
                    object startContent = button.Content;

                    _cts = new CancellationTokenSource();

                    Task.Factory.StartNew(() =>
                    {
                        _cleaningMode = true;
                        for (int i = 30; i > 0; i--)
                        {
                            if(_cts.Token.IsCancellationRequested)
                            {
                                break;
                            }
                            Thread.Sleep(1000);
                            button.Dispatcher.Invoke(() => button.Content = $"Verbleibende Zeit: {i}");
                        }
                        _cleaningMode = false;
                        button.Dispatcher.Invoke(() => button.Content = startContent);
                    });
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape && _cleaningMode)
            {
                _cts?.Cancel();
            }
        }
    }

    public enum RotationClasses
    {
        High, Middle, Low
    }
}
