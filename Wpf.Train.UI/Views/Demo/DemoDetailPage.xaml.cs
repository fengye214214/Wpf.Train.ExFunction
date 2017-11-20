using System;
using System.Collections.Generic;
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

namespace Wpf.Train.UI
{
    /// <summary>
    /// DemoDetailPage.xaml 的交互逻辑
    /// </summary>
    public partial class DemoDetailPage : PageBase
    {
        public DemoDetailPage()
        {
            InitializeComponent();
        }

        public DemoDetailPage(string str)
            : this()
        {
            txt_details.Content = string.Format("我是传递过来的 {0} ", str);
        }

        private void PageBase_Loaded(object sender, RoutedEventArgs e)
        {
            //if (this.IsFirstLoad)
            //{
            //    return;
            //}
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
            ParentWindow.PageCanGoBack();
        }
    }
}
