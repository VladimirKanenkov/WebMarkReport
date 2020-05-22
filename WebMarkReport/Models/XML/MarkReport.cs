using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMarkReport.Models
{
    [Serializable]
    public class MarkReport
    {
        //[DefaultValue("newid()")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int id { get; set; }
        public int id_l1 { get; set; }
        public int id_l2 { get; set; }
        public int id_sublayer1 { get; set; }
        public int id_technology_card { get; set; }
        public string technology_card_name { get; set; }
        public int id_subcontractor { get; set; }
        public string subcontractor_name { get; set; }
        public int id_status { get; set; }
        public int lag_days_count { get; set; }
        public int accept_quantity { get; set; }
        public int dev_count { get; set; }
        public int id_employee { get; set; }
        public int call_count { get; set; }
        public bool is_have_ct3 { get; set; }
        public bool is_only_ct3 { get; set; }
        public DateTime date { get; set; }
        public DateTime? datev2 { get; set; }
        public MarkReport()
        {

        }
    }
}
