using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Wpf.Train.UI
{
    public partial class PageBase : Page
    {   
        private int count = 0;

        /// <summary>
        /// 判断页面是否为第一次加载，为了防止重复调用比如Loaded函数里的内容
        /// 保持Page页面的状态
        /// 在此属性判断的后面写业务逻辑代码
        /// </summary>
        public bool IsFirstLoad { get; private set; }
        /// <summary>
        /// 程序主界面
        /// </summary>
        public MainWindow ParentWindow { get; set; }

        public PageBase()
        {
            this.KeepAlive = true;
            this.Loaded += PageBase_Loaded;
        }

        void PageBase_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            count++;
            if (count == 1)
            {
                IsFirstLoad = true;
            }
            else
            {
                IsFirstLoad = false;
            }
        }
    }
}
