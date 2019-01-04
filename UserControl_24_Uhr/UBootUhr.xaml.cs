using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UserControl_24_Uhr
{
    /// <summary>
    /// Interaction logic for UBootUhr.xaml
    /// </summary>
    public partial class UBootUhr : UserControl
    {

        //Dependency Property: propdp (Snippet)

        private bool _moveTimeForward = true;
        public bool MoveTimeForward
        {
            get
            {
                return _moveTimeForward;
            }
            set
            {
                _moveTimeForward = value;
                if(_moveTimeForward == false)
                {
                    _cts?.Cancel();
                }
            }
        }





        public Style BorderStyle
        {
            get { return (Style)GetValue(BorderStyleProperty); }
            set { SetValue(BorderStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderStyleProperty =
            DependencyProperty.Register("BorderStyle", typeof(Style), typeof(UBootUhr), new PropertyMetadata(null));




        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(TimeSpan), typeof(UBootUhr), new PropertyMetadata(TimeSpan.Zero, TimeChanged));

        private static void TimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UBootUhr uhr)
            {
                //Hole die Stunden aus dem neu zugewiesenen DateTime-Objekts
                double newAngle = (((TimeSpan)e.NewValue).Hours * 15) + 180;

                DoubleAnimation animation = new DoubleAnimation(uhr.borderRotate.Angle, newAngle, new Duration(TimeSpan.FromMilliseconds(400)), FillBehavior.Stop);
                uhr.borderRotate.BeginAnimation(RotateTransform.AngleProperty, animation);



                uhr.borderRotate.Angle = newAngle;
            }
        }

        CancellationTokenSource _cts;

        //Hilfsklassen für Multithreading:
        //DispatcherTimer _timer;
        //BackgroundWorker worker = new BackgroundWorker();

      

        public UBootUhr()
        {
            InitializeComponent();

            BorderStyle = this.Resources["generalStyle"] as Style;

            _cts = new CancellationTokenSource();

            Task.Factory.StartNew(() =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    borderRotate.Dispatcher.Invoke(() =>
                    {
                        Time = Time.Add(TimeSpan.FromHours(1));
                    });
                }
            });
        }

        ~UBootUhr()
        {
            _cts.Cancel();
        }

    }
}
