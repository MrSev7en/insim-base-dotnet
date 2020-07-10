using InSimDotNet;
using InSimDotNet.Packets;
using InSim_Base.Handler;
using InSim_Base.Source.Handshake;
using System;
using System.Linq;

namespace InSim_Base.Packets.Message
{
    public class Message_Output
    {
        public static void MSO(InSim insim, IS_MSO MSO)
        {
            foreach (Connections Conn in Connections._connections.Values)
            {
                if (Conn.UCID == MSO.UCID)
                {
                    if (MSO.UserType == UserType.MSO_PREFIX)
                    {
                        string Command = (((MSO.Msg.Substring(MSO.TextStart, (MSO.Msg.Length - MSO.TextStart))).Split(' ').Take(1).First()).Substring(1));
                        string[] Args = ((MSO.Msg.Substring(MSO.TextStart, (MSO.Msg.Length - MSO.TextStart))).Split(' ').Skip(1).ToArray());

                        try
                        {
                            CommandHandler.Command.Get(Command, Args, Conn);
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
