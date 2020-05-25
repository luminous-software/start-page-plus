using System;
using System.Windows;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using Interfaces;

    public class ClipboardService : IClipboardService
    {
        private readonly IDialogService dialogService;

        public ClipboardService(IDialogService dialogService)
            => this.dialogService = dialogService;

        public void CopyToClipboard(string path)
        {
            try
            {
                Clipboard.SetText(path);
            }
            catch (Exception ex)
            {
                dialogService.ShowError(ex);
            }
        }
    }
}