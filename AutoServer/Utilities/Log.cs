using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoServer.Utilities
{
    public class Log
    {
        public static void Info(string message)
        {
            Console.WriteLine("[INFO] " + message);
        }

        public static void Warning(string message)
        {
            Console.WriteLine("[WARNING] " + message);
        }

        public static void Error(string message)
        {
            Console.WriteLine("[ERROR] " + message);
        }
    }
}
