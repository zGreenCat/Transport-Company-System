using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Transport.Pages
{
    public class TravelsModel : PageModel
    {

        public List<TravelRegister> Travels { get; set; }
        [BindProperty]
        public int TravelId { get; set; }
        [BindProperty]
        public string newStatus { get; set; }
        public void OnGet()
        {
            TrucksdbContext context = new TrucksdbContext();

            Travels = context.TravelRegisters.OrderBy(x => x.Id).ToList();
        }

        public IActionResult OnPostUpdateStatus()
        {
            TrucksdbContext context = new TrucksdbContext();

            var travel = context.TravelRegisters.Find(TravelId);
            if (travel != null)
            {
                travel.Status = newStatus;
                context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
