using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Wpf.Train.UI
{
    /// <summary>
    /// DemoPage.xaml 的交互逻辑
    /// </summary>
    public partial class DemoPage : PageBase
    {
        #region 变量
        private IVMSTreeListViewModel ivmViewModel;
        #endregion

        #region 属性

        private List<IVMSTreeListViewModel> deviceTreeList = new List<IVMSTreeListViewModel>();
        /// <summary>
        /// 设备树形结构
        /// </summary>
        public List<IVMSTreeListViewModel> DeviceTreeList
        {
            get { return deviceTreeList; }
            set
            {
                deviceTreeList = value;
                Dispatcher.BeginInvoke(new Action(() => { tv_orgList.ItemsSource = deviceTreeList; }));
            }
        }

        private ObservableCollection<IssueViewModel> issueList = new ObservableCollection<IssueViewModel>();
        public ObservableCollection<IssueViewModel> IssueList
        {
            get { return issueList; }
            set
            {
                issueList = value;
                Dispatcher.BeginInvoke(new Action(() => { dg_issueList.ItemsSource = issueList; }));
            }
        }
        #endregion

        public DemoPage()
        {
            InitializeComponent();
            ivmViewModel = new IVMSTreeListViewModel();
        }

        private void PageBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (!this.IsFirstLoad)
            {
                return;
            }

            int count = 0;
            Thread th = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    count++;
                    Dispatcher.Invoke(new Action(() =>
                    {
                        txt_name.Content = count.ToString();
                    }));
                    Thread.Sleep(1000);
                }
            }));
            th.IsBackground = true;
            th.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var detailPage = new DemoDetailPage(txt_name.Content.ToString());
            ParentWindow.Navigation(detailPage);
        }

        private void ImgButton_Click(object sender, RoutedEventArgs e)
        {
            var userName = txt_userName.Text;
            var userPwd = txt_pwd.Password;
            if (string.IsNullOrEmpty(userName))
            {
                MessageBoxEx.ShowInfo("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(userName))
            {
                MessageBoxEx.ShowInfo("密码不能为空！");
                return;
            }

            WaitingWinBox.ShowDialog(new Action(() =>
            {
                var orgList = ivmViewModel.GetDeviceTreeList(userName, userPwd, 1);
                if(!"200".Equals(orgList.ErrorCode))
                {
                    Dispatcher.BeginInvoke(new Action(() => 
                    {
                        MessageBoxEx.ShowError(orgList.Message);
                    }));
                    return;
                }
                DeviceTreeList = orgList.Data;
            }), "获取组织机构...");
        }

        private void ImgButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var issueModel = new IssueViewModel();
                WaitingWinBox.ShowDialog(new Action(() =>
                {
                    var result = issueModel.GetIssueList();
                    if (!result.success)
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            MessageBoxEx.ShowError(result.message);
                        }));
                        return;
                    }
                    IssueList = result.data;
                }), "获取数据...");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
