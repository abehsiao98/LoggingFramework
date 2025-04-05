namespace LoggingFramework.Loggers.Exporters;

public class ConsoleExporter : IExporter
{
    public void Export(string formatMessage) => Console.WriteLine(formatMessage);
}