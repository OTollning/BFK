using System;
using System.IO;

namespace bfk
{
    /******************************************************************************
    NAME:       bfk_listname
    FUNCTION:   Auflisten aller Dateinamen (ohne Verzeichnisse), deren Namen mit
                dem Anzugebenen Text beginnen.
    PARAMETERS: files           = array to store filenames
                TeilName        = part of the string that is to be searched
    RETURNS:    
    ******************************************************************************/
    class listname
    {
        public static void bfk_listname(DirectoryInfo directory, string TeilName)
        {
            string searchstring = TeilName + "*";
            FileSystemInfo[] files = directory.GetFiles(searchstring);
            int i = 0;
            while (i < files.Length)
            {
                Console.WriteLine(files[i]);

                i++;
            }
        }
    }
}
