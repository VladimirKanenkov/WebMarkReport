using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMarkReport.Model
{
    /// <summary>
    /// Строительная площадка
    /// </summary>
    public class Building
    {
        public List<Unit> units = new List<Unit>();
        public Unit BuildCorpus { get; set; }


        /// <summary>
        /// id секции в корпусе
        /// </summary>
        public int Id_l2 { get; set; }
        /// <summary>
        ///  id этажа в секции
        /// </summary>
        public int Id_sublayer1 { get; set; }
    }
}
