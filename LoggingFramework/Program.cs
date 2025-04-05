using LoggingFramework;
using Newtonsoft.Json.Linq;

//var root = new Logger(LevelThreshold.DEBUG, new ConsoleExporter(), new StandardLayout());
//var gameLogger = new Logger("app.game", root, LevelThreshold.INFO, new CompositeExporter(
//            new ConsoleExporter(),
//            new CompositeExporter(
//                new FileExporter("game.log"),
//                new FileExporter("game.backup.log")
//)));
//var aiLogger = new Logger("app.game.ai", gameLogger, LevelThreshold.TRACE);

var path = Directory.GetCurrentDirectory();
var jsonConfig = File.ReadAllText(Path.Combine(path, "config.json"));
var config = JObject.Parse(jsonConfig);
var configurator = new JsonLoggerConfigurator();
configurator.JsonConvertLogger(config["loggers"]);
var game = new Game();
game.Start();