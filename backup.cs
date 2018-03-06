using System;
using System.IO;

namespace bfk
{
    /******************************************************************************
    NAME:       bfk_backup
    FUNCTION:   Erstellen eines Backups aller Dateien und Verzeichnisse.
    PARAMETERS: backup          = target directory of backup
                backupName      = Name of the backup folder
    RETURNS:    
    ******************************************************************************/
    class backup
    {
        public static void bfk_backup(string pfad, string backupName)
        {
            string backup = @pfad + '\\' + backupName;

            if (!Directory.Exists(backup))
            {
                //Erstelle alle Ordner
                foreach (string alt in Directory.GetDirectories(pfad, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(alt.Replace(pfad, backup));
                //Kopiere alle Dateien und ersetze diese falls nötig
                foreach (string neu in Directory.GetFiles(pfad, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(neu, neu.Replace(pfad, backup), true);
                //Backupordner erstellen
                Directory.CreateDirectory(backup);
            }
            else { Console.WriteLine("Ordner existiert bereits."); }
        }
    }
}
