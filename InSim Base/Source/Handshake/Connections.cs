using InSimDotNet.Helpers;
using System;
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

        public long KMH()
        {
            return (long)MathHelper.SpeedToKph(Speed);
        }

        public long MPH()
        {
            return (long)MathHelper.SpeedToMph(Speed);
        }

        public bool Closer(int x, int y, int z, int offset = 50)
        {
            return Math.Abs((X * 65536) - (x * 65536)) <= offset && Math.Abs((Y * 65536) - (y * 65536)) <= offset && Math.Abs((Z * 65536) - (z * 65536)) <= offset;
        }

        public bool Closer(Connections Conn, int offset = 50)
        {
            return Math.Abs((X * 65536) - (Conn.X * 65536)) <= offset && Math.Abs((Y * 65536) - (Conn.Y * 65536)) <= offset && Math.Abs((Z * 65536) - (Conn.Z * 65536)) <= offset;
        }

        public Connections[] Next(int offset = 50)
        {
            var next = new List<Connections>();

            foreach (var Conn in _connections.Values)
                if (Closer(Conn, offset))
                    next.Add(Conn);

            return next.ToArray();
        }
    }
}
