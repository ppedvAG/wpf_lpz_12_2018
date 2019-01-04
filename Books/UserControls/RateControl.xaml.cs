using System;
using System.Collections.Generic;
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

namespace Books.UserControls
{
    /// <summary>
    /// Interaction logic for RateControl.xaml
    /// </summary>
    public partial class RateControl : UserControl
    {
        public float Rating
        {
            get { return (float)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register("Rating", typeof(float), typeof(RateControl), new PropertyMetadata(0f, RatingChanged));

        private static void RatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is RateControl control)
            {
                //Favoriten-Icons aktualisieren

                List<Stars> stars = new List<Stars>();
                //4.5
                float rating = control.Rating * 10;

                int anzahlSterne = (int)rating / 10;

                //Ganze Sterne hinzufügen
                for (int i = 0; i < anzahlSterne; i++)
                {
                    stars.Add(Stars.Full);
                }

                //Evtl. halber Stern
                if (rating % 10 >= 5)
                {
                    stars.Add(Stars.Half);
                }

                control.mainGrid.DataContext = stars;
            }
        }

        public RateControl()
        {
            InitializeComponent();
        }
    }

    public enum Stars { Full, Half }
}
