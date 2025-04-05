using LoggingFramework.Loggers;
using LoggingFramework.Loggers.Enums;

namespace LoggingFramework;

public class Ai
{
    private Logger _logger { get; set; } = Logger.GetLogger("app.game.ai");
    public string Name { get; set; }
    public void MakeDecision()
    {
        _logger.Log(LevelThreshold.TRACE, $"{Name} starts making decisions...");
        _logger.Log(LevelThreshold.WARN, $"{Name} decides to give up.");
        _logger.Log(LevelThreshold.ERROR, "Something goes wrong when AI gives up.");
        _logger.Log(LevelThreshold.TRACE, $"{Name} completes its decision.");
    }
}