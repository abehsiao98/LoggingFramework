using LoggingFramework.Loggers;
using LoggingFramework.Loggers.Enums;

namespace LoggingFramework;

public class Game()
{
    private Logger _logger { get; set; } = Logger.GetLogger("app.game");
    private List<Ai> _players { get; set; } = new()
    {
        new() { Name = "AI 1" },
        new() { Name = "AI 2" },
        new() { Name = "AI 3" },
        new() { Name = "AI 4" }
    };
    public void Start()
    {
        _logger.Log(LevelThreshold.INFO, "The game begins.");
        foreach (var ai in _players)
        {
            _logger.Log(LevelThreshold.TRACE, $"The player *{ai.Name}* begins his turn.");
            ai.MakeDecision();
            _logger.Log(LevelThreshold.TRACE, $"The player *{ai.Name}* finishes his turn.");
        }
        _logger.Log(LevelThreshold.DEBUG, "Game ends.");
    }
}