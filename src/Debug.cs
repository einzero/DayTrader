using System;
using System.Drawing;

namespace DayTrader
{
    public static class Debug
    {
        public enum LogLevel
        {
            Info,
            Warning,
            Error,
        }

        public static event Action<DateTime, LogLevel, string> Logged;

        public static void Error(string format, params object[] args)
        {
            Log(LogLevel.Error, format, args);
        }

        public static void Warn(string format, params object[] args)
        {
            Log(LogLevel.Warning, format, args);
        }

        public static void Info(string format, params object[] args)
        {
            Log(LogLevel.Info, format, args);
        }

        public static void Info(string[] list)
        {
            foreach (var text in list)
            {
                Info(text);
            }
        }

        private static void Log(LogLevel level, string format, params object[] args)
        {
            if (string.IsNullOrEmpty(format))
            {
                return;
            }

            if (Logged != null)
            {
                Logged(DateTime.Now, level, string.Format(format, args));
            }
        }

        private static Color GetColorByLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Warning:
                    return Color.DarkOrange;
                case LogLevel.Error:
                    return Color.DarkRed;
            }

            return Color.Black;
        }
    }
}
