using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Wpf.Train.UI
{
    public class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {   
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        #region INotifyPropertyChanged事件
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 属性更改事件
        /// </summary>
        /// <param name="propertyName"></param>
        ///<remarks>.net 4.0中的用法</remarks>
        public void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 属性更改事件
        /// </summary>
        /// <param name="propertyName"></param>
        ///<remarks>.net 4.5中的用法</remarks>
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 属性更改事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression"></param>
        ///<remarks>.net 4.0中的用法, .net 4.5也可以用</remarks>
        public void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            this.NotifyPropertyChanged(((MemberExpression)propertyExpression.Body).Member.Name);
        }
        #endregion

        #region IDataErrorInfo事件，用于数据验证

        /// <summary>
        /// 获取数据注释的特性描述
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                var vc = new ValidationContext(this, null, null)
                {
                    MemberName = columnName
                };
                var res = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this, null), vc, res);
                if (res.Count > 0)
                {
                    return string.Join(Environment.NewLine, res.Select(r => r.ErrorMessage).ToArray());
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 验证的错误消息
        /// </summary>
        /// <remarks>这里重新定义为virtual，以便子类重写</remarks>
        public virtual string Error
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}
