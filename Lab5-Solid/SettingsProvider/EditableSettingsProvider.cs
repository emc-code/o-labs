using Lab5_Solid.SettingsGenerator;
using System.Text.Json;

namespace Lab5_Solid.SettingsProvider;

/// <summary>
/// Для LSP
/// Чтение\инициализация + запись настроек
/// </summary>
internal class EditableSettingsProvider : ReadOnlySettingsProvider
{
    public EditableSettingsProvider(IInitializer initializer) : base(initializer)
    { }

    public void SaveSettings(SettingsDto settings, string filePath)
    {
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
