using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.Train.Common
{   
    /// <summary>
    /// 时间帮助类
    /// </summary>
    public class TimesHelper
    {
        /// <summary>
        /// DateTime转换为32位uint
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static uint DateTimeTo32Uint(DateTime dateTime)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            uint timeStamp = (uint)(dateTime - startTime).TotalSeconds; // 相差秒数
            return timeStamp;
        }

        /// <summary>
        /// 32位uint转换为DateTime
        /// </summary>
        /// <param name="unixTime"></param>
        /// <returns></returns>
        public static DateTime Convert32UintToDateTime(uint unixTime)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(unixTime);
            return dt;
        }
    }
}
