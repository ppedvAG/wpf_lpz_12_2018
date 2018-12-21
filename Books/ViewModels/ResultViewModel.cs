using Books.Helper;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.ViewModels
{
    public class ResultViewModel : ModelBase
    {
        private ObservableCollection<Book>  _books  ;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { SetValue(ref _books, value); }
        }

        public DelegateCommand AddFavoriteCommand { get; set; }
        public DelegateCommand RemoveFavoriteCommand { get; set; }

        public ResultViewModel()
        {
            AddFavoriteCommand = new DelegateCommand(AddBookAsFavorite);
            RemoveFavoriteCommand = new DelegateCommand(RemoveBookAsFavorite);
        }

        private void RemoveBookAsFavorite(object obj)
        {
            throw new NotImplementedException();
        }

        public void AddBookAsFavorite(object obj)
        {
            throw new NotImplementedException();
        }
    }
}