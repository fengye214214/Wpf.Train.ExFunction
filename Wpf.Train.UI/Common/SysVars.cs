using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.Train.UI
{   
    /// <summary>
    /// 系统变量
    /// 只定义变量和属性
    /// </summary>
    public class SysVars
    {
        private static UserViewModel userInfo = new UserViewModel();
        /// <summary>
        /// 用户对象
        /// 系统公共使用
        /// </summary>
        public static UserViewModel UserInfo
        {
            get { return SysVars.userInfo; }
            set { SysVars.userInfo = value; }
        }

        /// <summary>
        /// 系统Debug目录
        /// </summary>
        public static string DebugFilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
    }
}
