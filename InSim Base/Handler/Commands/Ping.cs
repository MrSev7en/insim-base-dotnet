using InSim_Base.Source.Gateway;
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
            Interface.Message.Send("^6» ^7Medindo sua taxa de latência, e a taxa de latência do servidor. Aguarde...", Conn.UCID);

            System.Net.NetworkInformation.Ping _Ping = new System.Net.NetworkInformation.Ping();
            PingReply Reply = _Ping.Send((new WebClient().DownloadString(new Uri("https://api.ipify.org/"))));
            PingReply ReplyMe = null;

            if (!string.IsNullOrWhiteSpace(Conn.IP))
            {
                ReplyMe = _Ping.Send(Conn.IP);
            }
            else
            {
                ReplyMe = _Ping.Send("127.0.0.1");
            }

            if (Reply.Status == IPStatus.Success && ReplyMe.Status == IPStatus.Success)
            {
                Interface.Message.Send($"^6» ^7O ping atual desse servidor é ^6{Reply.RoundtripTime.ToString()}ms", Conn.UCID);
                Interface.Message.Send($"^6» ^7O seu ping atual nesse servidor é ^6{ReplyMe.RoundtripTime.ToString()}ms", Conn.UCID);
            }
            else
            {
                Interface.Message.Send($"^1» ^7O seu ping ou o ping do servidor está muito alto, então não foi possível identificar.", Conn.UCID);
            }
        }
    }
}
