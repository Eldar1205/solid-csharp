using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Solid.OCP_After
{
    public interface ILogger
    {
        void Write(string message);
    }

    public class Calculator
    {
        private readonly ILogger _logger;

        // Let the calculator depend on an abstraction instead of implementation,
        // that way different implementations can be created with different parameters
        // and the calculator isn't concerned with that - think SRP.
        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public int Add(int a, int b)
        {
            _logger.Write($"Adding {a} and {b}");

            return a + b;
        }
    }

    public class TextLogger : ILogger
    {
        private readonly StreamWriter _logFile;

        // We can have different ctor parameters when Calculator doesn't create the logger
        public TextLogger(string filename)
        {
            _logFile = new StreamWriter(filename);
        }

        public void Write(string message)
        {
            _logFile.WriteLine(message);
        }
    }

    public class EventLogger : ILogger
    {
        private readonly string _logSource;

        // We can have different ctor parameters when Calculator doesn't create the logger
        public EventLogger(string logSource, string logName)
        {
            _logSource = logSource;

            if (!EventLog.SourceExists(_logSource))
                EventLog.CreateEventSource(_logSource, logName);
        }

        public void Write(string message)
        {
            EventLog.WriteEntry(_logSource, message);
        }
    }
}
