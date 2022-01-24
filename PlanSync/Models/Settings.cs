using DynamicData.Binding;
using Newtonsoft.Json;
using ReactiveUI;
using System.Reactive;

namespace PlanSync.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Settings : ReactiveObject
    {
        private static string SettingsLocation { get; } = Path.Join(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "settings.json");

        public Settings()
        {
#if DEBUG
            GPSPlanPath = @"C:\Games\FS2020\Community\pms50-gns530\fpl530";
#endif

            GlobalPlanPath = Environment.ExpandEnvironmentVariables(@"%appdata%\Microsoft Flight Simulator\");

            SaveSettings = ReactiveCommand.CreateFromTask(() => SaveSettingsAction(SettingsLocation));

            this.WhenAnyPropertyChanged().InvokeCommand(SaveSettings);
        }

        private async Task SaveSettingsAction(string path)
        {
            await using StreamWriter createStream = new(path, append: false);
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            createStream.Write(json);
        }

        private ReactiveCommand<Unit, Unit> SaveSettings { get; }

        [JsonProperty]
        public string GlobalPlanPath { get; set; }

        [JsonProperty]
        public string GPSPlanPath { get; set; }

        public static async Task<Settings> ReadOrCreate()
        {
            if (!File.Exists(SettingsLocation))
            {
                var settings = new Settings();
                await settings.SaveSettingsAction(SettingsLocation);
            }
            using StreamReader r = new(SettingsLocation);
            return JsonConvert.DeserializeObject<Settings>(r.ReadToEnd());
        }
    }
}