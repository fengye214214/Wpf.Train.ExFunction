using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;

namespace Wpf.Train.UI
{   
    /// <summary>
    /// 皮肤视图
    /// </summary>
    public class SkinViewModel : ViewModelBase
    {
        /// <summary>
        /// 皮肤资源文件路径
        /// </summary>
        public string ResFilePath { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 皮肤资源列表
        /// </summary>
        public static List<SkinViewModel> SkinResList
        {
            get
            {
                var skinList = new List<SkinViewModel>();
                skinList.Add(new SkinViewModel()
                {
                    ID = "1",
                    Remark = "白色背景",
                    ResFilePath = "/Wpf.Train.CustomControlLib;component/Themes/DefaultStyle.xaml"
                });
                skinList.Add(new SkinViewModel() 
                {
                     ID = "2",
                     Remark = "黑色背景",
                     ResFilePath = "/Wpf.Train.CustomControlLib;component/Themes/SecondStyle.xaml"
                });
                skinList.Add(new SkinViewModel()
                {
                    ID = "3",
                    Remark = "蓝色背景",
                    ResFilePath = "/Wpf.Train.CustomControlLib;component/Themes/ThirdStyle.xaml"
                });
                return skinList;
            }
        }

        #region 方法定义

        public void ChangeSkin(SkinViewModel skinModel)
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
            var oldSkinRes = Application.Current.Resources.MergedDictionaries.Where(x => SkinResList.Any(y => Path.GetFileName(y.ResFilePath) == Path.GetFileName(x.Source.OriginalString))).SingleOrDefault();
            if (oldSkinRes == null)
            {
                return;
            }
            Application.Current.Resources.MergedDictionaries.Remove(oldSkinRes);
            Application.Current.Resources.MergedDictionaries.Add(newSkinRes);
        }
        #endregion
    }
}
