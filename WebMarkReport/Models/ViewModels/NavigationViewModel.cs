using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebMarkReport.Models.ViewModels
{
    public class NavigationViewModel
    {
        private List<Building> buildings { get; set; } = new List<Building>();

        public NavigationViewModel(DbSet<Structure> structures)
        {
            foreach (var str in structures)
            {
                buildings.Add(new Building
                {
                    Id_l1 = str.id_l1,
                    Id_l2 = str.id_l2,
                    L1_name = str.l1_name,
                    L2_name = str.l2_name
                });
            }
        }       
        public virtual IEnumerable<Building> NoduplicatesBuildings => buildings.Distinct().OrderBy(n => n.L1_name);
    }

    public class Building : IEquatable<Building>
    {
        public int Id_l1 { get; set; }
        public int Id_l2 { get; set; }

        public string L1_name { get; set; }
        public string L2_name { get; set; }

        public bool Equals(Building other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return Id_l1.Equals(other.Id_l1) && Id_l2.Equals(other.Id_l2);
        }

        public override int GetHashCode()
        {
            int hashId_l1 = Id_l1.GetHashCode();
            int hashId_l2 = Id_l2.GetHashCode();
            return hashId_l1 ^ hashId_l2;
        }
    }
  
}
