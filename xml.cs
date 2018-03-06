using System;
using System.IO;
using System.Xml;

namespace bfk
{
    class xml
    {
        /******************************************************************************
       NAME:        bfk_xml
       FUNCTION:    Speichern aller Dateinamen und Verzeichnisnamen im aktuellen 
                    Verzeichnis als xml-Datei 
       PARAMETERS:  Dateiname   = Name of XML file
                    Verzeichnis = Current directory
       RETURNS:    
       ******************************************************************************/

        public static void bfk_xml(string Dateiname, DirectoryInfo Verzeichnis)
        {
            string name = Dateiname + ".xml";
            XmlTextWriter writer = new XmlTextWriter(name, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;

            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", Verzeichnis.Name);

            FileInfo[] files = Verzeichnis.GetFiles();
            foreach (FileInfo file in files)
            { printElement(writer, file); }
            DirectoryInfo[] dirs = Verzeichnis.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            { printDir(writer, dir); }

            writer.WriteEndElement();

            writer.Close();
            Console.WriteLine("XML-Datei abgeschlossen");
        }
        private static void printDir(XmlTextWriter writer, DirectoryInfo dir)
        {
            writer.WriteStartElement("entry");
            writer.WriteStartElement("typ");
            writer.WriteString("dir");
            writer.WriteEndElement();
            writer.WriteStartElement("name");
            writer.WriteString(dir.Name);
            writer.WriteEndElement();
            writer.WriteStartElement("size");
            writer.WriteString("-");
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        private static void printElement(XmlTextWriter writer, FileInfo file)
        {
            writer.WriteStartElement("entry");
            writer.WriteStartElement("typ");
            writer.WriteString("file");
            writer.WriteEndElement();
            writer.WriteStartElement("name");
            writer.WriteString(file.Name);
            writer.WriteEndElement();
            writer.WriteStartElement("size");
            writer.WriteString(file.Length.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
