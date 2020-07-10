using InSim_Base.Source.Getaway;
using InSim_Base.Source.Handshake;

namespace InSim_Base.Handler.Commands
{
    public class Ajuda
    {
        public Ajuda(string[] Args, Connections Conn)
        {
            Interface.Message.Send("^6Precisa de ajuda? ^7lfsteam.net", Conn.UCID);
        }
    }
}
