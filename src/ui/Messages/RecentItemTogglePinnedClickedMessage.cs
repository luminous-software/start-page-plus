using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemTogglePinnedClickedMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemTogglePinnedClickedMessage(RecentItemViewModel sender) : base(sender, "")
        { }
    }
}