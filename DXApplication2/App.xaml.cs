using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using DXApplication2.Properties;

namespace DXApplication2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            CompatibilitySettings.UseLightweightThemes = true;
            ApplicationThemeHelper.Preload(PreloadCategories.Core);

            bool darkmode = Settings.Default.DarkMode;


            if (darkmode)
                ApplicationThemeHelper.ApplicationThemeName = Theme.Win11Dark.Name;
            else
                ApplicationThemeHelper.ApplicationThemeName = Theme.Win11Light.Name;


        }


        protected override void OnStartup(StartupEventArgs e)
        {
            
            base.OnStartup(e);

            SetupExceptionHandling();
        }


        private void SetupExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                LogUnhandledException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            DispatcherUnhandledException += (s, e) =>
            {
                LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");
                e.Handled = true;
            };

            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
                e.SetObserved();
            };
        }

        private void LogUnhandledException(Exception exception, string source)
        {
            string message = $"مشكل غير متوقع ({source})";
            try
            {
                System.Reflection.AssemblyName assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
                message = string.Format("Unhandled exception in {0} v{1}", assemblyName.Name, assemblyName.Version);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                MessageBox.Show(message);
            }
        }
    }
}
