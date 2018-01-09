using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace Wpf.Train.Common
{   
    /// <summary>
    /// 配置文件帮助类
    /// </summary>
    public class ConfigsHelper
    {
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettingValue(string key)
        {
            string defaultValue = "error";
            try
            {
                string value = ConfigurationManager.AppSettings[key];
                return value;
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 设置配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetAppSettingValue(string key, string value)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[key] != null)
                {
                    config.AppSettings.Settings[key].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add(key, value);
                }
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置EndpointAddress
        /// </summary>
        /// <param name="endpointName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool SetEndpointClientAddress(string endpointName, string address)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ClientSection clientSection = config.GetSection("system.serviceModel/client") as ClientSection;
                foreach (ChannelEndpointElement item in clientSection.Endpoints)
                {
                    if (item.Name == endpointName)
                    {
                        item.Address = new Uri(address);
                        break;
                    }
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("system.serviceModel/client");
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取WSDL终结点的信息
        /// </summary>
        /// <param name="endpointName"></param>
        /// <returns></returns>
        public static Uri GetEndpointClientUri(string endpointName)
        {
            Uri uri = null;
            ClientSection clientSection = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            foreach (ChannelEndpointElement item in clientSection.Endpoints)
            {
                if (item.Name == endpointName)
                    uri = item.Address;
            }
            return uri;
        }
    }
}
