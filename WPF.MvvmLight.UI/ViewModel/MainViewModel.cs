using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using System.Threading;
using WPF.MvvmLight.UI.Model;

namespace WPF.MvvmLight.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {   
        /// <summary>
        /// 数据服务
        /// </summary>
        private readonly IDataService _dataService;
        /// <summary>
        /// 窗口服务
        /// </summary>
        private readonly MvvmDialogs.IDialogService DialogService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public RelayCommand CommitCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            DialogService = new DialogService();

            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;

                    WelcomeTitle = "测试多少度";
                });

            CommitCommand = new RelayCommand(() => 
            {
                var settings = new OpenFileDialogSettings
                {
                    Title = "Open",
                    Filter = "Sample (.xml)|*.xml",
                    CheckFileExists = false
                };

                bool? success = DialogService.ShowOpenFileDialog(this, settings);

            });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}