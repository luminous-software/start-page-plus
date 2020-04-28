using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;

    public class SettingsOptions : BaseOptionModel<SettingsOptions>
    {
        [Category(Settings)]
        [DisplayName(Constants.PageConstants.MaxWidth)]
        [Description("Sets the max width of the window's contents")]
        public int MaxWidth { get; } = 1175;
    }
}