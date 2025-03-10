using Microsoft.Extensions.Logging;
using WelcomeExtended.Helpers;

namespace WelcomeExtended.Others
{
    public class Delegates
    {
        public static readonly ILogger consoleLogger = LoggerHelper.GetLogger("Hello", Console.Out);
        public static readonly StreamWriter file = new(@"log.txt");
        public static readonly ILogger fileLogger = LoggerHelper.GetLogger("Hello", file);
        public static void Log(string error)
        {
            consoleLogger.LogError(error);
            fileLogger.LogError(error);
        }
        public static void Log2(string error)
        {
            Console.WriteLine("- DELEGATES -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        }
    }
}
