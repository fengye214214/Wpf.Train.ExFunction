using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.Train.UI
{
    public class LangueViewModel : ViewModelBase
    {
        #region 属性定义
        /// <summary>
        /// 语言资源文件路径
        /// </summary>
        public string ResFilePath { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 语言资源列表
        /// </summary>
        public static List<LangueViewModel> LangueResList
        {
            get
            {
                var skinList = new List<LangueViewModel>();
                skinList.Add(new LangueViewModel()
                {
                    ID = "1",
                    Remark = "中文",
                    ResFilePath = "/Wpf.Train.UI;component/Language/ZH_CN.xaml"
                });
                skinList.Add(new LangueViewModel()
                {
                    ID = "2",
                    Remark = "英文",
                    ResFilePath = "/Wpf.Train.UI;component/Language/EN_US.xaml"
                });
                return skinList;
            }
        }

        #region 方法定义

        public void ChangeLangue(LangueViewModel skinModel)
        {
            if (skinModel == null)
            {
                return;
            }
            var newSkinRes = Application.LoadComponent(new Uri(skinModel.ResFilePath, UriKind.RelativeOrAbsolute)) as ResourceDictionary;
            if (newSkinRes == null)
            {
                return;
            }
            newSkinRes.Source = new Uri(skinModel.ResFilePath, UriKind.RelativeOrAbsolute);
            var oldSkinRes = Application.Current.Resources.MergedDictionaries.Where(x => LangueResList.Any(y => Path.GetFileName(y.ResFilePath) == Path.GetFileName(x.Source.OriginalString))).SingleOrDefault();
            if (oldSkinRes == null)
            {
                return;
            }
            Application.Current.Resources.MergedDictionaries.Remove(oldSkinRes);
            Application.Current.Resources.MergedDictionaries.Add(newSkinRes);
        }
        #endregion
        #endregion
    }
}
