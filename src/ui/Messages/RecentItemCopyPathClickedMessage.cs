using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemCopyPathClickedMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemCopyPathClickedMessage(RecentItemViewModel sender) : base(sender, "")
        { }
    }
}