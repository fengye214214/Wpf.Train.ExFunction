using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpf.Train.Common;
using Wpf.Train.Entiry;
using ZED.IVMS7200;

namespace Wpf.Train.UI
{
    public class IVMSTreeListViewModel : ViewModelBase
    {
        #region 变量定义
        private readonly IDevice devService;
        #endregion
        #region 属性定义
        /// <summary>
        /// node ID
        /// </summary>
        public string Node { get; set; }


        private string nodeImage;
        /// <summary>
        /// 结点图片
        /// </summary>
        public string NodeImage
        {
            get { return nodeImage; }
            set
            {
                if (value != this.nodeImage)
                {
                    nodeImage = value;
                    OnPropertyChanged(() => this.NodeImage);
                }
            }
        }

        /// <summary>
        /// 结点名称
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 父结点
        /// </summary>
        public string ParentNode { get; set; }

        private bool isNodeExpanded;
        /// <summary>
        /// 结点是否展开
        /// </summary>
        public bool IsNodeExpanded
        {
            get { return isNodeExpanded; }
            set
            {
                if (value != this.isNodeExpanded)
                {
                    isNodeExpanded = value;
                    OnPropertyChanged(() => this.IsNodeExpanded);
                    if (this.ChildrenList.Count <= 0)
                    {
                        return;
                    }
                    if (isNodeExpanded)
                    {
                        this.NodeImage = "/Wpf.Train.CustomControlLib;component/ImgResources/communication_organization_yrjhzk.png";
                    }
                    else
                    {
                        this.NodeImage = "/Wpf.Train.CustomControlLib;component/ImgResources/communication_organization_yrjhwzk.png";
                    }
                }
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        public Object NodeData { get; set; }

        /// <summary>
        /// 子结点
        /// </summary>
        public List<IVMSTreeListViewModel> ChildrenList { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Node, NodeImage);
        }
        #endregion

        #region 构造函数
        public IVMSTreeListViewModel()
        {
            ChildrenList = new List<IVMSTreeListViewModel>();
            NodeData = null;
            Node = string.Empty;
            nodeImage = "/Wpf.Train.CustomControlLib;component/ImgResources/deltext.png";
            NodeName = string.Empty;
            ParentNode = string.Empty;
            isNodeExpanded = false;
            devService = new DeviceService();
        }
        #endregion

        #region 方法
        public SOAPResponseCmd<List<IVMSTreeListViewModel>> GetDeviceTreeList(string userName, string pwd, uint line = 1)
        {   
            //定义返回值
            var resultList = new SOAPResponseCmd<List<IVMSTreeListViewModel>>();
            resultList.Data = new List<IVMSTreeListViewModel>();
            //调用服务
            var treeInfo = devService.GetDevTreeInfo(userName, pwd, line);
            resultList.ErrorCode = treeInfo.ErrorCode;
            resultList.Message = treeInfo.Message;
            if (!"200".Equals(resultList.ErrorCode))
            {   
                //失败
                return resultList;
            }
            InitOrg(treeInfo.Data, resultList.Data);
            return resultList;
        }

        private void InitOrg(DevTreeInfo devList, List<IVMSTreeListViewModel> treeListViewModel)
        {
                if (devList.AreaList.Count <= 0)
                    return;

                //获取组织机构parentNode号码
                List<int> rootNumberList = devList.AreaList.Select(x => Convert.ToInt32(x.AreaId)).ToList().Distinct().ToList().OrderBy(x => x).ToList();
                //如果组织机构父节点没有在parentNode里面。返回的数据有错，返回了两条ID相同的数据，所以要做处理
                var rootOrgList = devList.AreaList.Where(x => !rootNumberList.Any(y => y.ToString() == x.ParentAreaId)).ToList();
                //创建组织机构根节点
                foreach (var item in rootOrgList)
                {
                    var orgModel = new IVMSTreeListViewModel();
                    orgModel.ParentNode = item.ParentAreaId;
                    orgModel.Node = item.AreaId;
                    orgModel.NodeName = item.AreaName;
                    orgModel.NodeImage = "/Wpf.Train.CustomControlLib;component/ImgResources/communication_organization_yrjhzk.png";
                    orgModel.IsNodeExpanded = true;
                treeListViewModel.Add(orgModel);
                }
                //因为获取的数据中有两条ID相同的"青岛分公司"，删除掉父节点不是-1的青岛分公司
                treeListViewModel.RemoveAll(x => !"-1".Equals(x.ParentNode));
                //添加组织机构子节点
                AddOrgNode(treeListViewModel, devList.AreaList.ToList());
                //添加设备
                AddDeviceNode(treeListViewModel, devList.DeviceNodeList.ToList());
        }

        private void AddOrgNode(List<IVMSTreeListViewModel> orgList, List<Area> areaList)
        {
            foreach (var item in orgList)
            {
                if (areaList.Any(x => x.ParentAreaId == item.Node))
                {
                    var newList = areaList.Where(x => x.ParentAreaId == item.Node).ToList();
                    foreach (var itemNew in newList)
                    {
                        var orgModel = new IVMSTreeListViewModel();
                        orgModel.Node = itemNew.AreaId;
                        orgModel.NodeName = itemNew.AreaName;
                        orgModel.ParentNode = item.Node;
                        orgModel.NodeData = itemNew;
                        orgModel.NodeImage = "/Wpf.Train.CustomControlLib;component/ImgResources/communication_organization_yrjhwzk.png";

                        item.ChildrenList.Add(orgModel);
                        areaList.RemoveAll(x => x.AreaId == orgModel.Node);
                    }
                }
                AddOrgNode(item.ChildrenList, areaList);
            }
        }

        private void AddDeviceNode(List<IVMSTreeListViewModel> list, List<DeviceNode> deviceNodeList)
        {
            foreach (var item in list)
            {
                if (deviceNodeList.Any(x => x.ParentNodeId == item.Node))
                {
                    var newList = deviceNodeList.Where(x => x.ParentNodeId == item.Node).ToList();

                    foreach (var itemNew in newList)
                    {
                        var model = new IVMSTreeListViewModel();
                        model.ParentNode = itemNew.ParentNodeId;
                        model.NodeName = itemNew.Devicename;
                        model.Node = itemNew.Deviceid;
                        model.NodeData = itemNew;
                        model.NodeImage = "/Wpf.Train.CustomControlLib;component/ImgResources/tree_tvwall_monitor_list3.png";

                        item.ChildrenList.Add(model);
                        deviceNodeList.RemoveAll(x => x.Deviceid == model.Node);
                    }
                }
                AddDeviceNode(item.ChildrenList, deviceNodeList);
            }
        }
        #endregion
    }
}
