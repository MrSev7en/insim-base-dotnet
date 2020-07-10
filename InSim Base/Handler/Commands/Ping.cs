using InSim_Base.Source.Getaway;
using InSim_Base.Source.Handshake;
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace InSim_Base.Handler.Commands
{
    public class Ping
    {
        public Ping(string[] Args, Connections Conn)
        {
            System.Net.NetworkInformation.Ping _Ping = new System.Net.NetworkInformation.Ping();
            PingReply Reply = _Ping.Send((new WebClient().DownloadString(new Uri("https://api.ipify.org/"))));

            if (Reply.Status == IPStatus.Success)
            {
                Interface.Message.Send($"^6» ^7O ping atual desse servidor é ^6{Reply.RoundtripTime.ToString()}ms", Conn.UCID);
            }
            else
            {
                Interface.Message.Send($"^1» ^7O ping atual desse servidor está muito alto ou não foi possível identificar.", Conn.UCID);
            }
        }
    }
}
