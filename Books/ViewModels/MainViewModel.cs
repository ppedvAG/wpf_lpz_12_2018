using Books.Helper;
using Books.Models;
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
            SearchCommand = new DelegateCommand((object p) => { SearchBooks(); }, p => !string.IsNullOrWhiteSpace(SearchTerm));
            FavoriteCommand = new DelegateCommand(p => ShowFavorites());
        }

        public async void SearchBooks()
        {
            MessageBox.Show("Suche bücher für " + SearchTerm);
            try
            {
                var books = await BookSearchService.SearchBooks(SearchTerm);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }
        }

        public void ShowFavorites()
        {

        }
    }
}
