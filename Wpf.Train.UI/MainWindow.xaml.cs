using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Wpf.Train.CustomControlLib;

namespace Wpf.Train.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        #region 属性定义

        #region 导航页面定义

        /// <summary>
        /// 语音调度
        /// </summary>
        public VideoDispatch VideoDispatchPage { get; set; }
        /// <summary>
        /// 视频调度
        /// </summary>
        public VoiceDispatch VoiceDispatchPage { get; set; }
        /// <summary>
        /// 短消息
        /// </summary>
        public Messages MessagesPage { get; set; }
        /// <summary>
        /// 示例导航页面
        /// </summary>
        public DemoPage DemoMainPage { get; set; }

        #endregion

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VideoDispatchPage = new VideoDispatch();
            VoiceDispatchPage = new VoiceDispatch();
            MessagesPage = new Messages();
            DemoMainPage = new DemoPage();
            //默认显示语音界面
            Navigation(VoiceDispatchPage);

            com_changeSkin.ItemsSource = SkinViewModel.SkinResList;
            com_changeSkin.SelectedIndex = 0;
        }

        #region 页面导航

        public void Navigation(Page pages = null)
        {
            //设置Page导航内容
            this.main_frame.NavigationService.Content = pages;
            if (pages != null)
            {
                Type type = pages.GetType();
                PropertyInfo[] infos = type.GetProperties();
                foreach (var item in infos)
                {
                    //ParentWindow对用于PageBase页面里的 ParentWindow属性
                    //此操作是为了让导航的Page也可以调用MainWindow里的方法
                    if ("ParentWindow".Equals(item.Name))
                    {
                        item.SetValue(pages, this, null);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 返回上一个Page页
        /// </summary>
        public void PageCanGoBack()
        {
            if (this.main_frame.NavigationService.CanGoBack)
            {
            this.main_frame.NavigationService.GoBack();
            }
        }

        private void btn_voice_Click(object sender, RoutedEventArgs e)
        {   
            //语音调度
            Navigation(VoiceDispatchPage);
        }

        private void btn_video_Click(object sender, RoutedEventArgs e)
        {   
            //视频调度
            Navigation(VideoDispatchPage);
        }

        private void btn_msg_Click(object sender, RoutedEventArgs e)
        {   
            //短消息
            Navigation(MessagesPage);
        }

        private void btn_demo_Click(object sender, RoutedEventArgs e)
        {   
            //demo导航示例
            Navigation(DemoMainPage);
        }
        #endregion

        #region 公共方法

        public void CallParentWindowMethod(string str = "")
        {
            MessageBox.Show(str);
        }

        #endregion

        #region 重写方法
        protected override void OnClosed(EventArgs e)
        {

        }
        #endregion

        private void com_changeSkin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            var cb = sender as ComboBox;
            var skinModel = cb.SelectedItem as SkinViewModel;
            var skinViewModel = new SkinViewModel();
            skinViewModel.ChangeSkin(skinModel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }




    }
}
