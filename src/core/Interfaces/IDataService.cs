using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartPagePlus.Core.Interfaces
{
    public interface IDataService
    {
        Task<List<IDataItem>> GetItemsAsync(string url, int count);
    }
}