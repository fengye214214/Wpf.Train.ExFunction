using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Wpf.Train.CustomControlLib
{   
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class LibCustomMethod
    {
        private static ConcurrentDictionary<Enum, string> _CacheDescriptions = new ConcurrentDictionary<Enum, string>();

        /// <summary>
        /// 获取枚举类型的描述
        /// </summary>
        /// <param name="enums"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enums)
        {
            return _CacheDescriptions.GetOrAdd(enums, x =>
            {
                Type type = x.GetType();
                FieldInfo field = type.GetField(x.ToString());
                return (field == null) ? "" : GetDescription(field);
            });
        }

        private static string GetDescription(FieldInfo field)
        {
            Attribute customAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
            return (customAttribute == null) ? string.Empty : ((DescriptionAttribute)customAttribute).Description;
        }

        /// <summary>
        /// 根据枚举值获取枚举名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumNameByValue<T>(this object value)
        {
            Type typeFromHandle = typeof(T);
            if (typeFromHandle.IsEnum)
            {
                return Enum.GetName(typeFromHandle, value);
            }
            throw new InvalidCastException("必须是枚举类型才能获取枚举名称。");
        }

        public static void BindCommand(this UIElement @ui, ICommand com, Action<object, ExecutedRoutedEventArgs> call)
        {
            var bind = new CommandBinding(com);
            bind.Executed += new ExecutedRoutedEventHandler(call);
            ui.CommandBindings.Add(bind);
        }
    }
}
