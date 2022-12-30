using System;

namespace InSim_Base.Source.Output
{
    public class Logger
    {
        public enum Types
        {
            Initialize,
            ISM,
            NCN,
            NCI,
            CNL,
            MCI,
            MTC,
            BTN,
            BFN,
            NPL,
            PLP,
            PLL
        }

        public static void Error(string Message, Types Type)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"[Exception] {Type} --> {Message}");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }

        public static void Info(string Message, Types Type)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"[Info] {Type} --> {Message}");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }
    }
}
