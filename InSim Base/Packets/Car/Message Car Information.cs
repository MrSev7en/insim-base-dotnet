using InSim_Base.Source.Handshake;
using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;

namespace InSim_Base.Packets.Car
{
    public class Message_Car_Information
    {
        public static void MCI(InSim insim, IS_MCI MCI)
        {
            try
            {
                foreach (CompCar car in MCI.Info)
                {
                    if (Players._players.TryGetValue(car.PLID, out Players NPL))
                    {
                        foreach (Connections Conn in Connections._connections.Values)
                        {
                            if (Conn.PLID == car.PLID)
                            {
                                Conn.X = (car.X / 65536);
                                Conn.Y = (car.Y / 65536);
                                Conn.Z = (car.Z / 65536);

                                Conn.Heading = ((car.Heading / 256) + 128);
                                Conn.Angle = (car.AngVel / 16384);

                                Conn.Speed = car.Speed;
                            }
                        }
                    }
                }
            }
            catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.MCI); }
        }
    }
}
