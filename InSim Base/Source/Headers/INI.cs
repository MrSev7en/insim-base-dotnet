using System.IO;

namespace InSim_Base.Source.Headers
{
    public class INI
    {
        public static string Read(string Path, string Config)
        {
            if (!File.Exists(Path)) return string.Empty;

            StreamReader SR = new StreamReader(Path);

            string _1 = SR.ReadToEnd();

            SR.Dispose();
            SR.Close();

            string _2 = _1.Substring(_1.IndexOf(Config) + Config.Length + 1);

            string _3 = _2.Remove(_2.IndexOf("\r\n"));

            string _4 = _3.Replace("'", string.Empty);

            return _4;
        }
    }
}
