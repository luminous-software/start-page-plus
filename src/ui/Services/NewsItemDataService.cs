using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StartPagePlus.UI.Services
{
    using ViewModels;

    public class NewsItemDataService : INewsItemDataService
    {
        private const string ITEM_ELEMENT_NAME = "item";
        private const string NO_ANGLE_BRACKETS_AND_NO_EXTENSION = "<.*?>|&.*?;";

        private const string TITLE_ELEMENT_NAME = "title";
        private const string DESCRIPTION_ELEMENT_NAME = "description";
        private const string LINK_ELEMENT_NAME = "link";
        private const string PUB_DATE_ELEMENT_NAME = "pubDate";

        public async Task<ObservableCollection<NewsItemViewModel>> GetItemsAsync(string feedUrl)
        {
            //https://wp.qmatteoq.com/?p=6486
            //https://blog.qmatteoq.com/the-mvvm-pattern-dependency-injection/

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(feedUrl);
                var document = XDocument.Parse(response);
                var viewModels = (
                    from item in document.Descendants(ITEM_ELEMENT_NAME)
                    select new NewsItemViewModel
                    {
                        Title = ExtractTitle(item),
                        Description = ExtractDescription(item),
                        Link = ExtractLink(item),
                        PublishDate = ExtractPublishDate(item)
                    }
                ).ToList();

                return new ObservableCollection<NewsItemViewModel>(viewModels);
            }
        }

        private string ExtractTitle(XElement item)
            => (string)item.Element(TITLE_ELEMENT_NAME);

        private string ExtractDescription(XElement item)
            => Regex.Replace((string)item.Element(DESCRIPTION_ELEMENT_NAME),
                NO_ANGLE_BRACKETS_AND_NO_EXTENSION,
                string.Empty);

        private string ExtractLink(XElement item)
            => (string)item.Element(LINK_ELEMENT_NAME);

        private DateTime ExtractPublishDate(XElement item)
        {
            var elementValue = (string)item.Element(PUB_DATE_ELEMENT_NAME);

            DateTime.TryParse(elementValue, out var result);

            return result;
        }
    }
}