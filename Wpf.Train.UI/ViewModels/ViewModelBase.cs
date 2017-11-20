using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Wpf.Train.UI
{
    public class ViewModelBase : INotifyPropertyChanged
    {   
        /// <summary>
        /// ID
        /// </summary>
        public virtual string ID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            this.NotifyPropertyChanged(((MemberExpression)propertyExpression.Body).Member.Name);
        }

    }
}
