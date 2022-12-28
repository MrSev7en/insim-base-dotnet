using InSim_Base.Source.Gateway;
using InSim_Base.Source.Handshake;

namespace InSim_Base.Handler.Commands
{
    public class Ajuda
    {
        public Ajuda(string[] Args, Connections Conn)
        {
            Interface.Message.Send("^6» ^7Precisa de ajuda? ^6lfsteam.net", Conn.UCID);
        }
    }
}
