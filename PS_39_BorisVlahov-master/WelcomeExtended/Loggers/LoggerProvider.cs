using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    class LoggerProvider : ILoggerProvider
    {
        private TextWriter _output;

        public LoggerProvider(System.IO.TextWriter output)
        {
            _output = output;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new HashLogger(categoryName, _output);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
