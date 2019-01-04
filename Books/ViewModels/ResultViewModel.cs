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

        private string _header = "Test";
        public string Header
        {
            get { return _header; }
            set { SetValue(ref _header, value); }
        }


        public DelegateCommand AddFavoriteCommand { get; set; }
        public DelegateCommand RemoveFavoriteCommand { get; set; }

        public ResultViewModel(ObservableCollection<Book> books, string header)
        {
            AddFavoriteCommand = new DelegateCommand(AddBookAsFavorite, CanAdd);
            RemoveFavoriteCommand = new DelegateCommand(RemoveBookAsFavorite, o => !CanAdd(o));

            Books = books;
            Header = header;
        }

      
        //Prüfunng ob AddFavoriteCommand ausgeführt werden kann
        private bool CanAdd(object arg)
        {
            if(arg is Book book)
            {
                return !book.IsFavorite;
            }
            return true;
        }

        public ResultViewModel()
        {
            //Testdaten anlegen
            Books = new ObservableCollection<Book>()
            {
                new Book()
                {
                    ID = "44",
                    Title = "WPF For Dummies",
                    Rating = 4,
                    CoverURL = "http://books.google.com/books/content?id=DwPC71448KEC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                    PageCount = 200,
                    Authors = new string[] {"Henry", "Alex"}
                }
            };
        }

        private void RemoveBookAsFavorite(object obj)
        {
            if(obj is Book book)
            {
                FavoriteManager.RemoveBook(book);
            }
        }

        public void AddBookAsFavorite(object obj)
        {
            if(obj is Book book)
            {
                FavoriteManager.AddBook(book);
            }
        }
    }
}