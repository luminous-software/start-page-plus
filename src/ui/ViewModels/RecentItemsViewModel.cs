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

        public RecentItemsViewModel(
            IRecentItemDataService dataService,
            IRecentItemActionService actionService,
            IRecentItemCommandService commandService,
            IRecentItemService itemService,
            IDialogService dialogService)
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

            MessengerInstance.Register<RecentItemClickMessage>(this, ExecuteAction);
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

        //public void OnContextMenuClosing(object sender, ContextMenuEventArgs e)
        //    => ContextCommands.Clear();

        public void OnContextMenuOpening(object sender, ContextMenuEventArgs e)
            => GetContextCommands();

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
            => ContextCommands = CommandService.GetContextCommands(CanRemoveItem, RemoveItem, CanPinItem, PinItem, CanUnpinItem, UnpinItem, CanCopyItemPath, CopyItemPath);

        private void ExecuteAction(RecentItemClickMessage message)
            => ActionService.ExecuteAction(message.Content);

        //TODO: can these Func<bool>'s be changed to just bool now?

        private bool CanCopyItemPath
            => (SelectedItem != null);

        private void CopyItemPath()
        {
            if (!ItemService.CopyItemPath(SelectedItem))
            {
                DialogService.ShowMessage("Path copied: '{SelectedItem?.Name}'", Vsix.Name);
            }
            SelectedItem = null;
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

        private bool CanPinItem
            => (SelectedItem?.Pinned == false);

        private void PinItem()
        {
            //SelectedItem.Pinned = true;
            //SelectedItem.ClickCommand.Execute(null);
            if (!ItemService.PinItem(SelectedItem))
            {
                DialogService.ShowMessage($"Unable to pin '{SelectedItem?.Name}'", Vsix.Name);
            }
            Refresh();
        }

        private bool CanUnpinItem
            => (SelectedItem?.Pinned == true);

        private void UnpinItem()
        {
            if (!ItemService.UnpinItem(SelectedItem))
            {
                DialogService.ShowMessage($"Unable to unpin '{SelectedItem?.Name}'", Vsix.Name);
            }
            Refresh();
        }

        public void Refresh()
        {
            var itemsToDisplay = SettingOptions.Instance.RecentItemsToDisplay;
            var items = DataService.GetItems(itemsToDisplay);

            Items.Clear();

            foreach (var item in items)
            {
                Items.Add(item);
            }

            SelectedItem = null;
        }
    }
}