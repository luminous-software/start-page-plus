using System;

namespace StartPagePlus.UI.ViewModels
{
    using GalaSoft.MvvmLight;

    public class NewsItemViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}