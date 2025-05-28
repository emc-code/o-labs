namespace Lab5_Solid.SettingsProvider;

internal interface ISettingsSaver
{
    public void SaveSettings(SettingsDto settings, string filePath);
}
