namespace Lab5_Solid.SettingsProvider;

internal interface ISettingsWriter
{
    public void WriteSettings(SettingsDto settings, string filePath);
}
