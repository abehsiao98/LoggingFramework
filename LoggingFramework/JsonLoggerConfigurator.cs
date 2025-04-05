using LoggingFramework.Loggers.Enums;
using LoggingFramework.Loggers.Exporters;
using LoggingFramework.Loggers.Layouts;
using LoggingFramework.Loggers;
using Newtonsoft.Json.Linq;

namespace LoggingFramework;

public class JsonLoggerConfigurator
{
    public void JsonConvertLogger(JToken config, Logger? parentLogger = null)
    {
        if (parentLogger == null)
            parentLogger = CreateLogger(config);
        foreach (var property in config.Children<JProperty>())
        {
            if (property.Name == "levelThreshold" || property.Name == "exporter" || property.Name == "layout")
                continue;

            var loggerConfig = property.Value;
            var logger = CreateLogger(loggerConfig, property.Name, parentLogger);
            JsonConvertLogger(loggerConfig, logger);
        }
    }
    private Logger CreateLogger(JToken config, string? name = null, Logger? parent = null)
    {
        var levelThreshold = config["levelThreshold"] != null ? Enum.Parse<LevelThreshold>(config["levelThreshold"].ToString()) : (LevelThreshold?)null;
        var exporter = config["exporter"] != null ? CreateExporter(config["exporter"]) : null;
        var layout = config["layout"]?.ToString() != null ? CreateLayout(config["layout"].ToString()) : null;

        return parent == null
            ? new Logger(levelThreshold ?? throw new ArgumentNullException("root's levelThreshold can't be null"), exporter ?? throw new ArgumentNullException("root's exporter can't be null"), layout ?? throw new ArgumentNullException("root's layout can't be null"))
            : new Logger(name!, parent, levelThreshold, exporter, layout);
    }
    private IExporter CreateExporter(JToken config)
    {
        var type = config["type"].ToString();
        return type switch
        {
            "console" => new ConsoleExporter(),
            "file" => new FileExporter(config["fileName"].ToString()),
            "composite" => new CompositeExporter(config["children"].Select(CreateExporter).ToArray()),
            _ => throw new ArgumentException($"unknown exporter")
        };
    }
    private ILayout CreateLayout(string config)
    {
        return config switch
        {
            "standard" => new StandardLayout(),
            _ => throw new ArgumentException($"unknown layout")
        };
    }
}