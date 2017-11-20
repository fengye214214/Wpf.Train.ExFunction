using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.Train.UI
{   
    /// <summary>
    /// 用户信息ViewModel
    /// </summary>
    public class SubscriberInfoViewModel : ViewModelBase
    {
        /// <summary>
        /// 终端号码
        /// </summary>
        private string number;

        public string Number
        {
            get { return number; }
            set
            {

                if (value != this.number)
                {
                    number = value;
                    OnPropertyChanged(() => this.Number);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string linkVoiceNumber;

        public string LinkVoiceNumber
        {
            get { return linkVoiceNumber; }
            set
            {

                if (value != this.linkVoiceNumber)
                {
                    linkVoiceNumber = value;
                    OnPropertyChanged(() => this.LinkVoiceNumber);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string linkVideoNumber;

        public string LinkVideoNumber
        {
            get { return linkVideoNumber; }
            set
            {
                if (value != this.linkVideoNumber)
                {
                    linkVideoNumber = value;
                    OnPropertyChanged(() => this.LinkVideoNumber);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int level;

        public int Level
        {
            get { return level; }
            set
            {
                if (value != this.level)
                {
                    level = value;
                    OnPropertyChanged(() => this.Level);
                }
            }
        }

        /// <summary>
        /// 终端所在PBX的ID
        /// </summary>
        private string pBXId;

        public string PBXId
        {
            get { return pBXId; }
            set
            {
                if (value != this.pBXId)
                {
                    pBXId = value;
                    OnPropertyChanged(() => this.PBXId);
                }
            }
        }

        /// <summary>
        ///  若终端类型为 DISP_TYPE_CONFERENCE， Moderator 为主持人密码，其它类型无效。
        /// </summary>
        private string moderator;

        public string Moderator
        {
            get { return moderator; }
            set
            {
                if (value != this.moderator)
                {
                    moderator = value;
                    OnPropertyChanged(() => this.Moderator);
                }
            }
        }

        /// <summary>
        /// 若终端类型为 DISP_TYPE_CONFERENCE， Participant 为与会者密码，其它类型无效。
        /// </summary>
        private string participant;

        public string Participant
        {
            get { return participant; }
            set
            {
                if (value != this.participant)
                {
                    participant = value;
                    OnPropertyChanged(() => this.Participant);
                }
            }
        }

        /// <summary>
        /// 若终端类型为 DISP_TYPE_POST， nAnalogTerminal 模拟终端号。
        /// </summary>
        private int analogTerminal;

        public int AnalogTerminal
        {
            get { return analogTerminal; }
            set
            {
                if (value != this.analogTerminal)
                {
                    analogTerminal = value;
                    OnPropertyChanged(() => this.AnalogTerminal);
                }
            }
        }

        private bool isEnableVideo;

        public bool IsEnableVideo
        {
            get { return isEnableVideo; }
            set
            {
                if (value != this.isEnableVideo)
                {
                    isEnableVideo = value;
                    OnPropertyChanged(() => this.IsEnableVideo);
                }
            }
        }

        private bool isEnableAudio;

        public bool IsEnableAudio
        {
            get { return isEnableAudio; }
            set
            {
                if (value != this.isEnableAudio)
                {
                    isEnableAudio = value;
                    OnPropertyChanged(() => this.IsEnableAudio);
                }
            }
        }

        private bool isRecordAudio;

        public bool IsRecordAudio
        {
            get { return isRecordAudio; }
            set
            {
                if (value != this.isRecordAudio)
                {
                    isRecordAudio = value;
                    OnPropertyChanged(() => this.IsRecordAudio);
                }
            }
        }

        private bool isRecordVideo;

        public bool IsRecordVideo
        {
            get { return isRecordVideo; }
            set
            {
                if (value != this.isRecordVideo)
                {
                    isRecordVideo = value;
                    OnPropertyChanged(() => this.IsRecordVideo);
                }
            }
        }

        /// <summary>
        ///  若终端类型为 DISP_TYPE_HUNTGROUP， true 为平衡轮询组， false 为优先轮询组。
        /// </summary>
        private bool isHunt;

        public bool IsHunt
        {
            get { return isHunt; }
            set
            {
                if (value != this.isHunt)
                {
                    isHunt = value;
                    OnPropertyChanged(() => this.IsHunt);
                }
            }
        }

        /// <summary>
        /// 如果为 true 允许终端登录，否则不允许终端登录。
        /// </summary>
        private bool isAllowLogin;

        public bool IsAllowLogin
        {
            get { return isAllowLogin; }
            set
            {
                if (value != this.isAllowLogin)
                {
                    isAllowLogin = value;
                    OnPropertyChanged(() => this.IsAllowLogin);
                }
            }
        }

        /// <summary>
        /// 若终端类型为 DISP_TYPE_DISPATCHER， true 为 GVS 用户类型
        /// </summary>
        private bool isGvsUser;

        public bool IsGvsUser
        {
            get { return isGvsUser; }
            set
            {
                if (value != this.isGvsUser)
                {
                    isGvsUser = value;
                    OnPropertyChanged(() => this.IsGvsUser);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool isGVSLinked;

        public bool IsGVSLinked
        {
            get { return isGVSLinked; }
            set
            {
                if (value != this.isGVSLinked)
                {
                    isGVSLinked = value;
                    OnPropertyChanged(() => this.IsGVSLinked);
                }
            }
        }

        /// <summary>
        ///  若终端类型为 DISP_TYPE_DISPATCHER， true 为 GTS 用户类型。
        /// </summary>
        private bool isGtsUser;

        public bool IsGtsUser
        {
            get { return isGtsUser; }
            set
            {
                if (value != this.isGtsUser)
                {
                    isGtsUser = value;
                    OnPropertyChanged(() => this.IsGtsUser);
                }
            }
        }

        /// <summary>
        /// 若终端类型为 DISP_TYPE_DISPATCHER， true 为海康 28181 用户类型。
        /// </summary>
        private bool is28181User;

        public bool Is28181User
        {
            get { return is28181User; }
            set
            {
                if (value != this.is28181User)
                {
                    is28181User = value;
                    OnPropertyChanged(() => this.Is28181User);
                }
            }
        }

        /// <summary>
        /// 如果为 true 只显示终端所在组，否则显示所有组。
        /// </summary>
        private bool isOnlyShowMyGroup;

        public bool IsOnlyShowMyGroup
        {
            get { return isOnlyShowMyGroup; }
            set
            {
                if (value != this.isOnlyShowMyGroup)
                {
                    isOnlyShowMyGroup = value;
                    OnPropertyChanged(() => this.IsOnlyShowMyGroup);
                }
            }
        }

        private bool isVoiceAndVideoInOrderForLinkVideo;

        public bool IsVoiceAndVideoInOrderForLinkVideo
        {
            get { return isVoiceAndVideoInOrderForLinkVideo; }
            set
            {
                if (value != this.isVoiceAndVideoInOrderForLinkVideo)
                {
                    isVoiceAndVideoInOrderForLinkVideo = value;
                    OnPropertyChanged(() => this.IsVoiceAndVideoInOrderForLinkVideo);
                }
            }
        }

        private bool isVideoMeanwhileVoiceForLinkVideo;

        public bool IsVideoMeanwhileVoiceForLinkVideo
        {
            get { return isVideoMeanwhileVoiceForLinkVideo; }
            set
            {
                if (value != this.isVideoMeanwhileVoiceForLinkVideo)
                {
                    isVideoMeanwhileVoiceForLinkVideo = value;
                    OnPropertyChanged(() => this.IsVideoMeanwhileVoiceForLinkVideo);
                }
            }
        }

        /// <summary>
        /// 终端名称
        /// </summary>
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != this.name)
                {
                    name = value;
                    OnPropertyChanged(() => this.Name);
                }
            }
        }

        private bool isPdtUser;

        public bool IsPdtUser
        {
            get { return isPdtUser; }
            set
            {
                if (value != this.isPdtUser)
                {
                    isPdtUser = value;
                    OnPropertyChanged(() => this.IsPdtUser);
                }
            }
        }

        private bool isDmrUser;

        public bool IsDmrUser
        {
            get { return isDmrUser; }
            set
            {
                if (value != this.isDmrUser)
                {
                    isDmrUser = value;
                    OnPropertyChanged(() => this.IsDmrUser);
                }
            }
        }

        /// <summary>
        /// 经度
        /// </summary>
        private string longitude;

        public string Longitude
        {
            get { return longitude; }
            set
            {
                if (value != this.longitude)
                {
                    longitude = value;
                    OnPropertyChanged(() => this.Longitude);
                }
            }
        }

        /// <summary>
        /// 纬度
        /// </summary>
        private string latitude;

        public string Latitude
        {
            get { return latitude; }
            set
            {
                if (value != this.latitude)
                {
                    latitude = value;
                    OnPropertyChanged(() => this.Latitude);
                }
            }
        }

        /// <summary>
        /// 高度
        /// </summary>
        private string altitude;

        public string Altitude
        {
            get { return altitude; }
            set
            {
                if (value != this.altitude)
                {
                    altitude = value;
                    OnPropertyChanged(() => this.Altitude);
                }
            }
        }

        private string homeNumber;

        public string HomeNumber
        {
            get { return homeNumber; }
            set
            {
                if (value != this.homeNumber)
                {
                    homeNumber = value;
                    OnPropertyChanged(() => this.HomeNumber);
                }
            }
        }

        private string officeNumber;

        public string OfficeNumber
        {
            get { return officeNumber; }
            set
            {
                if (value != this.officeNumber)
                {
                    officeNumber = value;
                    OnPropertyChanged(() => this.OfficeNumber);
                }
            }
        }

        private string cellPhoneNumber;

        public string CellPhoneNumber
        {
            get { return cellPhoneNumber; }
            set
            {
                if (value != this.cellPhoneNumber)
                {
                    cellPhoneNumber = value;
                    OnPropertyChanged(() => this.CellPhoneNumber);
                }
            }
        }

        private string imageSource;

        public string ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                if (value != this.imageSource)
                {
                    imageSource = value;
                    OnPropertyChanged(() => this.ImageSource);
                }
            }
        }

        private string callStatusImageSource;
        /// <summary>
        /// 用户呼叫时的图片状态
        /// </summary>
        public string CallStatusImageSource
        {
            get { return callStatusImageSource; }
            set
            {
                if (value != this.callStatusImageSource)
                {
                    callStatusImageSource = value;
                    OnPropertyChanged(() => this.CallStatusImageSource);
                }
            }
        }

        private string devTypeImageSource;
        /// <summary>
        /// 设备类别图片
        /// </summary>
        public string DevTypeImageSource
        {
            get { return devTypeImageSource; }
            set
            {
                if (value != this.devTypeImageSource)
                {
                    devTypeImageSource = value;
                    OnPropertyChanged(() => this.DevTypeImageSource);
                }
            }
        }

        private string statusName;
        /// <summary>
        /// 用户状态名称
        /// </summary>
        public string StatusName
        {
            get { return statusName; }
            set
            {
                if (value != this.statusName)
                {
                    statusName = value;
                    OnPropertyChanged(() => this.StatusName);
                }
            }
        }

        private string oppNumber;
        /// <summary>
        /// 对端号码
        /// </summary>
        public string OppNumber
        {
            get { return oppNumber; }
            set
            {
                if (value != this.oppNumber)
                {
                    oppNumber = value;
                    OnPropertyChanged(() => this.OppNumber);
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} : {1}", Name, Number);
        }

        private string cahceFirstName;

        public string CahceFirstName
        {
            get { return cahceFirstName; }
            set
            {
                if (value != this.cahceFirstName)
                {
                    cahceFirstName = value;
                    OnPropertyChanged(() => this.CahceFirstName);
                }
            }
        }

        private string checkBoxVisibility = "Collapsed";

        public string CheckBoxVisibility
        {
            get { return checkBoxVisibility; }
            set
            {
                if (value != this.checkBoxVisibility)
                {
                    checkBoxVisibility = value;
                    OnPropertyChanged(() => this.CheckBoxVisibility);
                }
            }
        }
    }
}
