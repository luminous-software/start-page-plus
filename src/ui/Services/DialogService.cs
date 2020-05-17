
using System;
using System.Windows;

using Luminous.Code.Extensions.ExceptionExtensions;

using Button = System.Windows.MessageBoxButton;
using Icon = System.Windows.MessageBoxImage;
using Result = System.Windows.MessageBoxResult;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    public class DialogService : IDialogService
    {
        public Result ShowMessage(string message, string title = null, Button button = Button.OK, Icon icon = Icon.None)
            => MessageBox.Show(message, title ?? Vsix.Name, button, icon);

        public void ShowMessage(string message)
            => ShowMessage(message, title: "Warning", button: Button.OK, icon: Icon.Exclamation);

        public void ShowExclamation(string message)
            => ShowMessage(message, title: "Warning", button: Button.OK, icon: Icon.Exclamation);

        public void ShowWarning(string error)
            => ShowMessage(error, title: "Warning", button: Button.OK, icon: Icon.Warning);

        public void ShowError(string error)
            => ShowMessage(error, title: "Error", button: Button.OK, icon: Icon.Error);

        public void ShowError(Exception error, bool extendedMessage = true)
            => ShowError(extendedMessage ? error.ExtendedMessage() : error.Message);

        public Result ShowConfirm(string question, string title = null, Button button = Button.YesNo)
            => ShowMessage(question, title: title ?? "Please Confirm", button, icon: Icon.Question);

        public bool Confirmed(string question)
            => (ShowConfirm(question) == Result.Yes);

        //public Task ShowErrorAsync(string message, string title, string buttonText, Action afterHideCallback)
        //    => throw new NotImplementedException();

        //public Task ShowErrorAsync(Exception error, string title, string buttonText, Action afterHideCallback)
        //    => throw new NotImplementedException();

        //public Task ShowMessageAsync(string message, string title)
        //    => throw new NotImplementedException();

        //public Task ShowMessageAsync(string message, string title, string buttonText, Action afterHideCallback)
        //    => throw new NotImplementedException();

        //public Task<bool> ShowMessageAsync(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        //    => throw new NotImplementedException();
    }
}