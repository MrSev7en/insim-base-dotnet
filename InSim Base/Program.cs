using InSim_Base.Packets.Car;
using InSim_Base.Packets.Connection;
using InSim_Base.Packets.Initialize;
using InSim_Base.Packets.Message;
using InSim_Base.Source.Headers;
using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;

namespace InSim_Base
{
    public class Program
    {
        public static InSim insim = new InSim();

        public static void Main(string[] args)
        {
            string IP = INI.Read("config.ini", "IP");
            ushort Port = ushort.Parse(INI.Read("config.ini", "Port"));
            string Admin_Password = INI.Read("config.ini", "Admin_Password");

            while (true)
            {
                if (!insim.IsConnected)
                {
                    insim.Bind<IS_ISM>(InSim_Multi.ISM);
                    insim.Bind<IS_NCN>(New_Connection.NCN);
                    insim.Bind<IS_NCI>(New_Connection_Identification.NCI);
                    insim.Bind<IS_CNL>(Connection_Leave.CNL);
                    insim.Bind<IS_NPL>(Leave_Pit.NPL);
                    insim.Bind<IS_PLP>(Goes_To_Pit.PLP);
                    insim.Bind<IS_PLL>(Goes_To_Spectator.PLL);
                    insim.Bind<IS_MCI>(Message_Car_Information.MCI);
                    insim.Bind<IS_MSO>(Message_Output.MSO);

                    insim.Initialize(new InSimSettings
                    {
                        Host = IP,
                        Port = Port,
                        Admin = Admin_Password,
                        Flags = InSimFlags.ISF_MSO_COLS | InSimFlags.ISF_MCI,
                        Interval = 1000,
                        Prefix = '!',
                        IName = "^0L^7I^0B"
                    });

                    insim.Send(new IS_TINY { ReqI = 2, SubT = TinyType.TINY_ISM });

                    Logger.Info($"InSim Base - InSim\nInitialized with success, in {IP}:{Port}", Logger.Types.Initialize);
                }
            }
        }
    }
}
