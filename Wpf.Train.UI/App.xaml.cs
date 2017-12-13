using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Wpf.Train.CustomControlLib;

namespace Wpf.Train.UI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionOccured);
        }

        private void UnhandledExceptionOccured(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBoxEx.ShowError(((Exception)e.ExceptionObject).Message);
        }
    }
}
