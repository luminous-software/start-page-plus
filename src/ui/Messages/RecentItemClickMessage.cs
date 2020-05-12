using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.Messages
{
    using ViewModels;

    public class RecentItemClickMessage : NotificationMessage<RecentItemViewModel>
    {
        public RecentItemClickMessage(RecentItemViewModel sender, string notification) : base(sender, notification)
        { }
    }
}