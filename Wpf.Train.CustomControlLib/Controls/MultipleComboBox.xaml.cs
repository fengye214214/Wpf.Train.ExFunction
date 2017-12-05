using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf.Train.CustomControlLib
{
    /// <summary>
    /// MultipleComboBox.xaml 的交互逻辑
    /// 2017-9-13 add by fy
    /// </summary>
    [TemplatePart(Name = "PART_ListBox", Type = typeof(ListBox))]
    public partial class MultipleComboBox : ComboBox
    {
        #region 属性变量定义
        private ListBox _ListBox;
        private bool IsFirstLoad = false;

        /// <summary>
        /// 获取选择项集合
        /// </summary>
        public IList SelectedItems
        {
            get { return this._ListBox.SelectedItems; }
        }

        /// <summary>
        /// 设置或获取选择项
        /// </summary>
        public new int SelectedIndex
        {
            get { return this._ListBox.SelectedIndex; }
            set { this._ListBox.SelectedIndex = value; }
        }
        #endregion

        static MultipleComboBox()
        {
        }

        public MultipleComboBox()
        {
            this.IsEditable = true;
            this.IsReadOnly = true;
        }

        #region 方法
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._ListBox = Template.FindName("PART_ListBox", this) as ListBox;
            //this._Pupu = Template.FindName("PART_Popup", this) as Popup;
            if (this._ListBox != null)
            {
                this._ListBox.SelectionChanged += _ListBox_SelectionChanged;
                this._ListBox.Loaded += MultipleComboBox_Loaded;
                this.DropDownClosed += MultipleComboBox_DropDownClosed;
            }
        }

        void MultipleComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (this.Items.Count > 0 && string.IsNullOrEmpty(this.Text))
            {
                this._ListBox.SelectAll();
            }
        }

        void MultipleComboBox_Loaded(object sender, RoutedEventArgs e)
        {   
            //默认全选
            if (this.Items.Count > 0 && string.IsNullOrEmpty(this.Text) && this.IsDropDownOpen == false && !IsFirstLoad)
            {
                this._ListBox.SelectAll();
                IsFirstLoad = true;
            }
        }

        void _ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.SelectedItems)
            {
                sb.Append(item.ToString()).Append(",");
            }
            this.Text = sb.ToString().TrimEnd(',');
        }

        public void SelectAll()
        {
            Dispatcher.Invoke(new Action(() => 
            {   
                //...
                if (this._ListBox != null)
                {
                    this._ListBox.SelectAll();
                }
            }));
        }

        public void UnselectAll()
        {
            this._ListBox.UnselectAll();
        }
        #endregion
    }
}
