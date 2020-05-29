using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemRemovedMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemRemovedMessage(RecentItemViewModel sender) : base(sender, "")
        { }
    }
}