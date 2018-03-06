using System;
using System.IO;

namespace bfk
{
    /******************************************************************************
    NAME:       bfk_list
    FUNCTION:   Auflisten aller Dateinamen und Verzeichnisnamen im aktuellen 
                Verzeichnis.
    PARAMETERS: files           = array to store filenames
    RETURNS:    
    ******************************************************************************/
    class list
    {
        public static void bfk_list(DirectoryInfo directory)
        {
            FileSystemInfo[] files = directory.GetFileSystemInfos();
            int i = 0;
            while (i < files.Length)
            {
                if (files[i] is DirectoryInfo)
                {
                    Console.WriteLine("<dir>" + files[i]);
                }
                else
                {
                    Console.WriteLine(files[i]);
                }
                i++;
            }
        }
    }
}
