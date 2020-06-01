using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemRemoveClickedMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemRemoveClickedMessage(RecentItemViewModel sender) : base(sender, "")
        { }
    }
}