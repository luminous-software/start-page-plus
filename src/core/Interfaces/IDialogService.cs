using System;

using Button = System.Windows.MessageBoxButton;
using Icon = System.Windows.MessageBoxImage;
using Result = System.Windows.MessageBoxResult;

namespace StartPagePlus.Core.Interfaces
{
    public interface IDialogService
    {
        Result ShowMessage(string message, string title = null, Button button = Button.OK, Icon icon = Icon.None);

        void ShowMessage(string message);

        void ShowExclamation(string message);

        void ShowWarning(string error);

        void ShowError(string error);

        void ShowError(Exception error, bool extendedMessage = true);

        Result ShowConfirm(string question, string title = null, Button button = Button.YesNo);

        bool Confirmed(string question);
    }
}