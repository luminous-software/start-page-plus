using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemOpenInVSClickedMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemOpenInVSClickedMessage(RecentItemViewModel sender) : base(sender, "")
        { }
    }
}