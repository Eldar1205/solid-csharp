using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Solid.SRP_After
{
    public class Calculator
    {
        private readonly Logger _logger;

        public Calculator(LoggerType lt, string logStream)
            : this(new Logger(lt, logStream))
        {
        }

        public Calculator(Logger logger)
        {
            _logger = logger;
        }

        public int Add(int a, int b)
        {
            _logger.Write($"Adding {a} and {b}");

            return a + b;
        }
    }

    public class Logger
    {
        private readonly LoggerType _logType;
        private readonly StreamWriter _logFile;
        private readonly string _logSource;

        public Logger(LoggerType lt, string logStream)
        {
            _logType = lt;

            if (_logType == LoggerType.TextFile)
            {
                _logFile = new StreamWriter(logStream);
            }
            else
            {
                _logSource = logStream;

                if (!EventLog.SourceExists(_logSource))
                    EventLog.CreateEventSource(_logSource, "Application");
            }
        }

        public void Write(string logMessage)
        {
            if (_logType == LoggerType.TextFile)
            {
                _logFile.WriteLine(logMessage);
            }
            else
            {
                EventLog.WriteEntry(_logSource, logMessage);
            }
        }
    }

    public enum LoggerType
    {
        TextFile,
        EventLog
    }
}
