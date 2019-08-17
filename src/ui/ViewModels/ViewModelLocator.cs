using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace StartPagePlus.UI.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var container = SimpleIoc.Default;

            ServiceLocator.SetLocatorProvider(() => container);

            container.Register<StartViewModel>();
            container.Register<MainViewModel>();
        }

        public static MainViewModel MainViewModel
            => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static StartViewModel StartViewModel
            => ServiceLocator.Current.GetInstance<StartViewModel>();
    }
}