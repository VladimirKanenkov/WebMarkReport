using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebMarkReport.Models.ViewModels;
using WebMarkReport.Models;
using System.Collections.Generic;

namespace WebMarkReport.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext context;

        public NavigationMenuViewComponent(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.BuildingId = RouteData?.Values["buildingId"];
            ViewBag.SectionId = RouteData?.Values["sectionId"];
            NavigationViewModel nav = new NavigationViewModel(context.Structures);

            return View(nav.NoduplicatesBuildings);      

        }
    }
}

 

