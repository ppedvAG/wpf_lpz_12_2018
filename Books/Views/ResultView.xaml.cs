using Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Books.Views
{
    /// <summary>
    /// Interaction logic for ResultView.xaml
    /// </summary>
    public partial class ResultView : Window
    {
        public ResultView()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(sender is Image image)
            {
                string previewlink = image.Tag.ToString();
                Process.Start(previewlink);
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(DataContext is ResultViewModel model && sender is DataGrid grid) 
            {
                model.AddFavoriteCommand.Execute(grid.SelectedItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datagrid.ZeigeItems();
        }
    }
}
