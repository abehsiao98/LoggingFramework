namespace LoggingFramework.Loggers.Exporters;

public class FileExporter(string fileName) : IExporter
{
    private string _fileName = fileName;
    public void Export(string formatMessage) => File.AppendAllText($"{Path.Combine(Directory.GetCurrentDirectory(), _fileName)}", formatMessage + Environment.NewLine);
}