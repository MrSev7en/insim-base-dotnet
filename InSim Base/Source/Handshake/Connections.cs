using InSimDotNet.Helpers;
using System.Collections.Generic;

namespace InSim_Base.Source.Handshake
{
    public class Connections
    {
        public static Dictionary<byte, Connections> _connections = new Dictionary<byte, Connections>();

        /*
         * [General Purpose]
        */
        public byte UCID = new byte();
        public byte PLID = new byte();

        /*
         * [Global Variables]
        */
        public string UName = string.Empty;
        public string PName = string.Empty;

        public bool Administrator = new bool();
        public string IP = string.Empty;

        /*
         * [Car Information]
        */
        public long X = new long();
        public long Y = new long();
        public long Z = new long();

        public long Heading = new long();
        public long Angle = new long();

        public long Speed = new long();

        public long Speed_KMH()
        {
            return (long)MathHelper.SpeedToKph(Speed);
        }

        public long Speed_MPH()
        {
            return (long)MathHelper.SpeedToMph(Speed);
        }
    }
}
