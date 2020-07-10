using InSim_Base.Source.Handshake;
using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;

namespace InSim_Base.Packets.Connection
{
    public class Connection_Leave
    {
        public static void CNL(InSim insim, IS_CNL CNL)
        {
            try
            {
                Connections._connections.Remove(CNL.UCID);
            }
            catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.CNL); }
        }
    }
}
