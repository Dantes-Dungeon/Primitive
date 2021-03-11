using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Microsoft.Toolkit.Uwp.UI.Controls;

using Primitive.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.ApplicationModel.Core;
using Windows.Management.Deployment;

namespace Primitive.Views
{
    public sealed partial class App_InfoPage : Page, INotifyPropertyChanged
    {
        private appstruct _selected;

        public static List<AppListEntry> apps = new List<AppListEntry>();

        public appstruct Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<appstruct> SampleItems { get; private set; } = new ObservableCollection<appstruct>();

        public App_InfoPage()
        {
            InitializeComponent();
            Loaded += App_InfoPage_Loaded;
        }

        private async void App_InfoPage_Loaded(object sender, RoutedEventArgs e)
        {
            SampleItems.Clear();

            var data = new List<appstruct>();

            var packagemanager = new PackageManager();
            var packages = packagemanager.FindPackagesForUser("");
            foreach (var package in packages)
            {
                var entries = package.GetAppListEntries();
                foreach (var entry in entries)
                {
                    data.Add(
                        new appstruct()
                        {
                            APPName = entry.DisplayInfo.DisplayName,
                            Description = entry.DisplayInfo.Description,
                            AMUID = entry.AppUserModelId,
                            Index = data.Count(),
                            SymbolCode = 57738, // Symbol Globe
                        });
                    apps.Add(entry);
                }
            }

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            if (MasterDetailsViewControl.ViewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.FirstOrDefault();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
