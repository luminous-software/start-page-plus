namespace StartPagePlus.UI.Observables
{
    using ViewModels;

    public class ObservableContextCommandList : ObservableList<ContextCommandViewModel>
    {
        public ObservableContextCommandList() : base()
        { }

        public override int VisibleCount
            => base.FindAll(i => i.IsVisible).Count;
    }
}