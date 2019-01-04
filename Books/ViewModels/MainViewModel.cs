using Books.Helper;
using Books.Models;
using Books.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Books.ViewModels
{
    public class MainViewModel : ModelBase
    {
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set { base.SetValue(ref _searchTerm, value); }
        }

        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand FavoriteCommand { get; set; }


        public MainViewModel()
        {

            //MessageBox.Show(12312321.Quersumme().ToString());

            SearchCommand = new DelegateCommand((object p) => { SearchBooks(); }, p => !string.IsNullOrWhiteSpace(SearchTerm));
            FavoriteCommand = new DelegateCommand(p => ShowFavorites(), p => FavoriteManager.FavoriteBooks.Count > 0);
        }

        public void SearchBooks()
        {
            //mit dieser Variante (ohne async/await) wird der GUI-Thread auch bei größter Belastung nicht blockiert
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var books = BookSearchService.SearchBooks(SearchTerm).Result;
                    //Der Code innerhalb des Invokes wird auf dem GUI-Thread ausgeführt
                    Application.Current.Dispatcher.Invoke(() =>
                    {

                        ResultView view = new ResultView();
                        view.DataContext = new ResultViewModel(books, "Suchergebnisse");
                        view.ShowDialog();
                    });
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                    return;
                }
            });
            
        }

        public void ShowFavorites()
        {
            ResultView view = new ResultView();
            view.DataContext = new ResultViewModel(FavoriteManager.FavoriteBooks, "Favoriten");
            view.ShowDialog();
        }
    }
}