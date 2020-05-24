using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemPinnedOrUnpinnedMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemPinnedOrUnpinnedMessage(RecentItemViewModel sender, string notification) : base(sender, notification)
        { }
    }
}