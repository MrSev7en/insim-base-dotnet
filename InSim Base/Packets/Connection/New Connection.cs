using InSim_Base.Source.Gateway;
using InSim_Base.Source.Handshake;
using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;

namespace InSim_Base.Packets.Connection
{
    public class New_Connection
    {
        public static void NCN(InSim insim, IS_NCN NCN)
        {
            try
            {
                Connections._connections.Add(NCN.UCID, new Connections
                {
                    UCID = NCN.UCID,
                    UName = NCN.UName,
                    PName = NCN.PName,
                    Administrator = NCN.Admin
                });

                foreach (Connections Conn in Connections._connections.Values)
                {
                    if (Conn.UCID == NCN.UCID)
                    {
                        Interface.Message.Send($"^7Olá, ^6{Conn.UName}", Conn.UCID);
                    }
                }
            }
            catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.NCN); }
        }
    }
}
