using System;
using GalaSoft.MvvmLight;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class NewsItemViewModel : ViewModelBase, INewsItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        //public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}