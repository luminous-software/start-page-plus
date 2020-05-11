
using System;
using System.Windows;

using Luminous.Code.Extensions.StringExtensions;

using static System.Environment;

using Button = System.Windows.MessageBoxButton;
using Icon = System.Windows.MessageBoxImage;
using Result = System.Windows.MessageBoxResult;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    public class DialogService : IDialogService
    {
        public void ShowMessage(string message, string title, string buttonText)
            => MessageBox.Show(message, title);

        public void ShowError(string errorMessage, string title, string buttonText)
        { }

        public void ShowError(Exception error, string title, string buttonText)
        { }

        private Result DisplayMessage(string title = null, string message = "", Button button = Button.OK, Icon icon = Icon.None)
            => MessageBox.Show(message, title, button, icon);

        private bool DisplayQuestion(string title = null, string messageText = null, string questionText = "")
        {
            var message = messageText.JoinWith(questionText, separator: NewLine + NewLine);

            return (DisplayMessage(title: title ?? "Question", message: message,
                button: Button.YesNo, icon: Icon.Question) == Result.Yes);
        }

        private bool DisplayConfirm(string title = null, string messageText = null, string questionText = "")
        {
            var message = messageText.JoinWith(questionText, separator: NewLine + NewLine);

            return (DisplayMessage(title: title ?? "Please Confirm", message: message,
                button: Button.YesNoCancel, icon: Icon.Warning) == Result.Yes);
        }

        //public Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        //    => throw new NotImplementedException();

        //public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        //    => throw new NotImplementedException();

        //public Task ShowMessage(string message, string title)
        //    => throw new NotImplementedException();

        //public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        //    => throw new NotImplementedException();

        //public Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        //    => throw new NotImplementedException();

        //public Task ShowMessageBox(string message, string title)
        //    => throw new NotImplementedException();
    }
}