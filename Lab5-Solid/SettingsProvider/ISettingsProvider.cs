namespace Lab5_Solid.SettingsProvider;

internal interface ISettingsProvider
{
    public SettingsDto LoadSettings(string filePath);
}
