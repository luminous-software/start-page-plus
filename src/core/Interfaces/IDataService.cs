using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartPagePlus.Core.Interfaces
{
    using Models;

    public interface IDataService
    {
        Task<List<FeedItem>> GetItemsAsync(string url, int count);
    }
}