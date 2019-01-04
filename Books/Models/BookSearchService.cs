using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class BookSearchService
    {
        public async static Task<ObservableCollection<Book>> SearchBooks(string searchTerm)
        {

            HttpClient client = new HttpClient();
            string jsonString = await client.GetStringAsync("https://www.googleapis.com/books/v1/volumes?q=" + searchTerm);

            var result = JsonConvert.DeserializeObject<GoogleBooksResult>(jsonString);

            ObservableCollection<Book> books = new ObservableCollection<Book>();

            //riesige Datenmenge simulieren
            for (int i = 0; i < 100000; i++)
            {
                foreach (var item in result.items)
                {
                    Book newBook = new Book();
                    newBook.ID = item.id;
                    newBook.Title = item.volumeInfo.title;
                    newBook.PreviewLink = item.volumeInfo.previewLink;
                    newBook.PageCount = item.volumeInfo.pageCount;
                    newBook.Rating = item.volumeInfo.averageRating;
                    newBook.CoverURL = item.volumeInfo.imageLinks?.smallThumbnail;
                    newBook.Authors = item.volumeInfo.authors;

                    //Ist es bereits ein Favorit?
                    if (FavoriteManager.CheckIsFavorite(newBook))
                    {
                        newBook.IsFavorite = true;
                    }

                    books.Add(newBook);
                }
            }
           

            return books;
        }
    }
}