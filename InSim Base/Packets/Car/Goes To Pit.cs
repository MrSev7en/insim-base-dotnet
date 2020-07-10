using InSim_Base.Source.Handshake;
using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;

namespace InSim_Base.Packets.Car
{
    public class Goes_To_Pit
    {
        public static void PLP(InSim insim, IS_PLP PLP)
        {
            try
            {
                Players._players.Remove(PLP.PLID);

                foreach (Connections Conn in Connections._connections.Values)
                {
                    if (Conn.PLID == PLP.PLID)
                    {

                    }
                }
            }
            catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.PLP); }
        }
    }
}
