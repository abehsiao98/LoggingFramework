using LoggingFramework.Loggers.Enums;
using LoggingFramework.Loggers.Exporters;
using LoggingFramework.Loggers.Layouts;

namespace LoggingFramework.Loggers;

public class Logger
{
    public Logger(LevelThreshold levelThreshold, IExporter exporter, ILayout layout)
    {
        if (_loggers.ContainsKey("root"))
            throw new ArgumentException($"logger root already exists");
        Name = "root";
        _parent = null;
        _levelThreshold = levelThreshold;
        _exporter = exporter;
        _layout = layout;
        _loggers.Add("root", this);
    }
    public Logger(string name, Logger parent, LevelThreshold? levelThreshold = null, IExporter? exporter = null, ILayout? layout = null)
    {
        if (_loggers.ContainsKey(name))
            throw new ArgumentException($"logger {name} already exists");
        if (parent == null)
            throw new ArgumentNullException("parent logger can't be null");
        Name = name;
        _parent = parent;
        _levelThreshold = levelThreshold;
        _exporter = exporter;
        _layout = layout;
        _loggers.Add(name, this);
    }
    private static readonly Dictionary<string, Logger> _loggers = new();
    private Logger? _parent { get; set; }
    public string Name { get; private set; }
    private LevelThreshold? _levelThreshold;
    private IExporter? _exporter;
    private ILayout? _layout;
    public LevelThreshold LevelThreshold
    {
        get => _levelThreshold ?? _parent!.LevelThreshold;
        set => _levelThreshold = value;
    }
    public IExporter Exporter
    {
        get => _exporter ?? _parent!.Exporter;
        set => _exporter = value;
    }
    public ILayout Layout
    {
        get => _layout ?? _parent!.Layout;
        set => _layout = value;
    }
    public void Log(LevelThreshold level, string message)
    {
        if (LevelThreshold <= level)
            Exporter.Export(Layout.GetFormatMessage(level, Name, message));
    }

    public static Logger GetLogger(string name)
    {
        if (_loggers.TryGetValue(name, out var logger))
            return logger;
        throw new KeyNotFoundException($"logger {name} doesn't exists");
    }
}