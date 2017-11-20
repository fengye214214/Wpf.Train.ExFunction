using System;
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

namespace Wpf.Train.CustomControlLib
{
    /// <summary>
    /// WindowBase.xaml 的交互逻辑
    /// 
    /// 此窗体有个BUG：
    /// 继承次窗体的Window, 假如Grid定义了两行，每行的属性都是Auto
    /// 在设计界面让控件都显示完全，但程序运行后，在SizeToContent是默认值情况下，窗体下方会多出一些空白
    /// 解决此问题的方式是在继承WindowBase的窗体的Loaded方法里添加:this.Height = this.Height - 20,就可以解决下方多出一些空白的问题
    /// 
    /// 如果每行都是*的话，你感觉下方空白区域多了也可以用上述方法解决
    /// 目前没找到原因
    /// </summary>
    public partial class WindowBase : Window
    {
        #region 依赖属性

        #region  标题栏高度
        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }
        public static readonly DependencyProperty CaptionHeightProperty =
            DependencyProperty.Register("CaptionHeight", typeof(double), typeof(WindowBase), new PropertyMetadata(15D));
        #endregion

        #region 标题栏背景

        public Brush CaptionBackground
        {
            get { return (Brush)GetValue(CaptionBackgroundProperty); }
            set { SetValue(CaptionBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CaptionBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionBackgroundProperty =
            DependencyProperty.Register("CaptionBackground", typeof(Brush), typeof(WindowBase), new PropertyMetadata(null));

        #endregion

        #region 标题栏标题大小


        public double HeaderFontSize
        {
            get { return (double)GetValue(HeaderFontSizeProperty); }
            set { SetValue(HeaderFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderFontSizeProperty =
            DependencyProperty.Register("HeaderFontSize", typeof(double), typeof(WindowBase), new PropertyMetadata(15D));


        #endregion

        #region 标题栏文字前景色
        public static readonly DependencyProperty CaptionForegroundProperty = DependencyProperty.Register(
    "CaptionForeground", typeof(Brush), typeof(WindowBase), new PropertyMetadata(null));

        public Brush CaptionForeground
        {
            get { return (Brush)GetValue(CaptionForegroundProperty); }
            set { SetValue(CaptionForegroundProperty, value); }
        }
        #endregion

        #endregion

        #region 命令定义
        /// <summary>
        /// 关闭命令
        /// </summary>
        public ICommand CloseWindowCommand { get; protected set; }
        #endregion

        #region 构造函数

        static WindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowBase), new FrameworkPropertyMetadata(typeof(WindowBase)));
        }

        public WindowBase()
        {
            this.WindowStyle = WindowStyle.None;
            this.AllowsTransparency = true;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.MaxHeight = SystemParameters.WorkArea.Height + 10;
            this.CloseWindowCommand = new RoutedUICommand();
            this.BindCommand(CloseWindowCommand, this.Close_Execute);
        }
        #endregion

        private void Close_Execute(object arg1, ExecutedRoutedEventArgs arg2)
        {
            this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {   
            //窗体可以拖动
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}
