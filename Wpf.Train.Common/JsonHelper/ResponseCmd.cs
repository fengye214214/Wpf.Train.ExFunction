﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.Train.Common
{
    public class ResponseCmd<T> where T : new()
    {
        public ResponseCmd()
        {
            data = new T();
        }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 返回的消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 创建响应参数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseCmd<T> CreateResponseCmd(string data)
        {
            var setting = new JsonSerializerSettings()
            {
                //日期类型默认格式化处理
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                //日期格式
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                //字段首字母消息
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                //空值处理
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.DeserializeObject<ResponseCmd<T>>(data, setting);
        }
    }
}
