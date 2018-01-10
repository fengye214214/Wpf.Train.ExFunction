using System;
using System.Collections.Generic;
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
using Wpf.Train.CustomControlLib;

namespace Wpf.Train.UI.Views
{
    /// <summary>
    /// CustomReg.xaml 的交互逻辑
    /// </summary>
    public partial class CustomReg : WindowBase
    {
        private readonly ConsumerViewModel consumerViewModel;

        public CustomReg()
        {
            InitializeComponent();

            consumerViewModel = new ConsumerViewModel();
            this.DataContext = consumerViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            //验证
            if (!string.IsNullOrEmpty(consumerViewModel.Error))
            {
                MessageBox.Show(consumerViewModel.Error);
                return;
            }
            MessageBox.Show(consumerViewModel.ConName + consumerViewModel.ComPwd + consumerViewModel.PhoneNumber);
        }
    }
}
