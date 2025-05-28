namespace Lab5_Solid.SettingsProvider;

internal interface ISettingsReader
{
    public SettingsDto ReadSettings(string filePath);
}
