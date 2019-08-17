namespace StartPagePlus.UI.ViewModels
{
    public class StartViewModel : TabViewModel
    {
        public StartViewModel() : base()
        {
            Name = "Start";
            Title = "Hi User, what would you like to do today?";
            IsVisible = true;
        }
    }
}