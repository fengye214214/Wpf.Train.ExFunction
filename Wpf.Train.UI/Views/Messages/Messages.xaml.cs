﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Messages.xaml 的交互逻辑
    /// </summary>
    public partial class Messages : PageBase
    {
        public Messages()
        {
            InitializeComponent();
        }

        private void PageBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (!this.IsFirstLoad)
            {
                return;
            }

        }
    }
}
