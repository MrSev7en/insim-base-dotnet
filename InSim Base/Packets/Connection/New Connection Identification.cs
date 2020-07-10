using InSim_Base.Source.Handshake;
using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;
using System;

namespace InSim_Base.Packets.Connection
{
    public class New_Connection_Identification
    {
        public static void NCI(InSim insim, IS_NCI NCI)
        {
            try
            {
                foreach (Connections Conn in Connections._connections.Values)
                {
                    if (Conn.UCID == NCI.UCID)
                    {
                        if (!string.IsNullOrWhiteSpace(Convert.ToString(NCI.IPAddress)))
                        {
                            Conn.IP = Convert.ToString(NCI.IPAddress);
                        }
                        else
                        {
                            Conn.IP = "127.0.0.1";
                        }
                    }
                }
            }
            catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.NCI); }
        }
    }
}
