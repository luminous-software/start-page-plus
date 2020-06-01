using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemClickedMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemClickedMessage(RecentItemViewModel sender) : base(sender, "")
        { }
    }
}