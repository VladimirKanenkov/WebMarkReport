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
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _appEnvironment;
        public HomeController(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;          
        }

        public IActionResult Index()
        {
            TableViewData data = GetTable(2, 4);
            return View(data);

        }

        /// <summary>
        /// Получение данных из базы для отображения 
        /// </summary>
        /// <param name="_id_l1"></param>
        /// <param name="_id_l2"></param>
        /// <returns></returns>
        TableViewData GetTable(int _id_l1, int _id_l2)
        {
            TableViewData data = new TableViewData
            {
                L1_name = _context.Structures.First(n => n.id_l1 == _id_l1).l1_name,
                L2_name = _context.Structures.First(n => n.id_l2 == _id_l2).l2_name
            };
            var ids = _context.Reports.Where(n => (n.id_l1 == _id_l1) && (n.id_l2 == _id_l2));//все строки для выборки данных в таблицу
            data.Technology_cards = ids.
                DistinctBy(n=>n.id_technology_card).
                ToDictionary(k => k.id_technology_card, v => v.technology_card_name); //использую MoreLinq DistinctBy
            data.Sublayer1_items = _context.Structures.
                Where(n => (n.id_l1 == _id_l1) && (n.id_l2 == _id_l2)).
                DistinctBy(n => n.id_sublayer1).
                OrderByDescending(n => n.Id).
                ToDictionary(k => k.id_sublayer1, v => v.sublayer1_name);

            foreach (var row in ids)
            {
                //var row = _context.Reports.Where(n => n.id == i).First();
                data.WorkProgress.Add(new Progress()
                {
                    Accept_quantity = row.accept_quantity,
                    Id_status = row.id_status,
                    Id_sublayer1 = row.id_sublayer1,
                    Id_technology_card = row.id_technology_card,
                    Lag_days_count = row.lag_days_count
                });
            }
            return data;
        }

        /*[HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                _context.File.Add(file);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }*/
    }
}
