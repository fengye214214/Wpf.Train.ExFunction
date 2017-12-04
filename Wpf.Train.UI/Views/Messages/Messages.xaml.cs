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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Train.CustomControlLib;
using Wpf.Train.Entiry;

namespace Wpf.Train.UI
{
    /// <summary>
    /// Messages.xaml 的交互逻辑
    /// </summary>
    public partial class Messages : PageBase
    {

        public string MyTestProperty
        {
            get { return (string)GetValue(MyTestPropertyProperty); }
            set { SetValue(MyTestPropertyProperty, value); }
        }

        public static readonly DependencyProperty MyTestPropertyProperty =
            DependencyProperty.Register("MyTestProperty", typeof(string), typeof(Messages), new PropertyMetadata("测试依赖属性"));



        public ObservableCollection<TreeViewListViewModel> UserTreeList { get; set; }
        public Messages()
        {
            InitializeComponent();
            UserTreeList = new ObservableCollection<TreeViewListViewModel>();
            txt_testTxt.DataContext = MyTestProperty;
        }

        private void PageBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (!this.IsFirstLoad)
            {
                return;
            }
            var list = new List<string>() { "1", "2", "3", "4" };
            exCom.ItemsSource = list;

            InitUserTreeList();
        }

        private void InitUserTreeList()
        {
            //添加根结点
            var org = new Organization()
            {
                 Id = "1",
                 Name = "组织架构"
            };
            var rootModel = new TreeViewListViewModel()
            {
                Node = org.Id,
                NodeName = org.Name,
                NodeImage = "\ue613",
                NodeData = org
            };
            UserTreeList.Add(rootModel);
            //添加子结点1
            var teams = new Teams()
            {
                Id = "1",
                Name = "小组1"
            };
            var teamModel = new TreeViewListViewModel()
            {
                Node = teams.Id,
                NodeName = teams.Name,
                NodeImage = "\ue611",
                NodeData = org
            };
            UserTreeList[0].ChildrenList.Add(teamModel);
            //添加子结点2
            var teams1 = new Teams()
            {
                Id = "2",
                Name = "小组2"
            };
            var teamModel1 = new TreeViewListViewModel()
            {
                Node = teams1.Id,
                NodeName = teams1.Name,
                NodeImage = "\ue611",
                NodeData = org
            };
            //给结点2添加用户
            var users = new User()
            {
                Id ="1",
                Name = "用户1"
            };
            var teamModel2 = new TreeViewListViewModel()
            {
                Node = users.Id,
                NodeName = users.Name,
                NodeImage = "\ue656",
                NodeData = org
            };
            var users1 = new User()
            {
                Id = "2",
                Name = "用户2"
            };
            var teamModel3 = new TreeViewListViewModel()
            {
                Node = users1.Id,
                NodeName = users1.Name,
                NodeImage = "\ue656",
                NodeData = org
            };
            teamModel1.ChildrenList.Add(teamModel2);
            teamModel1.ChildrenList.Add(teamModel3);
            UserTreeList[0].ChildrenList.Add(teamModel1);
            

            tv_totalPersonList.ItemsSource = UserTreeList;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WaitingWinBox.ShowDialog(new Action(() =>
            {
                Thread.Sleep(5000);
            }));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var nw = new NewWindow();
            nw.Show();
        }

        private void btn_info_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxEx.ShowInfo("我是提示信息！");
        }

        private void btn_war_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxEx.ShowWarn("我是警告信息！我是警告信息！我是警告信息！我是警告信息！我是警告信息！我是警告信息！我是警告信息！我是警告信息！我是警告信息！我是警告信息！");
        }

        private void btn_error_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxEx.ShowError("我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，我是错误，");
        }

        private void btn_tip_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxEx.ShowQuestion("确认删除？");
            if (result)
            {
                MessageBox.Show("true");
            }
            else
            {
                MessageBox.Show("false");
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            var rootModel = new TreeViewListViewModel()
            {
                Node = "2",
                NodeName = "添加结点",
                NodeImage = "\ue611",
            };
            UserTreeList[0].ChildrenList.Add(rootModel);
        }

        private void btn_Re_Click(object sender, RoutedEventArgs e)
        {
            UserTreeList.Clear();
            InitUserTreeList();
        }

        private void btn_ch_Click(object sender, RoutedEventArgs e)
        {
            MyTestProperty = "改变";
        }
    }
}
