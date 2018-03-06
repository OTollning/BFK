using System;
using System.IO;

namespace bfk
{
    /******************************************************************************
    NAME:       bfk_listtype
    FUNCTION:   Auflisten aller Dateinamen (ohne Verzeichnisse) eines bestimmten
    Typs(fileformat)
    !! Achtung !! Aktuell ohne Unterverzeichnisse
    PARAMETERS: files           = array to store filenames
    fileformat      = parameter for file extension
    dateiendung     = local variable for file extension
    RETURNS:    
    ******************************************************************************/
    class listtype
    {
        public static void bfk_listtype(DirectoryInfo directory, string fileformat)
        {
            string dateiendung = fileformat;
            FileSystemInfo[] files = directory.GetFiles("*." + dateiendung);
            int i = 0;
            while (i < files.Length)
            {
                Console.WriteLine(files[i]);
                i++;
            }
        }
    }
}
