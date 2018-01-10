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
    /// CustomRegOne.xaml 的交互逻辑
    /// </summary>
    public partial class CustomRegOne : WindowBase
    {
        private readonly ConsumerViewModel consumerViewModel;

        public CustomRegOne()
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

    public class RequiredValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "内容不能为空");
            }
            return new ValidationResult(true, null);
        }
    }
}
