using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.Train.Common
{
    public class SOAPResponseCmd<T>
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }

        private T data = default(T);
        /// <summary>
        /// 返回的数据
        /// </summary>
        public T Data { get => data; set => data = value; }

    }
}
