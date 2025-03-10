using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;

namespace WelcomeExtended.Loggers
{
    class HashLogger : ILogger
    {
        private class Message
        {
            public string Text { get; set; }
            public LogLevel Level { get; set; }
            public required HashLogger Logger { get; set; }

            public override string ToString()
            {
                var messageToBeLogged = new StringBuilder();
                messageToBeLogged.Append($"[{Level}]");
                messageToBeLogged.AppendFormat(" [{0}]", Logger._name);
                return "- LOGGER -\n" +
                        messageToBeLogged + "\n" +
                        $" {Text}\n" +
                        "- LOGGER -";
            }

            public void print()
            {
                if (Logger._output == Console.Out)
                {
                    switch (Level)
                    {
                        case LogLevel.Critical:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case LogLevel.Error:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case LogLevel.Warning:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                Logger._output.WriteLine(ToString());
                if (Logger._output == Console.Out)
                    Console.ResetColor();
                Logger._output.Flush();
            }
        }
        private readonly ConcurrentDictionary<int, Message> _logMessages;
        private readonly string _name;
        private readonly System.IO.TextWriter _output;

        public HashLogger(string name, System.IO.TextWriter output)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, Message>();
            _output = output;
        }

        ~HashLogger()
        {
            _output.Flush();
            _output.Close();
            _output.Dispose();
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var text = formatter(state, exception);
            var logMessage = new Message
            {
                Text = text,
                Level = logLevel,
                Logger = this
            };
            _logMessages[eventId.Id] = logMessage;
            logMessage.print();
        }
        void printAll()
        {
            foreach (var message in _logMessages)
            {
                message.Value.print();
            }
        }
        void printOne(int id)
        {
            _logMessages.TryGetValue(id, out var message);
            if (message != null)
                message.print();
        }
    }
}
