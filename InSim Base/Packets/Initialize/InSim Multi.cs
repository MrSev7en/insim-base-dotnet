using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;

namespace InSim_Base.Packets.Initialize
{
    public class InSim_Multi
    {
        public static void ISM(InSim insim, IS_ISM ISM)
        {
            try
            {
                insim.Send(new IS_TINY { ReqI = 2, SubT = TinyType.TINY_NCN });
                insim.Send(new IS_TINY { ReqI = 2, SubT = TinyType.TINY_NCI });
                insim.Send(new IS_TINY { ReqI = 2, SubT = TinyType.TINY_NPL });
                insim.Send(new IS_TINY { ReqI = 2, SubT = TinyType.TINY_SST });
                insim.Send(new IS_TINY { ReqI = 2, SubT = TinyType.TINY_AXI });
            }
            catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.ISM); }
        }
    }
}
