using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemCopyPathMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemCopyPathMessage(RecentItemViewModel sender) : base(sender, "")
        { }
    }
}