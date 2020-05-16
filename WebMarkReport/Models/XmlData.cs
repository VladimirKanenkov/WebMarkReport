using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebMarkReport.Models;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace WebMarkReport.Models
{
    public class XmlData
    {
        public static List<MarkReport> reports { get; set; } = new List<MarkReport>();
        public static List<Structure> structures { get; set; } = new List<Structure>();

        public static void Deserialize()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment; //чтение "неправильного" xml с двумя корнями по фрагментам

            XmlDocument xDoc = new XmlDocument();
            XmlDocumentFragment xDocFrag = xDoc.CreateDocumentFragment();

            string filename = new DirectoryInfo(@"..\..").FullName + @"\data.xml";

            StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open));
            XmlSerializer formatter = new XmlSerializer(typeof(MarkReport[]));

            using (XmlReader reader = XmlReader.Create(sr, settings))
            {
                MarkReport[] reportArr = (MarkReport[])formatter.Deserialize(reader);
                reports = reportArr.ToList();

                formatter = new XmlSerializer(typeof(l3structure));
                l3structure l3structure = (l3structure)formatter.Deserialize(reader);
                int j = 0;
                foreach(var item in l3structure.structures)
                {
                    j++;
                    item.Id = j;

                }
                structures = l3structure.structures.ToList();
            }

        }

    }
}
