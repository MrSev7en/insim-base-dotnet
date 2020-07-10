using InSim_Base.Handler.Commands;
using InSim_Base.Source.Handshake;
using System;

namespace InSim_Base.Handler
{
    public class CommandHandler
    {
        public struct Command
        {
            public static void Get(string Command, string[] Args, Connections Conn)
            {
                switch (Command)
                {
                    case "ping":
                        {
                            new Ping(Args, Conn);
                        }
                        break;

                    case "ajuda":
                        {
                            new Ajuda(Args, Conn);
                        }
                        break;

                    default:
                        {
                            throw new Exception();
                        }
                }
            }
        }
    }
}