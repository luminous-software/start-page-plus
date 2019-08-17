using StartPagePlus.Core.Interfaces;

namespace StartPagePlus.UI.Models
{
    public class ModelBase : IModel
    {
        public string Name { get; set; }
        public bool IsVisible { get; set; }
    }
}
