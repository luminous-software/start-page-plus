using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemPinnedOrUnpinnedMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemPinnedOrUnpinnedMessage(RecentItemViewModel sender) : base(sender, "")
        { }
    }
}