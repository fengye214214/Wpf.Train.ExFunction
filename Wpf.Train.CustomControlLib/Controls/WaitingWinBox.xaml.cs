﻿using System;
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

namespace Wpf.Train.CustomControlLib
{
    /// <summary>
    /// WaitingWinBox.xaml 的交互逻辑
    /// </summary>
    public partial class WaitingWinBox : WindowBase
    {
        #region 变量定义

        private Action callBackMethod;

        #endregion

        #region 依赖属性定义

        #region 提示文字
        /// <summary>
        /// 提示文字
        /// </summary>
        public string TipMessage
        {
            get { return (string)GetValue(TipMessageProperty); }
            set { SetValue(TipMessageProperty, value); }
        }
        public static readonly DependencyProperty TipMessageProperty =
            DependencyProperty.Register("TipMessage", typeof(string), typeof(WaitingWinBox), new PropertyMetadata("加载数据..."));
        #endregion

        #endregion

        public WaitingWinBox()
        {
            InitializeComponent();
            grid_content.DataContext = this;
        }

        public WaitingWinBox(Action _callBackMethod)
            : this()
        {
            this.callBackMethod = _callBackMethod;
            this.Loaded += WaitingWinBox_Loaded;
        }

        public WaitingWinBox(string msg)
            : this()
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                TipMessage = msg;
            }));
        }
        void WaitingWinBox_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(callBackMethod).
                ContinueWith(x =>
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.Close();
                    }));
                });
        }

        public void CloseAsync()
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.Close();
            }));
        }

        public void TipMessageAsync(string msg = "")
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                TipMessage = msg;
            }));
        }

        /// <summary>
        /// 在此方法里直接放控件,如果要放控件，在回调函数里的控件要加this.Dispatcher.BeginInvok
        /// </summary>
        /// <param name="callBack"></param>
        /// <param name="msg"></param>
        public static void ShowDialog(Action callBack, string msg = "加载数据...")
        {
            var win = new WaitingWinBox(callBack);
            win.Owner = ControlUtils.GetTopWindow();
            win.TipMessage = msg;
            win.ShowDialog();
        }
    }
}
