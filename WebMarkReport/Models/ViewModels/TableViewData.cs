using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMarkReport.Models.ViewModels
{
    public class TableViewData
    {
        public string L1_name { get; set; }
        public string L2_name { get; set; }
        public List<Progress> WorkProgress { get; set; } = new List<Progress>();
        public Dictionary<int, string> Technology_cards { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> Sublayer1_items { get; set; } = new Dictionary<int, string>();
    }


    public class Progress
    {
        public int Id_sublayer1 { get; set; }
        public int Id_technology_card { get; set; }
        public int Id_status { get; set; }
        public int Lag_days_count { get; set; }
        public int Accept_quantity { get; set; }
    }

}

