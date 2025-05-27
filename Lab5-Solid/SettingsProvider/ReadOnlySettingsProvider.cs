using Lab5_Solid.SettingsGenerator;
using System.Text.Json;

namespace Lab5_Solid.SettingsProvider;

internal class ReadOnlySettingsProvider : ISettingsProvider
{
    private readonly IInitializer _initializer;
    public ReadOnlySettingsProvider(IInitializer initializer) => _initializer = initializer;

    public SettingsDto LoadSettings(string filePath)
    {
        if (!File.Exists(filePath))
            return _initializer.Init();

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<SettingsDto>(json);
    }
}
