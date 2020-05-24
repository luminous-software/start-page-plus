using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemSelectedMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemSelectedMessage(RecentItemViewModel sender) : base(sender, "")
        { }
    }
}