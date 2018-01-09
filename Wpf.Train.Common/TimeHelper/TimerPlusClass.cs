using System;

namespace Wpf.Train.Common
{
    /// <summary>
    /// 计时器累加类
    /// </summary>
    public class TimerPlusClass
    {
        private int TotalSecond;
        private int CurrentMinutes = 0;

        public TimerPlusClass()
        {
            //从零开始累加
            TotalSecond = 0;
        }

        /// <summary>
        /// 秒加
        /// </summary>
        /// <returns></returns>
        public void SecondsPlus()
        {
            if (CurrentMinutes == 59)
            {
                CurrentMinutes = 0;
            }

            TotalSecond++;
            CurrentMinutes++;
        }

        /// <summary>
        /// 获取小时
        /// </summary>
        /// <returns></returns>
        public string GetHour()
        {
            return String.Format("{0:D2}", (TotalSecond / 3600));
        }

        /// <summary>
        /// 获取分钟
        /// </summary>
        /// <returns></returns>
        public string GetMinute()
        {
            return String.Format("{0:D2}", (TotalSecond % 3600) / 60);
        }

        /// <summary>
        /// 获取秒
        /// </summary>
        /// <returns></returns>
        public string GetSecond()
        {
            return String.Format("{0:D2}", TotalSecond % 60);
        }
    }
}
