using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maintenance.Pages
{
    public class TrucksModel : PageModel
    {
        public List<Truck> Trucks;

        [BindProperty]
        public int TruckId { get; set; }

        [BindProperty]
        public string NewStatus { get; set; }
        public void OnGet()
        {
            TrucksdbContext context = new TrucksdbContext();

            Trucks = context.Trucks.OrderBy(x => x.Id).ToList();

        }


        public IActionResult OnPostUpdateStatus() 
        {
            TrucksdbContext context = new TrucksdbContext();

            var truck = context.Trucks.Find(TruckId);
            if (truck != null) 
            {
                truck.Status = NewStatus;
                context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
