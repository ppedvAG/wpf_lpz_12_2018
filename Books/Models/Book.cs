using Books.Helper;

namespace Books.Models
{
    public class Book : ModelBase
    {
        private string _id;
        public string ID
        {
            get { return _id; }
            set { SetValue(ref _id, value); }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetValue(ref _title, value); }
        }

        private string[] _authors;

        public string[] Authors
        {
            get { return _authors; }
            set { SetValue(ref  _authors, value); }
        }

        private int _pageCount;

        public int PageCount
        {
            get { return _pageCount; }
            set { SetValue(ref _pageCount, value); }
        }

        private string _coverURL;

        public string CoverURL
        {
            get { return _coverURL; }
            set { SetValue(ref _coverURL, value); }
        }

        private string _previewLink;

        public string PreviewLink
        {
            get { return _previewLink; }
            set { SetValue(ref _previewLink, value); }
        }

        private float _rating;

        public float Rating
        {
            get { return _rating; }
            set { SetValue(ref _rating, value); }
        }

        private bool _isFavorite = false;

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set { SetValue(ref _isFavorite, value); }
        }

    }
}