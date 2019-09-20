using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace StartPagePlus.UI.Observables
{
    public interface IObservableList<T> : IList<T>, INotifyCollectionChanged { }

    public class ObservableList<T> : List<T>, IObservableList<T>, INotifyPropertyChanged
    {
        //https://baumbartsjourney.wordpress.com/2009/06/01/an-alternative-to-observablecollection/

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableList()
        {
            IsNotifying = true;

            // to be able to bind to the VisibleCount property
            // need to use the OnPropertyChanged event from the INotifyPropertyChanged interface
            // to notify about VisibleCount changes

            CollectionChanged += new NotifyCollectionChangedEventHandler(delegate (object sender, NotifyCollectionChangedEventArgs e)
            {

                OnPropertyChanged(nameof(VisibleCount));
            });
        }

        public bool IsNotifying { get; set; }

        public virtual int VisibleCount { get; }

        public new void Add(T item)
        {
            base.Add(item);

            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item);

            OnCollectionChanged(e);
        }

        public new void AddRange(IEnumerable<T> collection)

        {
            base.AddRange(collection);

            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new List<T>(collection));

            OnCollectionChanged(e);
        }

        public new void Clear()
        {
            base.Clear();

            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);

            OnCollectionChanged(e);
        }

        public new void Insert(int i, T item)
        {
            base.Insert(i, item);

            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item);

            OnCollectionChanged(e);
        }

        public new void InsertRange(int i, IEnumerable<T> collection)
        {
            base.InsertRange(i, collection);

            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collection);

            OnCollectionChanged(e);
        }

        public new void Remove(T item)
        {

            base.Remove(item);

            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item);

            OnCollectionChanged(e);

        }
        public new void RemoveAll(Predicate<T> match)
        {
            var backup = FindAll(match);

            base.RemoveAll(match);

            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, backup);

            OnCollectionChanged(e);
        }

        public new void RemoveAt(int i)
        {
            var backup = this[i];

            base.RemoveAt(i);

            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, backup);

            OnCollectionChanged(e);
        }

        public new void RemoveRange(int index, int count)
        {
            var backup = GetRange(index, count);

            base.RemoveRange(index, count);

            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, backup);

            OnCollectionChanged(e);
        }

        public new T this[int index]
        {
            get => base[index];
            set
            {
                var oldValue = base[index];

                var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, oldValue);

                OnCollectionChanged(e);
            }
        }

        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (IsNotifying)
            {
                try
                {
                    CollectionChanged?.Invoke(this, e);
                }
                catch (NotSupportedException)
                {
                    var alternativeEventArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);

                    OnCollectionChanged(alternativeEventArgs);
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}