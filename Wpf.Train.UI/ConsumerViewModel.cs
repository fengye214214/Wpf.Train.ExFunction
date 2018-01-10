using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Train.UI
{
    public class ConsumerViewModel : ViewModelBase
    {
        #region 字段定义
        private string conName;
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空！")]
        [StringLength(10, ErrorMessage = "名字字符串长度在2-10之间!", MinimumLength = 2)]
        public string ConName
        {
            get { return conName; }
            set
            {
                if (value != this.conName)
                {
                    this.conName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string comPwd;
        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空！")]
        [StringLength(20, ErrorMessage = "密码字符串长度在6-20之间!", MinimumLength = 6)]
        public string ComPwd
        {
            get { return comPwd; }
            set
            {
                if (value != comPwd)
                {
                    comPwd = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string conPwdConfirm;
        /// <summary>
        /// 用户密码确认
        /// </summary>
        [Required(ErrorMessage = "确认密码不能为空！")]
        [StringLength(20, ErrorMessage = "确认密码字符串长度在6-20之间!", MinimumLength = 6)]
        [Compare("ComPwd", ErrorMessage = "密码不一致！")]
        public string ConPwdConfirm
        {
            get { return conPwdConfirm; }
            set
            {
                if (value != conPwdConfirm)
                {
                    conPwdConfirm = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string address;
        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "地址不能为空！")]
        [StringLength(30, ErrorMessage = "地址字符串长度在6-20之间!", MinimumLength = 10)]
        public string Address
        {
            get { return address; }
            set
            {
                if (value != address)
                {
                    address = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int age;
        /// <summary>
        /// 年龄
        /// </summary>
        [Range(19, 99, ErrorMessage = "年龄必须在18岁以上！")]
        public int Age
        {
            get { return age; }
            set
            {
                if (value != age)
                {
                    age = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string email;
        /// <summary>
        /// 电子邮件地址
        /// </summary>
        [Required(ErrorMessage = "Email地址不能为空！")]
        [EmailAddress(ErrorMessage = "邮箱格式不正确！")]
        public string Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string phoneNumber;
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required(ErrorMessage = "电话号码不能为空！")]
        [RegularExpression(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$",ErrorMessage = "手机号码格式不正确！")]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region 数据验证错误消息
        public override string Error
        {
            get
            {   
                //此处按照界面表单判断
                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(this["ConName"]))
                {
                    sb.AppendLine(this["ConName"]);
                    return sb.ToString();
                }
                if (!string.IsNullOrEmpty(this["ComPwd"]))
                {
                    sb.AppendLine(this["ComPwd"]);
                    return sb.ToString();
                }
                if (!string.IsNullOrEmpty(this["ConPwdConfirm"]))
                {
                    sb.AppendLine(this["ConPwdConfirm"]);
                    return sb.ToString();
                }
                if (!string.IsNullOrEmpty(this["Age"]))
                {
                    sb.AppendLine(this["Age"]);
                    return sb.ToString();
                }
                if (!string.IsNullOrEmpty(this["PhoneNumber"]))
                {
                    sb.AppendLine(this["PhoneNumber"]);
                    return sb.ToString();
                }
                if (!string.IsNullOrEmpty(this["Email"]))
                {
                    sb.AppendLine(this["Email"]);
                    return sb.ToString();
                }
                if (!string.IsNullOrEmpty(this["Address"]))
                {
                    sb.AppendLine(this["Address"]);
                    return sb.ToString();
                }
                return sb.ToString();
            }
        }
        #endregion
    }
}
