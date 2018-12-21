using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class GoogleBooksResult
    {
        public Item[] items { get; set; }
    }

    public class Item
    {
       public string id { get; set; }
       public Volumeinfo volumeInfo { get; set; }
    }

    public class Volumeinfo
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public int pageCount { get; set; }
        public Imagelinks imageLinks { get; set; }
        public string previewLink { get; set; }
        public float averageRating { get; set; }
    }

    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
    }
}
