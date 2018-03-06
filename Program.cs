using System;
using System.IO;

namespace bfk
{
    class Program
    {
        /*
         TODO:
         *      REFACTORING
         *      PARAMETER TESTEN
         *      RESTLICHE FUNKTIONEN
         *      FEHLER BEHANDLUNG
         *      EINGABE .toLower() [Eingabeformat ignorieren]
         
         */
        static String pfad = System.Environment.CurrentDirectory;
        static DirectoryInfo directory;

        static void Main(string[] args)
        {


            directory = init_directory(System.Environment.CurrentDirectory);


            int arg_count = args.Length;

            if (arg_count > 0)
            {
                switch (args[0])
                {
                    case "list":
                        list.bfk_list(directory);
                        break;
                    case "listtype":

                        if (check_paramcount(2, arg_count))
                        {
                            listtype.bfk_listtype(directory, args[1]);
                        }
                        else if (check_paramcount(1, arg_count))
                        {
                            listtype.bfk_listtype(directory, "*");
                        }

                        break;
                    case "listname":

                        if (check_paramcount(2, arg_count))
                        {
                            listname.bfk_listname(directory, args[1]);
                        }
                        else
                        {
                            listname.bfk_listname(directory, "");
                        }
                        break;
                    case "backup":
                        if (check_paramcount(2, arg_count))
                        {
                            backup.bfk_backup(pfad, args[1]);
                        }
                        else
                        {
                            paramcount_error();
                        }
                        break;
                    case "xml":
                        if (check_paramcount(2, arg_count))
                        {
                            xml.bfk_xml(args[1], directory);
                        }
                        else
                        {
                            paramcount_error();
                        }
                        break;
                    case "join":

                        if (check_paramcount(4, arg_count))
                        {
                            join.bfk_join(pfad, args[1], args[2], args[3]);
                        }
                        else
                        {
                            paramcount_error();
                        }
                        break;
                    case "attrib":
                        if (check_paramcount(2, arg_count))
                        {
                            attribute.bfk_attribute(pfad, args[1]);
                        }
                        else
                        {
                            //attribut.show_all_Attrib(directory);
                        }
                        break;
                    case "rename":

                        if (check_paramcount(2, arg_count))
                        {
                            rename.bfk_rename(directory, args[1]);
                        }
                        else
                        {
                            paramcount_error();
                        }
                        break;
                    case "find":
                        if (check_paramcount(3, arg_count))
                        {
                            find.bfk_find(directory, args[1], args[2]);
                        }
                        else
                        {
                            paramcount_error();
                        }
                        break;
                    case "censorship":
                        try
                        {
                            if (check_paramcount(4, arg_count))
                            {
                                FileInfo[] files = directory.GetFiles();
                                FileInfo f1 = null;
                                foreach (FileInfo file in files)
                                {
                                    if (file.Name == args[1])
                                    { f1 = file; }

                                }
                                censor.bfk_cencorship(f1, args[2], args[3]);
                            }
                            else
                            {
                                paramcount_error();
                            }
                        }
                        catch (System.NullReferenceException)
                        {
                            Console.WriteLine("Datei nicht gefunden");
                        }

                        break;

                    default:
                        Console.WriteLine("ERROR: Unbekannter Parameter");
                        Console.ReadLine();
                        break;

                }
            }
            else
            {
                Console.WriteLine("ERROR: Kein Parameter");
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Überprüft die Anzahl der Parameter
        /// </summary>
        private static bool check_paramcount(int paramC, int argLen)
        {
            if (paramC == argLen)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private static void paramcount_error()
        {
            Console.WriteLine("ERROR: Parameter Anzahl falsch!");


        }

        /****************************************************************/
        /*
         *  Gibt die FileInfodatei aus dem übergebenen String Namen zurück, oder null wenn nicht vorhanden.
         */
        private FileInfo get_file(string Dateiname)
        {
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Name == Dateiname)
                {
                    return file;
                }
            }
            return null; //Datei nicht gefunden-> Fehler 
        }



        /*
         * Initialisiert das aktuelle Verzeichnis
         */
        private static DirectoryInfo init_directory(String path)
        {
            return new DirectoryInfo(path);
        }

    }
}
