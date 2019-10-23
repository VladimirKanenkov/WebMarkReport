using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace WebMarkReport.Models
{
    [Serializable]
    public class l3structure
    {
        [XmlElement("Structure")]
        public Structure[] structures { get; set; }
        public l3structure()
        {
        }
    }

    [Serializable]
    public class Structure
    {
        public int id { get; set; }
        public int id_l1 { get; set; }
        public int id_l2 { get; set; }
        public int id_sublayer1 { get; set; }
        public string l1_name { get; set; }
        public string l2_name { get; set; }
        public string sublayer1_name { get; set; }
        public Structure()
        {
        }
    }

}