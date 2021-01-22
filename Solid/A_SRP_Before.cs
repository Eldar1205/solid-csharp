using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Solid.SRP_Before
{
    public class Calculator
    {
        private readonly LoggerType _logType;
        private readonly StreamWriter _logFile;
        private readonly string _logSource;

        public Calculator(LoggerType lt, string logStream)
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

        public int Add(int a, int b)
        {
            string logMessage = $"Adding {a} and {b}";

            if (_logType == LoggerType.TextFile)
            {
                _logFile.WriteLine(logMessage);
            }
            else
            {
                EventLog.WriteEntry(_logSource, logMessage);
            }

            return a + b;
        }
    }

    public enum LoggerType
    {
        TextFile,
        EventLog
    }
}
