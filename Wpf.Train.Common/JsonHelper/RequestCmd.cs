using Newtonsoft.Json;
using System;


namespace Wpf.Train.Common
{
    public class RequestCmd
    {
        public RequestCmd()
        {
        }

        // [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Object data
        {
            get;
            set;
        }

        public string date { get { return System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); } }

        public RequestCmd SetDataValue(Object oj)
        {
            this.data = oj;
            return this;
        }
        public override string ToString()
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            //日期类型默认格式化处理
            setting.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
            //setting.DateFormatString = "yyyy-MM-dd";
            setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            //空值处理
            setting.NullValueHandling = NullValueHandling.Ignore;


            string str = JsonConvert.SerializeObject(this, setting);
            return str;
        }

    }
}
