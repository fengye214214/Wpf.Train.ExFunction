using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Wpf.Train.Common;

namespace Wpf.Train.UI
{
    /// <summary>
    /// 用户对象
    /// 因为此类用户信息的属性要进行序列化，所以在不需要序列化的属性前面加
    /// [System.Xml.Serialization.XmlIgnore]
    /// </summary>
    [Serializable]
    public class UserViewModel : ViewModelBase
    {
        #region 属性定义
        /// <summary>
        /// 用户服务类
        /// </summary>
        private string loginName;
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get { return loginName; }
            set
            {
                if (value != this.loginName)
                {
                    loginName = value;
                    OnPropertyChanged(() => this.LoginName);
                }
            }
        }

        private string loginPwd;
        /// <summary>
        /// 密码
        /// </summary>
        public string LoginPwd
        {
            get { return loginPwd; }
            set
            {
                if (value != this.loginPwd)
                {
                    loginPwd = value;
                    OnPropertyChanged(() => this.LoginPwd);
                }
            }
        }

        private string serverIP;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerIP
        {
            get { return serverIP; }
            set
            {
                if (value != this.serverIP)
                {
                    serverIP = value;
                    OnPropertyChanged(() => this.ServerIP);
                }
            }
        }
        /// <summary>
        /// 本机IP
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public List<string> HostIP
        {
            get
            {
                var list = new List<string>();
                list = IPAddressHelper.GetAllAddressIP();
                return list;
            }
        }

        private string selectHostIP;
        /// <summary>
        /// 选择的本机IP地址
        /// </summary>
        public string SelectHostIP
        {
            get { return selectHostIP; }
            set
            {
                if (value != this.selectHostIP)
                {
                    selectHostIP = value;
                    OnPropertyChanged(() => this.SelectHostIP);
                }
            }
        }

        private bool isRememberMe;
        /// <summary>
        /// 是否记住我
        /// </summary>
        public bool IsRememberMe
        {
            get { return isRememberMe; }
            set
            {
                if (value != this.isRememberMe)
                {
                    isRememberMe = value;
                    OnPropertyChanged(() => this.IsRememberMe);
                }
            }
        }
        #endregion

        #region 构造方法

        public UserViewModel()
        {
            isRememberMe = false;
        }

        #endregion

        #region  方法定义

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="win"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public int UserLogin(Window win, out string errorMsg)
        {
            int result = 0;
            errorMsg = "";
            return result;
        }
        public override string ToString()
        {
            return String.Format("{0}", LoginName);
        }
        #endregion

    }
}
