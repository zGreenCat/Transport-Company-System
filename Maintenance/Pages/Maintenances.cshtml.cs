using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maintenance.Pages
{
    public class MaintenancesModel : PageModel
    {
        public List<SuppRegister> SuppRegisterList { get; set; }
        public void OnGet()
        {
            TrucksdbContext context = new TrucksdbContext();
            this.SuppRegisterList = context.SuppRegisters.OrderBy(x => x.Id).ToList();
        }
    }
}