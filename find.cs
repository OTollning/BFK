using System;
using System.IO;


namespace bfk
{
    class find
    {
        /******************************************************************************
        NAME:       bfk_find
        FUNCTION:   Auflisten aller Dateinamen der Dateien, die die mit dem zweiten 
                    Parameter angegebene  Dateiendung haben und den angegebenen 
                    Suchtext enthalten.
        PARAMETERS: prefix      = Prefix of all new files
                    Verzeichnis = Current directory
        RETURNS:    
        ******************************************************************************/
        public static void bfk_find(DirectoryInfo Verzeichnis, String fileformat, String searchstring)
        {
            FileInfo[] all_files = Verzeichnis.GetFiles();
            foreach (FileInfo file in all_files)
            {
                if ((string.Compare(file.Extension, "." + fileformat) == 0))
                {
                    search_file(file, searchstring);
                    // safe_search_file(file, searchstring);
                }
            }
            Console.WriteLine("Suche abgeschlossen");
        }
        private static void safe_search_file(FileInfo file, String searchtext)
        {
            string pattern = string.Format(@"{0}", searchtext);
            string text = file.OpenText().ReadToEnd();
            if (text.Contains(pattern))
            {
                Console.WriteLine(file.Name);
            }
        }
        private static void search_file(FileInfo file, String searchtext)
        {
            string text = file.OpenText().ReadToEnd();
            if (text.Contains(searchtext))
            {
                Console.WriteLine(file.Name);
            }
        }
    }
}
