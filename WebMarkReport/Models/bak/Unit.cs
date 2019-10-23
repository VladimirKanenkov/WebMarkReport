using System.Collections.Generic;

namespace WebMarkReport.Models
{
    /// <summary>
    /// Строящийся объект
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// id jкорпуса
        /// </summary>
        public int Id_l1 { get; set; }
        /// <summary>
        /// Название корпуса
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список секций
        /// </summary>
        public List<Section> sections = new List<Section>();
    }
}