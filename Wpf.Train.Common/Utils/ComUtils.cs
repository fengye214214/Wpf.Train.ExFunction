using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Wpf.Train.Common
{   
    /// <summary>
    /// 工具类
    /// </summary>
    public class ComUtils
    {
        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns></returns>
        public static List<String> GetLocalAddressIP()
        {
            var list = new List<String>();
            Dns.GetHostEntry(Dns.GetHostName()).AddressList.ToList().ForEach(x =>
            {
                if (x.AddressFamily.ToString().Equals("InterNetwork"))
                {
                    list.Add(x.ToString());
                }
            });
            list = list.OrderByDescending(x => x).ToList();
            return list;
        }
    }
}
