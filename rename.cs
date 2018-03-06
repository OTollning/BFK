using System;
using System.IO;

namespace bfk
{
    class rename
    {
        /******************************************************************************
        NAME:       bfk_rename
        FUNCTION:   Umbenennen aller Dateien (ohne Verzeichnisse) 
                    im aktuellen Verzeichnis 
        PARAMETERS: prefix      = Prefix of all new files
                    Verzeichnis = Current directory
        RETURNS:    
        ******************************************************************************/
        public static void bfk_rename(DirectoryInfo Verzeichnis, string prefix)
        {
            FileInfo[] allFiles = Verzeichnis.GetFiles();
            foreach (FileInfo file in allFiles)
            {
                rename_file(file, prefix);
            }
            Console.WriteLine("Umbennen abgeschlossen");
        }

        private static void rename_file(FileInfo file, String prefix)
        {
            System.IO.File.Move(file.FullName, file.DirectoryName + "\\" + prefix + file.Name);
        }
    }
}
