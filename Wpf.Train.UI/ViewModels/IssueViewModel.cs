using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Train.Common;
using Wpf.Train.WebApi;

namespace Wpf.Train.UI
{
    public class IssueViewModel : ViewModelBase
    {
        #region 属性定义
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string StatusImage { get; set; }
        #endregion

        #region 方法定义
        public ResponseCmd<ObservableCollection<IssueViewModel>> GetIssueList()
        {
            var viewResult  = new ResponseCmd<ObservableCollection<IssueViewModel>>();
            viewResult.data = new ObservableCollection<IssueViewModel>();
            var service = new IssueManageService();

            var result = service.GetAllIssues();

            viewResult.message = result.message;
            viewResult.success = result.success;
            if (!result.success)
            {
                return viewResult;
            }
            if(result.data == null)
            {
                return viewResult;
            }

            foreach(var item in result.data)
            {
                var model = new IssueViewModel()
                {
                     Id =  item.Id,
                     Description = item.Description,
                     Status = item.Status,
                     StatusImage = "我是ViewModel中的Status的描述",
                     Title = item.Title
                };
                viewResult.data.Add(model);
            }

            return viewResult;
        }
        #endregion
    }
}
