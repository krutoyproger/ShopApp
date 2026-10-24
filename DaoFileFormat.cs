using System;

namespace task2
{
    public static class DaoFileFormat
    {
        public static string Join(params object[] args) => string.Join("|", args);

        public static string[] Split(string line, int count)
        {
            var parts = line.Split('|');
            if (parts.Length != count)
                throw new FormatException($"Ожидалось {count} частей, получено {parts.Length}");
            return parts;
        }

        public static int ParseId(string part, string line) => int.Parse(part);

        public static DateTime ParseDate(string part, string line) => DateTime.Parse(part);

        public static string FormatDate(DateTime date) => date.ToString("yyyy-MM-dd");
    }
}