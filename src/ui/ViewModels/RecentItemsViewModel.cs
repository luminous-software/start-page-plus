using System.Collections.ObjectModel;
using System.Windows.Controls;

using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.ViewModels
{

    using Core.Interfaces;

    using Interfaces;

    using Messages;

    using Options.Models;

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
            IRecentItemService itemService,
            IDialogService dialogService
            )
            : base()
        {
            DataService = dataService;
            ActionService = actionService;
            CommandService = commandService;
            ItemService = itemService;
            DialogService = dialogService;
            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();

            MessengerInstance.Register<RecentItemsRefreshMessage>(this, RefreshRequested);
            MessengerInstance.Register<RecentItemSelectedMessage>(this, SelectItem);
            MessengerInstance.Register<RecentItemPinnedOrUnpinnedMessage>(this, PinOrUnpinItem);
            MessengerInstance.Register<RecentItemCopyPathMessage>(this, CopyItemPath);
        }

        public IRecentItemService ItemService { get; }

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
                    SelectedItem = null;
                    MessengerInstance.Send(new RecentItemsRefreshedMessage());
                }
            }
        }

        public void OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (SelectedItem == null)
            {
                e.Handled = true; //need to suppress empty menu
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
                        relayCommand.RaiseCanExecuteChanged();
                        break;

                    default:
                        break;
                }
            }
        }

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh);

        private void GetContextCommands()
            => ContextCommands = CommandService.GetContextCommands(
                CanPinItem, PinItem,
                CanUnpinItem, UnpinItem,
                CanRemoveItem, RemoveItem,
                CanCopyItemPath, CopyItemPath);

        private void SelectItem(RecentItemSelectedMessage message)
            => ActionService.ExecuteAction(message.Content);

        private void PinOrUnpinItem(RecentItemPinnedOrUnpinnedMessage message)
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
            if (!ItemService.PinItem(item))
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
            if (!ItemService.UnpinItem(item))
            {
                DialogService.ShowExclamation($"Unable to unpin '{item?.Name}'");
            }
            Refresh();
        }

        private bool CanRemoveItem
            => (SelectedItem != null);

        private void RemoveItem()
        {
            if (!ItemService.RemoveItem(SelectedItem))
            {
                DialogService.ShowMessage($"Unable to remove '{SelectedItem?.Name}'", Vsix.Name);
            }
            Refresh();
        }

        private bool CanCopyItemPath
            => (SelectedItem != null);

        private void CopyItemPath(RecentItemCopyPathMessage message)
        {
            var item = message.Content;

            CopyItemPath(item);
        }

        private void CopyItemPath()
        => CopyItemPath(SelectedItem);

        private void CopyItemPath(RecentItemViewModel item)
            => ItemService.CopyItemPath(item);

        private void Refresh()
        {
            Refreshed = false;

            var settingOptions = SettingOptions.Instance;
            var itemsToDisplay = settingOptions.RecentItemsToDisplay;
            var showExtensions = settingOptions.ShowRecentItemExtensions;
            var items = DataService.GetItems(itemsToDisplay, showExtensions);

            Items.Clear();

            foreach (var item in items)
            {
                Items.Add(item);
            }

            Refreshed = true;
        }

        private void RefreshRequested(RecentItemsRefreshMessage message)
            => Refresh();
    }
}