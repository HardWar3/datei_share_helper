using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace datei_share_helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Synchronize_directory kekse = new Synchronize_directory("\\\\192.168.178.28\\hardy\\share_folder",desktop_path + "\\ziel_folder");

            kekse.synchronize();
        }
    }
}
