using Lab5_Solid;
using Lab5_Solid.Player;
using Lab5_Solid.SettingsGenerator;
using Lab5_Solid.SettingsInitializer;
using Lab5_Solid.SettingsProvider;

/// SRP
/// Классы SettingsProvider - занимаются лишь загрузкой \ сохранением настроек, Player - лишь "игрой" - вводом данных, SettingsInitializer - лишь инициализирует настройки 
/// 
/// OCP
/// SettingsProvider при отсутствии настроек инициализирует их при помощи класса, реализующего интерфейс IInitializer
/// - может из консоли, может генерить рандомно - т.е. поведение расширяется без изменения
/// 
/// LSP
/// EditableSettingsProvider м.б. заменен ReadOnlySettingsProvider и чтение пройдет
/// 
/// ISP - используются небольшие интерфейсы
/// 
/// DIP - класс SettingsProvider зависит от IInitializer, а не конкретного класса
/// 

IInitializer initializer = new RandomInitializer();
ISettingsReader settingsProvider = new ReadWriteSettingsProvider(initializer);

var settings = settingsProvider.ReadSettings(string.Empty);

IPlayer player = new SimulationPlayer(settings.MinValue, settings.MaxValue);

bool result = Run(player, settings);
Console.WriteLine(result);


bool Run(IPlayer player, SettingsDto settings)
{
    int attempt = 0;
    do
    {
        attempt++;

        int value = player.InputValue();
        Console.WriteLine($"attempt: {attempt};   value: {value}");
        if (value == settings.TargetValue)
            return true;
    }
    while (attempt < settings.AttemptCount);

    return false;
}