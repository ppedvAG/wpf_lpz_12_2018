using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Books.Models
{
    public static class FavoriteManager
    {
        public static ObservableCollection<Book> FavoriteBooks;

        public const string File_Name = "favorites.fb";


        //Statischer Konstruktor
        static FavoriteManager()
        {
            if(!File.Exists(File_Name))
            {
                FavoriteBooks = new ObservableCollection<Book>();
            }
            else
            {
                using (StreamReader reader = new StreamReader(File_Name))
                {
                    string jsonString = reader.ReadToEnd();
                    FavoriteBooks = JsonConvert.DeserializeObject<ObservableCollection<Book>>(jsonString);
                }
            }

            FavoriteBooks = FavoriteBooks ?? new ObservableCollection<Book>();
        }

        public static bool CheckIsFavorite(Book book)
        {
            if (FavoriteBooks.Any(b => b.ID == book.ID))
            {
                return true;
            }
            return false;
        }


        public static void AddBook(Book book)
        {
            //Buch nicht als Favorit hinzufügen, wenn es bereits ein Favorit ist
            if(CheckIsFavorite(book))
            {
                return;
            }

            book.IsFavorite = true;
            FavoriteBooks.Add(book);

            SaveFavorites();
        }

        public static void RemoveBook(Book book)
        {
            Book bookToDelete = FavoriteBooks.SingleOrDefault(b => b.ID == book.ID);
            if(bookToDelete != null)
            {
                FavoriteBooks.Remove(bookToDelete);
                book.IsFavorite = false;

                SaveFavorites();
            }
        }

        public static void SaveFavorites()
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(FavoriteBooks);

                using (StreamWriter writer = new StreamWriter(File_Name))
                {
                    writer.Write(jsonString);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }
        }
    }
}