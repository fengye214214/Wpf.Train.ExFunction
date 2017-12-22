using Prism.Logging;
using Prism.Mef;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModularityWithMef.Desktop
{   
    /// <summary>
    /// 使用Managed Extensibility Framework(MEF)初始化Prism开始启动快速启动的Prism应用
    /// </summary>
    public class QuickStartBootstrapper : MefBootstrapper
    {
        private readonly CallbackLogger callbackLogger = new CallbackLogger();

        /// <summary>
        /// 创建应用程序的主要shell窗体
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<Shell>();
        }

        /// <summary>
        /// 初始化shell
        /// </summary>
        ///<remarks>
        ///基本的实现保证shell在容器中
        /// </remarks>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell)this.Shell;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// 使用MEF配置
        /// </summary>
        /// <remarks>
        /// 这个基本实现不做任何事情
        /// </remarks>
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            //添加这个程序集以导出ModuleTracker
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(QuickStartBootstrapper).Assembly));

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleA).Assembly));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            //创建CallbackLogger因为它需要立即执行，我们让它是安全的并且已经创建
            this.Container.ComposeExportedValue<CallbackLogger>(this.callbackLogger);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            //使用MEF，现在存在的Prism ModuleCatalog任然是使用配置文件去配置模块
            return new ConfigurationModuleCatalog();
        }

        /// <summary>
        /// 使用QuickStartBootstrapper创建ILoggerFacade
        /// </summary>
        /// <remarks>
        /// 基本的实现返回一个TextLogger
        /// </remarks>
        /// <returns></returns>
        protected override ILoggerFacade CreateLogger()
        {
            //因为shell是在所有QuickStartBootstrapper工作已经执行后展示的
            //QuickStartBootstrapper使用一个特别的logger类去处理一个更早的日志入口
            //并且在UI可视化之后展现他们
            return base.CreateLogger();
        }
    }
}
