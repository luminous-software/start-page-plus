namespace StartPagePlus.UI.Observables
{
    using ViewModels;

    public class ObservableCommandList : ObservableList<CommandViewModel>
    {
        public ObservableCommandList() : base()
        { }

        public override int VisibleCount
            => base.FindAll(i => i.IsVisible).Count;
    }
}