using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;
    using Services;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var container = SimpleIoc.Default;

            ServiceLocator.SetLocatorProvider(() => container);

            RegisterServices(container);
            RegisterViewModels(container);
        }

        private void RegisterServices(SimpleIoc container)
        {
            container.Register<IRecentItemDataService, RecentItemDataService>();
            container.Register<IRecentItemActionService, RecentItemActionService>();
            container.Register<INewsItemDataService, NewsItemDataService>();


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

        public static MainViewModel MainViewModel
            => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static StartViewModel StartViewModel
            => ServiceLocator.Current.GetInstance<StartViewModel>();

        public static RecentItemsViewModel RecentItemsViewModel
            => ServiceLocator.Current.GetInstance<RecentItemsViewModel>();

        public static StartActionsViewModel StartActionsViewModel
            => ServiceLocator.Current.GetInstance<StartActionsViewModel>();

        public static NewsItemsViewModel NewsItemsViewModel
            => ServiceLocator.Current.GetInstance<NewsItemsViewModel>();

        public static FavoritesViewModel FavoritesViewModel
            => ServiceLocator.Current.GetInstance<FavoritesViewModel>();

        public static CreateViewModel CreateViewModel
            => ServiceLocator.Current.GetInstance<CreateViewModel>();

        public static NewsViewModel NewsViewModel
            => ServiceLocator.Current.GetInstance<NewsViewModel>();
    }
}