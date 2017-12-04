using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Wpf.Train.UI
{
    public class TreeViewListViewModel : ViewModelBase
    {
        public TreeViewListViewModel()
        {
            node = string.Empty;
            isChecked = false;
            nodeName = string.Empty;
            ParentNode = null;
            NodeData = null;
            ChildrenList = new ObservableCollection<TreeViewListViewModel>();

            isNodeExpanded = true;
            nodeImage = "\ue613";
        }

        private string node;
        /// <summary>
        /// 结点编号
        /// </summary>
        public string Node
        {
            get { return node; }
            set
            {
                if (value != this.Node)
                {
                    node = value;
                    OnPropertyChanged(() => this.Node);
                }
            }
        }

        private bool isChecked;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (value != this.IsChecked)
                {
                    isChecked = value;
                    OnPropertyChanged(() => this.IsChecked);

                    if (isChecked)
                    {
                        CheckAllNode(ChildrenList, true);

                        //说明时根结点
                        if (this.ParentNode == null)
                            return;

                        if (this.ParentNode.ChildrenList.Count > 0)
                        {
                            bool isChildChecked1 = false;
                            foreach (var item in this.ParentNode.ChildrenList)
                            {
                                if (item.IsChecked == false)
                                {
                                    isChildChecked1 = true;
                                    break;
                                }
                            }

                            //如果全部选中
                            if (isChildChecked1 == false)
                            {
                                //如果不是根结点
                                if (this.ParentNode != null)
                                {
                                    if (this.ParentNode.IsChecked == false)
                                    {
                                        this.ParentNode.IsChecked = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //先取消所有子节点的选中
                        CheckAllNode(ChildrenList, false);

                        //说明时根结点
                        if (this.ParentNode == null)
                            return;

                        if (this.ParentNode.ChildrenList.Count > 0)
                        {
                            bool isChildChecked = false;
                            foreach (var item in this.ParentNode.ChildrenList)
                            {
                                if (item.IsChecked == true)
                                {
                                    isChildChecked = true;
                                    break;
                                }
                            }

                            //如果全部子结点没有选择的话
                            if (!isChildChecked)
                            {
                                if (this.ParentNode.IsChecked == true)
                                {
                                    this.ParentNode.IsChecked = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CheckAllNode(ObservableCollection<TreeViewListViewModel> treeList, bool isChecked)
        {
            foreach (var item in treeList)
            {
                item.IsChecked = isChecked;
                CheckAllNode(item.ChildrenList, isChecked);
            }
        }

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

        private string nodeName;
        /// <summary>
        /// 结点名称
        /// </summary>
        public string NodeName
        {
            get { return nodeName; }
            set
            {
                if (value != this.nodeName)
                {
                    nodeName = value;
                    OnPropertyChanged(() => this.NodeName);
                }
            }
        }

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
                    OnPropertyChanged(() => this.isNodeExpanded);

                    if (this.ChildrenList.Count <= 0)
                        return;

                    //if (isNodeExpanded)
                    //{
                    //    this.NodeImage = "\ue613";
                    //}
                    //else
                    //{
                    //    this.NodeImage = "\ue613";
                    //}
                }
            }
        }

        /// <summary>
        /// 父结点
        /// </summary>
        public TreeViewListViewModel ParentNode { get; set; }
        public Object NodeData { get; set; }
        public ObservableCollection<TreeViewListViewModel> ChildrenList { get; set; }
    }
}
