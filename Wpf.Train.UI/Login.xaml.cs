using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Train.CustomControlLib;
using Wpf.Train.Common;

namespace Wpf.Train.UI
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : WindowBase
    {
        #region 属性变量

        private string xmlPath = SysVars.DebugFilePath + "userConfig.xml";
        private UserViewModel userContext;
        private WaitingWinBox waitWin;

        #endregion

        #region 构造方法

        public Login()
        {
            InitializeComponent();

            userContext = new UserViewModel();
            grid_login.DataContext = userContext;
        }

        #endregion

        #region 事件
        private void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            //此行代码说明见WindowBase类的注释
            this.Height = this.Height - 40;
            //如果存在xml文件，读取用户信息
            if (File.Exists(xmlPath))
            {
                var model = XMLHelper<UserViewModel>.DeSerializeAndRead(xmlPath);
                userContext.LoginName = model.LoginName;
                txt_pwd.Password = model.LoginPwd;
                userContext.ServerIP = model.ServerIP;
                userContext.SelectHostIP = model.SelectHostIP;
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            userContext.LoginPwd = txt_pwd.Password;
            if (String.IsNullOrEmpty(userContext.LoginName))
            {
                MessageBoxEx.ShowInfo("请输入用户名！");
                return;
            }
            if (String.IsNullOrEmpty(userContext.LoginPwd))
            {
                MessageBoxEx.ShowInfo("请输入密码！");
                return;
            }
            if (String.IsNullOrEmpty(txt_hostIP.SelectedItem.ToString()))
            {
                MessageBoxEx.ShowInfo("请输入本机IP！");
                return;
            }
            if (String.IsNullOrEmpty(userContext.ServerIP))
            {
                MessageBoxEx.ShowInfo("请输入服务器IP！");
                return;
            }

            WaitingWinBox.ShowDialog(new Action(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var mainWin = new MainWindow();
                    mainWin.Show();
                    this.Close();
                }));
            }));


        }

        protected override void OnClosed(EventArgs e)
        {
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
