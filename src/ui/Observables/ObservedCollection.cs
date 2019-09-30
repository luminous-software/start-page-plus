using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace StartPagePlus.UI.Observables
{
    namespace ObservableCollections
    {
        //https://www.codeproject.com/Articles/1004644/ObservableCollection-Simply-Explained

        public class ObservedCollection<T>
        {
            public readonly ObservableCollection<T> Source;

            public delegate void ObservedCollectionAddDelegate(ObservableCollection<T> aSender, int aIndex, T aItem);
            public event ObservedCollectionAddDelegate OnItemAdded;

            public delegate void ObservedCollectionMoveDelegate(ObservableCollection<T> aSender, int aOldIndex, int aNewIndex, T aItem);
            public event ObservedCollectionMoveDelegate OnItemMoved;

            public delegate void ObservedCollectionRemoveDelegate(ObservableCollection<T> aSender, int aIndex, T aItem);
            public event ObservedCollectionRemoveDelegate OnItemRemoved;

            public delegate void ObservedCollectionReplaceDelegate(ObservableCollection<T> aSender, int aIndex, T aOldItem, T aNewItem);
            public event ObservedCollectionReplaceDelegate OnItemReplaced;

            public delegate void ObservedCollectionResetDelegate(ObservableCollection<T> aSender);
            public event ObservedCollectionResetDelegate OnCleared;

            public ObservedCollection() : this(new ObservableCollection<T>())
            { }
            public ObservedCollection(ObservableCollection<T> source)
            {
                Source = source;
                Source.CollectionChanged += Source_CollectionChanged;
            }

            protected void CheckOneOrNone(IList aList)
            {
                if (aList.Count > 1)
                {
                    throw new Exception("Holy cow. Someone changed ObservableCollection - update ObservedCollection.");
                }
            }

            private void Source_CollectionChanged(object aSender, NotifyCollectionChangedEventArgs aArgs)
            {
                switch (aArgs.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        //CheckOneOrNone(aArgs.NewItems);
                        OnItemAdded?.Invoke(Source, aArgs.NewStartingIndex, (T)aArgs.NewItems[0]);
                        break;

                    case NotifyCollectionChangedAction.Move:
                        //CheckOneOrNone(aArgs.NewItems);
                        OnItemMoved?.Invoke(Source, aArgs.OldStartingIndex, aArgs.NewStartingIndex, (T)aArgs.NewItems[0]);
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        //CheckOneOrNone(aArgs.OldItems);
                        OnItemRemoved?.Invoke(Source, aArgs.OldStartingIndex, (T)aArgs.OldItems[0]);
                        break;

                    case NotifyCollectionChangedAction.Replace:
                        //CheckOneOrNone(aArgs.NewItems);
                        OnItemReplaced?.Invoke(Source, aArgs.OldStartingIndex, (T)aArgs.OldItems[0], (T)aArgs.NewItems[0]);
                        break;

                    case NotifyCollectionChangedAction.Reset:
                        OnCleared?.Invoke(Source);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}