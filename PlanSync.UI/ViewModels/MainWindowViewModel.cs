using PlanSync.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Reactive;

namespace PlanSync.UI.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel(Settings settings = null)
        {
            Settings = settings ?? Locator.Current.GetService<Settings>();
            SettingsToggle = ReactiveCommand.Create(() => { SettingsFlyoutVisible = true; return Unit.Default; });
            SelectPathCommand = ReactiveCommand.Create<string>(SelectPathAction);
        }

        public Interaction<Unit, string> SelectPath { get; } = new();

        public ReactiveCommand<string, Unit> SelectPathCommand { get; }

        public Settings Settings { get; }

        [Reactive]
        public bool SettingsFlyoutVisible { get; set; }

        public ReactiveCommand<Unit, Unit> SettingsToggle { get; }

        private void SelectPathAction(string destination)
        {
            string currentPath;
            Action<string> setter = str => { };

            if (string.Equals(destination, "global", StringComparison.OrdinalIgnoreCase))
            {
                currentPath = Settings.GlobalPlanPath;
                setter = pth => Settings.GlobalPlanPath = pth;
            }
            else if (string.Equals(destination, "gps", StringComparison.OrdinalIgnoreCase))
            {
                currentPath = Settings.GPSPlanPath;
                setter = pth => Settings.GPSPlanPath = pth;
            }

            var diag = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog { SelectedPath = currentPath, Multiselect = false };

            if (diag.ShowDialog() == true)
            {
                setter(diag.SelectedPath);
            }
        }
    }
}