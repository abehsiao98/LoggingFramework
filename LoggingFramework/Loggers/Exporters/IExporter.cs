namespace LoggingFramework.Loggers.Exporters;

public interface IExporter
{
    void Export(string formatMessage);
}