using GalaSoft.MvvmLight.Ioc;

namespace StartPagePlus.UI.ViewModels
{
    using Core.Interfaces;

    using Interfaces;   // TODO: why are these interfaces not in Core.Interfaces?

    using Services;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var container = SimpleIoc.Default;

            RegisterServices(container);
            RegisterViewModels(container);
        }

        public static MainViewModel MainViewModel
            => SimpleIoc.Default.GetInstance<MainViewModel>();

        public static StartViewModel StartViewModel
            => SimpleIoc.Default.GetInstance<StartViewModel>();

        public static RecentItemsViewModel RecentItemsViewModel
            => SimpleIoc.Default.GetInstance<RecentItemsViewModel>();

        public static StartActionsViewModel StartActionsViewModel
            => SimpleIoc.Default.GetInstance<StartActionsViewModel>();

        public static NewsItemsViewModel NewsItemsViewModel
            => SimpleIoc.Default.GetInstance<NewsItemsViewModel>();

        public static FavoritesViewModel FavoritesViewModel
            => SimpleIoc.Default.GetInstance<FavoritesViewModel>();

        public static CreateViewModel CreateViewModel
            => SimpleIoc.Default.GetInstance<CreateViewModel>();

        public static NewsViewModel NewsViewModel
            => SimpleIoc.Default.GetInstance<NewsViewModel>();

        public static void Initialise()
        {

        }

        private void RegisterServices(SimpleIoc container)
        {
            container.Register<IDialogService, DialogService>();
            container.Register<IVisualStudioService, VisualStudioService>();

            container.Register<IDateTimeService, DateTimeService>();

            container.Register<IRecentItemService, RecentItemService>();

            container.Register<IRecentItemDataService, RecentItemDataService>();
            container.Register<IRecentItemActionService, RecentItemActionService>();
            container.Register<IRecentItemCommandService, RecentItemCommandService>();

            container.Register<IStartActionDataService, StartActionDataService>();
            container.Register<IStartActionCommandService, StartActionCommandService>();

            container.Register<INewsItemDataService, NewsItemDataService>();
            container.Register<INewsItemActionService, NewsItemActionService>();
            container.Register<INewsItemCommandService, NewsItemCommandService>();
        }

        private void RegisterViewModels(SimpleIoc container)
        {
            container.Register<RecentItemsViewModel>();
            container.Register<StartActionsViewModel>();
            container.Register<NewsItemsViewModel>();
            container.Register<StartViewModel>();

            container.Register<FavoritesViewModel>();

            container.Register<CreateViewModel>();

            container.Register<NewsViewModel>();

            container.Register<MainViewModel>();
        }
    }
}