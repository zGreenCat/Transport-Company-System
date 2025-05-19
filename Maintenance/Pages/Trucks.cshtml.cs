using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maintenance.Pages
{
    public class TrucksModel : PageModel
    {
        public List<Truck> Trucks;
        public void OnGet()
        {
            TrucksdbContext context = new TrucksdbContext();

            Trucks = context.Trucks.OrderBy(x => x.Id).ToList();

        }
    }
}
