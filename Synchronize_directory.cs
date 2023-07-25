using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Reflection.Emit;
using System.Security.Permissions;

namespace datei_share_helper
{
    internal class Synchronize_directory
    {

        private DirectoryInfo source_folder;
        private DirectoryInfo target_folder;

        public Synchronize_directory(string source_path, string target_path) 
        { 
            source_folder = new DirectoryInfo(source_path);
            target_folder = new DirectoryInfo(target_path);
        }

        public void synchronize()
        {
            foreach (FileInfo file in source_folder.GetFiles())
            {
                if (Ist_datei_vohanden(file))
                {
                    if (Ist_sha256_gleich(file))
                    {

                    } else
                    {
                        File_copy(file);
                    }
                } else
                {
                    File_copy(file);
                }
            }
        }

        public bool Ist_datei_vohanden(FileInfo file) 
        {
            FileInfo[] target_file = target_folder.GetFiles(file.Name);
            if (target_file.Length == 0)
            {
                return false;
            } 
            return true; 
        }

        public string Get_sha256(FileInfo file,DirectoryInfo target)
        {
            FileInfo[] target_file = target.GetFiles(file.Name);
            if (target_file.Length == 0 || file.Name.Length == 0)
            {
                return null;
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                using (FileStream fileStream = target_file.First().OpenRead())
                {
                    byte[] sha256_Hashcode = sha256.ComputeHash(fileStream);

                    return Convert.ToBase64String(sha256_Hashcode);
                }
            }
        }

        public bool Ist_sha256_gleich(FileInfo file)
        {
            string source_sha256 = Get_sha256(file, source_folder);
            string target_sha256 = Get_sha256(file, target_folder);

            if (source_sha256 != target_sha256)
            {
                return false;
            }

            return true;
        }

        public void File_copy(FileInfo file)
        {
            string source_file_string = Path.Combine(source_folder.ToString(),file.Name);
            string target_file_string = Path.Combine(target_folder.ToString(),file.Name);

            File.Copy(source_file_string,target_file_string,true);
        }
    }
}
