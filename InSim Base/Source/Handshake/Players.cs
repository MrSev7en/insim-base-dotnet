using System.Collections.Generic;

namespace InSim_Base.Source.Handshake
{
    public class Players
    {
        public static Dictionary<byte, Players> _players = new Dictionary<byte, Players>();

        public byte UCID = new byte();
        public byte PLID = new byte();

        public string PName = string.Empty;
        public string CName = string.Empty;
    }
}
