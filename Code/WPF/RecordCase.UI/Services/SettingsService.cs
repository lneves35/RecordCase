using RecordCase.UI.Properties;

namespace RecordCase.UI.Services
{
    public static class SettingsService
    {
        public static void AddDatabase(string fullPath)
        {
            Settings.Default.DatabaseCollection.Add(fullPath);
            Settings.Default.Save();
        }
    }
}
