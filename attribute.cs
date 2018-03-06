using System;
using System.IO;

namespace bfk
{
    /******************************************************************************
    NAME:       bfk_attrib
    FUNCTION:   Gibt die Dateiattribute (Schreibgeschützt R, Versteckt H und 
                Systemdatei S) der angegebenen Datei aus.
    PARAMETERS: datei       = the file that is checked
                rhs         = append file attribute as needed
    RETURNS:    
    ******************************************************************************/
    class attribute
    {
        public static void bfk_attribute(string pfad, string datei)
        {
            try
            {
                FileAttributes files = File.GetAttributes(pfad + "\\" + datei);
                string rhs = "";

                if ((files & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    rhs += "R";

                if ((files & FileAttributes.Hidden) == FileAttributes.Hidden)
                    rhs += "H";

                if ((files & FileAttributes.System) == FileAttributes.System)
                    rhs += "S";

                Console.WriteLine(pfad + "\\" + datei + " " + rhs);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Die angegebene Datei existiert nicht.");
            }
        }
    }
}
