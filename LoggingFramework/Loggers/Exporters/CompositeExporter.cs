namespace LoggingFramework.Loggers.Exporters;

public class CompositeExporter : IExporter
{
    public CompositeExporter(params IExporter[] exporters) => _subExporter = new List<IExporter>(exporters);
    private List<IExporter> _subExporter { get; set; }
    public void AddExporter(IExporter exporter) => _subExporter.Add(exporter);
    public void Export(string formatMessage) => _subExporter.ForEach(exporter => exporter.Export(formatMessage));
}