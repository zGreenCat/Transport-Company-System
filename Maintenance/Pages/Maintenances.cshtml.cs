using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Maintenance.Pages
{
    public class MaintenancesModel : PageModel
    {
        public List<SuppRegister> SuppRegisterList { get; set; }
        public void OnGet()
        {
            TrucksdbContext context = new TrucksdbContext();
            this.SuppRegisterList = context.SuppRegisters.Include(s => s.Truck).OrderBy(x => x.Id).ToList();
        }
    }
}