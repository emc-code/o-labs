using Lab5_Solid.SettingsGenerator;
using System.Text.Json;

namespace Lab5_Solid.SettingsProvider;

/// <summary>
/// Чтение\инициализация настроек
/// </summary>
internal class ReadOnlySettingsProvider : ISettingsReader
{
    private readonly IInitializer _initializer;
    public ReadOnlySettingsProvider(IInitializer initializer) => _initializer = initializer;

    public SettingsDto ReadSettings(string filePath)
    {
        if (!File.Exists(filePath))
            return _initializer.Init();

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<SettingsDto>(json);
    }
}
