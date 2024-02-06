using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace datei_share_helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Synchronize_directory datei_synchronize = new Synchronize_directory(@"\\192.168.178.28\share_folder",desktop_path + @"\ziel_folder");

            datei_synchronize.synchronize();
        }
    }
}