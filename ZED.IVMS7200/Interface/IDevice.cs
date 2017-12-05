using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpf.Train.Common;
using Wpf.Train.Entiry;

namespace ZED.IVMS7200
{   
    /// <summary>
    /// 设备接口
    /// </summary>
    public partial interface IDevice
    {
        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="line">线路号</param>
        SOAPResponseCmd<DevTreeInfo> GetDevTreeInfo(string userName, string pwd, uint line);
    }
}
