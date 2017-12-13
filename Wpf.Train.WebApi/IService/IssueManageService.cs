using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wpf.Train.Common;
using Wpf.Train.Entiry;

namespace Wpf.Train.WebApi
{
    public class IssueManageService : IIssueManage
    {
        public ResponseCmd<List<Issue>> GetAllIssues()
        {
            var webApiService = new Uri("http://localhost:59766/api/Issue/GetAsync");
            var httpCli = new HttpClient();
            var result = httpCli.GetAsync(webApiService).Result;
            var res = result.Content.ReadAsStringAsync().Result;
            return ResponseCmd<List<Issue>>.CreateResponseCmd(res);
        }
    }
}
