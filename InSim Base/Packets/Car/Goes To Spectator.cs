using InSim_Base.Source.Handshake;
using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;

namespace InSim_Base.Packets.Car
{
    public class Goes_To_Spectator
    {
        public static void PLL(InSim insim, IS_PLL PLL)
        {
            try
            {
                Players._players.Remove(PLL.PLID);

                foreach (Connections Conn in Connections._connections.Values)
                {
                    if (Conn.PLID == PLL.PLID)
                    {

                    }
                }
            }
            catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.PLL); }
        }
    }
}
