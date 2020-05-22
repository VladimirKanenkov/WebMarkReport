using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MoreLinq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WebMarkReport.Models;
using WebMarkReport.Models.ViewModels;
using System.Collections.Generic;

namespace WebMarkReport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext _context)
        {
            this.context = _context;    
        }

        public IActionResult Index(int buildingId = 2, int sectionId = 4)
        {
            return View(GetTable(buildingId, sectionId));
        }

        /// <summary>
        /// Получение данных из базы для отображения 
        /// </summary>
        /// <param name="buildingId"></param>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        TableViewModel GetTable(int buildingId, int sectionId)
        {
            TableViewModel tableData = new TableViewModel
            {
                L1_name = context.Structures.First(n => n.id_l1 == buildingId).l1_name,
                L2_name = context.Structures.First(n => n.id_l2 == sectionId).l2_name
            };
            var ids = context.Reports.Where(n => (n.id_l1 == buildingId) && (n.id_l2 == sectionId));//все строки для выборки данных в таблицу
            tableData.Technology_cards = context.Reports.
                DistinctBy(n => n.id_technology_card).
                ToDictionary(k => k.id_technology_card, v => v.technology_card_name); //использую MoreLinq DistinctBy
            tableData.Sublayer1_items = context.Structures.
                Where(n => (n.id_l1 == buildingId) && (n.id_l2 == sectionId)).
                DistinctBy(n => n.id_sublayer1).
                OrderByDescending(n => n.Id).
                ToDictionary(k => k.id_sublayer1, v => v.sublayer1_name);

            foreach (var row in ids)
            {
                //var row = _context.Reports.Where(n => n.id == i).First();
                tableData.WorkProgress.Add(new WorkProgress()
                {
                    Accept_quantity = row.accept_quantity,
                    Id_status = row.id_status,
                    Id_sublayer1 = row.id_sublayer1,
                    Id_technology_card = row.id_technology_card,
                    Lag_days_count = row.lag_days_count
                });
            }
            return tableData;
        }
    }
}
