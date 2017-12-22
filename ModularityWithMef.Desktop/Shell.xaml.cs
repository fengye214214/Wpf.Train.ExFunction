using ModuleTracking;
using Prism.Logging;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModularityWithMef.Desktop
{
    /// <summary>
    /// Shell.xaml 的交互逻辑
    /// </summary>
    [Export]
    public partial class Shell : Window, IPartImportsSatisfiedNotification
    {
        // shell引用IModuleTracker记录当一个记录已经下载
        [Import(AllowRecomposition = false)] private IModuleTracker moduleTracker;

        // shell引用IModuleManager当一个模块被需要
        [Import(AllowRecomposition = false)] private IModuleManager moduleManager;

        // shell引用logger把日志输出到UI
        [Import(AllowRecomposition = false)] private CallbackLogger logger;

        public Shell()
        {
            this.InitializeComponent();
        }

        public void Log(string message, Category category, Priority priority)
        {
            this.TraceTextBox.AppendText(
                                            string.Format(
                                                        CultureInfo.CurrentUICulture,
                                                        "[{0}][{1}] {2}\r\n",
                                                        category,
                                                        priority,
                                                        message));
        }



        public void OnImportsSatisfied()
        {
            //this.logger.Callback = this.Log;
            //this.logger.ReplaySaveLogs();

            //this.moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
            //this.moduleManager.ModuleDownloadProgressChanged += ModuleManager_ModuleDownloadProgressChanged;

        }

        //private void ModuleManager_ModuleDownloadProgressChanged(object sender, ModuleDownloadProgressChangedEventArgs e)
        //{
        //    this.moduleTracker.RecordModuleDownloading(e.ModuleInfo.ModuleName, e.BytesReceived, e.TotalBytesToReceive);
        //}

        //private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        //{
        //    this.moduleTracker.RecordModuleLoaded(e.ModuleInfo.ModuleName);
        //}
    }
}
