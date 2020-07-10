using InSim_Base.Source.Handshake;
using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;

namespace InSim_Base.Packets.Car
{
    public class Leave_Pit
    {
        public static void NPL(InSim insim, IS_NPL NPL)
        {
            try
            {
                if (Players._players.ContainsKey(NPL.PLID))
                {
                    Players._players[NPL.PLID].UCID = NPL.UCID;
                    Players._players[NPL.PLID].PLID = NPL.PLID;
                    Players._players[NPL.PLID].PName = NPL.PName;
                    Players._players[NPL.PLID].CName = NPL.CName;
                }
                else
                {
                    Players._players.Add(NPL.PLID, new Players
                    {
                        UCID = NPL.UCID,
                        PLID = NPL.PLID,
                        PName = NPL.PName,
                        CName = NPL.CName
                    });
                }

                foreach (Connections Conn in Connections._connections.Values)
                {
                    if (Conn.UCID == NPL.UCID)
                    {
                        Conn.PLID = NPL.PLID;
                    }
                }
            }
            catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.NPL); }
        }
    }
}
