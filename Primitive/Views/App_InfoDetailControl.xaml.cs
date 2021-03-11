using System;

using Primitive.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;
using Windows.Management.Deployment;
using System.Collections.Generic;

namespace Primitive.Views
{
    public sealed partial class App_InfoDetailControl : UserControl
    {
        public appstruct MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as appstruct; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(appstruct), typeof(App_InfoDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public App_InfoDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as App_InfoDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var index = int.Parse(btn.Tag.ToString());
            var launch = App_InfoPage.apps[index].LaunchAsync();
        }
    }
}
