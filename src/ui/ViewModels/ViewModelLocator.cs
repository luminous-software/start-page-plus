using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace StartPagePlus.UI.ViewModels
{
    using ViewModels.MainControl;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var container = SimpleIoc.Default;

            ServiceLocator.SetLocatorProvider(() => container);


            container.Register<MainControlViewModel>();
        }

        public static MainControlViewModel MainControlViewModel
            => ServiceLocator.Current.GetInstance<MainControlViewModel>();


    }
}