using DevExpress.Xpf.Core;
using DXApplication2.Properties;
using DXApplication2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        bool isMaximized = true;

        public MainWindow()
        {
            InitializeComponent();
            mainPage.Navigate(new Dashboard2());
        }

        public void score()
        {
            //Load sample data
            var sampleData = new Fooding.ModelInput()
            {
                Month = @"janv",
                Vacance = 6F,
                Nom = @"tomates",
                N = 950F,
            };

            //Load model and predict output
            var result = Fooding.Predict(sampleData);

        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                isMaximized = true;
                this.WindowState = WindowState.Maximized;
                IconMax.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.DockWindow;

            }
            else if (this.WindowState == WindowState.Normal)
            {
                isMaximized = false;
                this.WindowState = WindowState.Normal;
                IconMax.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.WindowMaximize;
            }
        }

        private void btntheme_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.DarkMode == true)
            {
                ThemeIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.WeatherNight;
                ThemeIcon.Foreground = new SolidColorBrush(Colors.Black);
                Settings.Default.DarkMode = false;
                Settings.Default.Save();
                ApplicationThemeHelper.ApplicationThemeName = Theme.Win11Light.Name;
            }
            else
            {
                ThemeIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.WeatherSunny;
                ThemeIcon.Foreground = new SolidColorBrush(Colors.White);
                Settings.Default.DarkMode = true;
                Settings.Default.Save();
                ApplicationThemeHelper.ApplicationThemeName = Theme.Win11Dark.Name;
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if (!isMaximized)
            {
                isMaximized = true;
                this.WindowState = WindowState.Maximized;
                IconMax.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.DockWindow;

            }
            else
            {
                isMaximized = false;
                this.WindowState = WindowState.Normal;
                IconMax.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.WindowMaximize;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

            Environment.Exit(0);
        }
    }

    public class FrameAnimationSelector : DevExpress.Xpf.WindowsUI.AnimationSelector
    {
        private Storyboard _BackStoryboard;
        private Storyboard _ForwardStoryboard;
        public Storyboard ForwardStoryboard
        {
            get { return _ForwardStoryboard; }
            set { _ForwardStoryboard = value; }
        }
        public Storyboard BackStoryboard
        {
            get { return _BackStoryboard; }
            set { _BackStoryboard = value; }
        }
        protected override Storyboard SelectStoryboard(DevExpress.Xpf.WindowsUI.FrameAnimation animation)
        {
            return animation.Direction == DevExpress.Xpf.WindowsUI.AnimationDirection.Forward ? ForwardStoryboard : BackStoryboard;
        }
    }

}


