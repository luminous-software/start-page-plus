using System.Collections.ObjectModel;
using System.Windows.Controls;

using GalaSoft.MvvmLight.Command;

using Luminous.Code.VisualStudio.Packages;

namespace StartPagePlus.UI.ViewModels
{

    using Core.Interfaces;

    using Interfaces;

    using Messages;

    using Options.Models;
    using Options.Pages;

    public class RecentItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Open a Recent Item";

        private ObservableCollection<RecentItemViewModel> items = new ObservableCollection<RecentItemViewModel>();
        private RecentItemViewModel selectedItem;
        private bool refreshed;

        public RecentItemsViewModel(
            IRecentItemDataService dataService,
            IRecentItemActionService actionService,
            IRecentItemCommandService commandService,
            IRecentItemContextMenuService contextMenuService,
            IDialogService dialogService
            )
            : base()
        {
            DataService = dataService;
            ActionService = actionService;
            CommandService = commandService;
            ContextMenuService = contextMenuService;
            DialogService = dialogService;
            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();

            MessengerInstance.Register<RecentItemsRefreshRequestedMessage>(this, RefreshRequested);
            MessengerInstance.Register<RecentItemClickedMessage>(this, SelectItem);
            MessengerInstance.Register<RecentItemTogglePinnedClickedMessage>(this, TogglePinned);
            MessengerInstance.Register<RecentItemRemoveClickedMessage>(this, RemoveItem);
            MessengerInstance.Register<RecentItemCopyPathClickedMessage>(this, CopyItemPath);
            MessengerInstance.Register<RecentItemOpenInVSClickedMessage>(this, OpenInVS);
        }

        public IRecentItemContextMenuService ContextMenuService { get; }

        public IRecentItemActionService ActionService { get; }

        public IRecentItemDataService DataService { get; }

        public IRecentItemCommandService CommandService { get; }

        public IDialogService DialogService { get; }

        public ObservableCollection<RecentItemViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        public RecentItemViewModel SelectedItem
        {
            get => selectedItem;
            set => Set(ref selectedItem, value, nameof(SelectedItem));
        }

        public bool Refreshed
        {
            get => refreshed;
            set
            {
                if (Set(ref refreshed, value, nameof(Refreshed)) && (value == true))
                {
                    MessengerInstance.Send(new RecentItemsRefreshClickedMessage());
                }
            }
        }

        public void OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (SelectedItem == null)
            {
                e.Handled = true; //suppress empty menu
            }

            GetContextCommands();
        }

        public void OnContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            // don't set SelectedItem = null in this method, doing so causes the context menu to be empty
        }

        protected override void RaiseCanExecuteChanged()
        {
            base.RaiseCanExecuteChanged();

            foreach (var command in ContextCommands)
            {
                var name = command.Name;
                var relayCommand = (RelayCommand)command.Command;

                switch (name)
                {
                    case nameof(PinItem):
                    case nameof(UnpinItem):
                    case nameof(RemoveItem):
                    case nameof(CopyItemPath):
                    case nameof(OpenInVS):
                        relayCommand.RaiseCanExecuteChanged();
                        break;

                    default:
                        break;
                }
            }
        }

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh, OpenSettings);

        private void GetContextCommands()
            => ContextCommands = CommandService.GetContextCommands(
                CanPinItem, PinItem,
                CanUnpinItem, UnpinItem,
                CanRemoveItem, RemoveItem,
                CanCopyItemPath, CopyItemPath,
                CanOpenInVS, OpenInVS);
        private void SelectItem(RecentItemClickedMessage message)
            => ActionService.ExecuteAction(message.Content);

        private void TogglePinned(RecentItemTogglePinnedClickedMessage message)
        {
            var item = message.Content;

            switch (item.Pinned)
            {
                case true:
                    UnpinItem(item);
                    break;

                case false:
                    PinItem(item);
                    break;
            }

            Refresh();
        }

        private bool CanPinItem
            => (SelectedItem?.Pinned == false);

        private void PinItem()
            => PinItem(SelectedItem);

        private void PinItem(RecentItemViewModel item)
        {
            if (!ContextMenuService.PinItem(item))
            {
                DialogService.ShowExclamation($"Unable to pin '{item?.Name}'");
            }
            Refresh();
        }

        private bool CanUnpinItem
            => (SelectedItem?.Pinned == true);

        private void UnpinItem()
            => UnpinItem(SelectedItem);

        private void UnpinItem(RecentItemViewModel item)
        {
            if (!ContextMenuService.UnpinItem(item))
            {
                DialogService.ShowExclamation($"Unable to unpin '{item?.Name}'");
            }
            Refresh();
        }

        private bool CanRemoveItem
            => (SelectedItem != null);

        private void RemoveItem(RecentItemRemoveClickedMessage message)
        {
            var item = message.Content;

            RemoveItem(item);
        }

        private void RemoveItem()
        => RemoveItem(SelectedItem);

        private void RemoveItem(RecentItemViewModel item)
        {
            if (!ContextMenuService.RemoveItem(item))
            {
                DialogService.ShowExclamation($"Unable to remove '{item?.Name}'");
            }
            Refresh();
        }

        private bool CanCopyItemPath
            => (SelectedItem != null);

        private void CopyItemPath(RecentItemCopyPathClickedMessage message)
        {
            var item = message.Content;

            if (!CopyItemPath(item))
            {
                DialogService.ShowExclamation($"Unable to copy path of '{item?.Name}'");
            }
        }

        private void CopyItemPath()
            => CopyItemPath(SelectedItem);

        private bool CopyItemPath(RecentItemViewModel item)
            => ContextMenuService.CopyItemPath(item);

        private bool CanOpenInVS
            => (SelectedItem != null);

        private void OpenInVS(RecentItemOpenInVSClickedMessage message)
        {
            var item = message.Content;

            Refresh();

            if (!OpenInVS(item))
            {
                DialogService.ShowExclamation($"Unable to launch '{item?.Name}' in a new instance of VS");
            }
        }

        private void OpenInVS()
            => OpenInVS(SelectedItem);

        private bool OpenInVS(RecentItemViewModel item)
            => ContextMenuService.OpenInVS(item);

        private void Refresh()
        {
            Refreshed = false;
            SelectedItem = null;

            var options = RecentItemsOptions.Instance;
            var itemsToDisplay = options.ItemsToDisplay;
            var showExtensions = options.ShowFileExtensions;
            var items = DataService.GetItems(itemsToDisplay, showExtensions);

            Items.Clear();

            foreach (var item in items)
            {
                Items.Add(item);
            }

            Refreshed = true;
        }

        private void RefreshRequested(RecentItemsRefreshRequestedMessage message)
            => Refresh();

        private void OpenSettings()
            => AsyncPackageBase.Instance.ShowOptionsPage<DialogPageProvider.RecentItems>();
    }
}