using LoggingFramework.Loggers.Enums;

namespace LoggingFramework.Loggers.Layouts;

public class StandardLayout : ILayout
{
    public string DataTimeFormat { get; } = "yyyy-MM-dd HH:mm:ss.SSS";
    public string GetFormatMessage(LevelThreshold level, string loggerName, string message) => $"{DateTime.Now.ToString(DataTimeFormat)} | - {Enum.GetName(typeof(LevelThreshold), level)} {loggerName} - {message}";
}