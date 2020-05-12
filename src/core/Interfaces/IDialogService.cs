using System;

namespace StartPagePlus.Core.Interfaces
{
    public interface IDialogService
    {
        void ShowMessage(string message, string title, string buttonText = "");

        void ShowError(string errorMessage, string title, string buttonText = "");

        void ShowError(Exception error, string title, string buttonText = "");
    }
}