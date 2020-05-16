using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebMarkReport.Models;

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
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(context.Structures
                .Select(x => x.l1_name + "::" + x.l2_name)
                .Distinct()
                .OrderBy(x => x));
            /*context.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));*/
            //return "Hello from the Nav View Component";
        }
    }
}

 

