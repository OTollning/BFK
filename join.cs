using System;
using System.IO;
using System.Text;

namespace bfk
{
    /******************************************************************************
    NAME:       bfk_join
    FUNCTION:   Zusammenfügen der Inhalte zweier Textdateien (Datei1 und Datei2) 
                zu einer neuen Textdatei Datei3 
    PARAMETERS: pfad    = Current Directory
                datei1  = First File
                datei2  = Second File
                datei3  = Joined File
    RETURNS:    
******************************************************************************/
    class join
    {
        public static void bfk_join(string pfad, string datei1, string datei2, string datei3)
        {
            try
            {
                File.Copy(datei1, datei3, true);
                File.SetAttributes(datei3, FileAttributes.Normal);
                string kopie = File.ReadAllText(pfad + "\\" + datei2, Encoding.UTF8);
                File.AppendAllText(pfad + "\\" + datei3, kopie, Encoding.UTF8);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Mindestens eine Ihrer angegebenen Dateien existiert nicht");
            }
        }
    }
}
