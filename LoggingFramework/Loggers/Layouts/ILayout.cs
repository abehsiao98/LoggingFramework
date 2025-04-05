using LoggingFramework.Loggers.Enums;

namespace LoggingFramework.Loggers.Layouts;
public interface ILayout
{
    string DataTimeFormat { get; }
    string GetFormatMessage(LevelThreshold level, string loggerName, string message);
}