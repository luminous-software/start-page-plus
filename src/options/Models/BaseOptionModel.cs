using Microsoft;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell.Settings;
using Microsoft.VisualStudio.Threading;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

using Task = System.Threading.Tasks.Task;

namespace Luminous.Code.VisualStudio.Options.Pages
{
    public abstract class BaseOptionModel<T>
        where T : BaseOptionModel<T>, new()
    {
        private static AsyncLazy<T> _liveModel = new AsyncLazy<T>(CreateAsync, ThreadHelper.JoinableTaskFactory);
        private static AsyncLazy<ShellSettingsManager> _settingsManager = new AsyncLazy<ShellSettingsManager>(GetSettingsManagerAsync, ThreadHelper.JoinableTaskFactory);

        protected BaseOptionModel()
        { }

        // A singleton instance of the options. MUST be called from UI thread only
        // Call GetLiveInstanceAsync() instead if on a background thread or in an async context on the main thread
        public static T Instance
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();

#pragma warning disable VSTHRD104 // Offer async methods
                return ThreadHelper.JoinableTaskFactory.Run(GetLiveInstanceAsync);
#pragma warning restore VSTHRD104 // Offer async methods
            }
        }

        // Get the singleton instance of the options (Thread safe)
        public static Task<T> GetLiveInstanceAsync()
            => _liveModel.GetValueAsync();

        // Creates a new instance of the options class and loads the values from the store (for internal use only)
        public static async Task<T> CreateAsync()
        {
            var instance = new T();

            await instance.LoadAsync();

            return instance;
        }

        // The name of the options collection as stored in the registry
        protected virtual string CollectionName { get; } = typeof(T).FullName;

        // Hydrates the properties from the registry
        public virtual void Load()
            => ThreadHelper.JoinableTaskFactory.Run(LoadAsync);

        // Hydrates the properties from the registry asyncronously
        public virtual async Task LoadAsync()
        {
            var manager = await _settingsManager.GetValueAsync();
            var settingsStore = manager.GetReadOnlySettingsStore(SettingsScope.UserSettings);


            if (!settingsStore.CollectionExists(CollectionName))
            {
                return;
            }

            foreach (var property in GetOptionProperties())
            {
                try
                {
                    var serializedProp = settingsStore.GetString(CollectionName, property.Name);
                    var value = DeserializeValue(serializedProp, property.PropertyType);

                    property.SetValue(this, value);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(ex);
                }
            }
        }

        // Saves the properties to the registry
        public virtual void Save()
            => ThreadHelper.JoinableTaskFactory.Run(SaveAsync);

        // Saves the properties to the registry asyncronously
        public virtual async Task SaveAsync()
        {
            var manager = await _settingsManager.GetValueAsync();
            var settingsStore = manager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!settingsStore.CollectionExists(CollectionName))
            {
                settingsStore.CreateCollection(CollectionName);
            }

            foreach (var property in GetOptionProperties())
            {
                var output = SerializeValue(property.GetValue(this));
                settingsStore.SetString(CollectionName, property.Name, output);
            }

            var liveModel = await GetLiveInstanceAsync();

            if (this != liveModel)
            {
                await liveModel.LoadAsync();
            }
        }

        // Serializes an object value to a string using the binary serializer
        protected virtual string SerializeValue(object value)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, value);
                stream.Flush();
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        // Deserializes a string to an object using the binary serializer
        protected virtual object DeserializeValue(string value, Type type)
        {
            var b = Convert.FromBase64String(value);

            using (var stream = new MemoryStream(b))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }

        private static async Task<ShellSettingsManager> GetSettingsManagerAsync()
        {
#pragma warning disable VSTHRD010
            // False-positive in Threading Analyzers. Bug tracked here https://github.com/Microsoft/vs-threading/issues/230
            var svc = await AsyncServiceProvider.GlobalProvider.GetServiceAsync(typeof(SVsSettingsManager)) as IVsSettingsManager;
#pragma warning restore VSTHRD010

            Assumes.Present(svc);

            return new ShellSettingsManager(svc);
        }

        private IEnumerable<PropertyInfo> GetOptionProperties() => GetType()
            .GetProperties()
            .Where(p => p.PropertyType.IsSerializable && p.PropertyType.IsPublic);
    }
}