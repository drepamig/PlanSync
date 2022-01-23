using ReactiveUI;

namespace PlanSync.UI.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            Greeting = "hello from the vm";
        }

        public string Greeting { get; set; }
    }
}