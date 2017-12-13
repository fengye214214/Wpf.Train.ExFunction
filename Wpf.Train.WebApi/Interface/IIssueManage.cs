using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Train.Common;
using Wpf.Train.Entiry;

namespace Wpf.Train.WebApi
{
    public interface IIssueManage
    {
        ResponseCmd<List<Issue>> GetAllIssues();
    }
}
