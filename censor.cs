using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace bfk
{
    class censor
    {
        /******************************************************************************
        NAME:       bfk_censorship
        FUNCTION:   Ersetzt in der angegebenen Datei jedes Suchwort (ohne Unterscheidung
                    von Groß- und Kleinbuchstaben) durch den angegebenen Ersatztext.
        PARAMETERS: prefix      = Prefix of all new files
                    Verzeichnis = Current directory
        RETURNS:    
        ******************************************************************************/
        public static void bfk_cencorship(FileInfo file, String Search_string, String replace_string)
        {
            string path = file.Directory.ToString() + "\\" + file.Name;
            string inhalt = get_text(file);
            StreamWriter sw = new StreamWriter(path);
            string newInhalt = safe_replace(inhalt, Search_string, replace_string);
            sw.Write(newInhalt);
            sw.Flush();

        }

        private static string safe_replace(string inhalt, string searchstring, string replacestring)
        {
            string pattern = string.Format(@"\b{0}\b", searchstring);
            string newTxt = Regex.Replace(inhalt, pattern, replacestring, RegexOptions.IgnoreCase);
            return newTxt;
        }


        private static string get_text(FileInfo file)
        {
            StreamReader sr = new StreamReader(file.FullName);
            string text = sr.ReadToEnd();
            sr.Close();
            return text;
        }
    }
}
