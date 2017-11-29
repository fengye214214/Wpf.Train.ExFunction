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
using System.Windows.Shapes;
using Wpf.Train.CustomControlLib;

namespace Wpf.Train.UI
{
    /// <summary>
    /// DemoPage.xaml 的交互逻辑
    /// </summary>
    public partial class DemoPage : PageBase
    {
        public DemoPage()
        {
            InitializeComponent();
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


    }
}
