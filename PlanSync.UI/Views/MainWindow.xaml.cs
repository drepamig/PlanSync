using MahApps.Metro.Controls;
using PlanSync.UI.ViewModels;
using ReactiveUI;

namespace PlanSync.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, IViewFor<MainWindowViewModel>
    {
        public MainWindow()
        {
            ViewModel = new MainWindowViewModel();
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.Bind(ViewModel, vm => vm.SettingsFlyoutVisible, v => v.SettingsFlyout.IsOpen));
                d(this.BindCommand(ViewModel, vm => vm.SettingsToggle, v => v.SettingsToggle));
                d(this.OneWayBind(ViewModel, vm => vm.Settings.GlobalPlanPath, v => v.GlobalPath.Text));
                d(this.OneWayBind(ViewModel, vm => vm.Settings.GPSPlanPath, v => v.GPSPath.Text));

                d(this.BindCommand(ViewModel, vm=> vm.SelectPathCommand, v=> v.))
            });
        }

        public MainWindowViewModel ViewModel { get; set; }
        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = (MainWindowViewModel)value; }
    }
}