using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Helpers
{
    static class LoggerHelper
    {
        public static ILogger GetLogger(string categoryName, System.IO.TextWriter output)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoggerProvider(output));

            return loggerFactory.CreateLogger(categoryName);
        }
    }
}
