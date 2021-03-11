using Flow.Launcher.Infrastructure.Storage;
using System.Windows;
using System.Windows.Forms;

namespace Wox.Plugin.Todos
{
    /// <summary>
    /// Interaction logic for FilePathSetting.xaml
    /// </summary>
    public partial class FilePathSetting
    {
        private Settings _setting;
        private PluginJsonStorage<Settings> _storage;

        public FilePathSetting(Settings setting, PluginJsonStorage<Settings> storage)
        {
            InitializeComponent();
            _setting = setting;
            Directory.Text = _setting.FolderPath;
            _storage = storage;
        }

        private void ChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var path = dialog.SelectedPath;
                Directory.Text = path;
                _setting.FolderPath = path;
                _storage.Save();
            }
        }
    }
}
