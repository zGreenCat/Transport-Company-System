using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Maintenance.Pages
{
    public class createMaintenanceModel : PageModel
    {

        public List<SelectListItem> TruckOptions { get; set; }

        [BindProperty,Required(ErrorMessage ="Debe seleccionar un camion")]
        public int TruckId { get; set; }

        [BindProperty,DataType(DataType.Date),Required]
        public DateOnly Date { get; set; }

        [BindProperty,StringLength(1000,MinimumLength = 5)]
        public string Description { get; set; }
        public void OnGet()
        {
            TrucksdbContext context = new TrucksdbContext();
            TruckOptions = context.Trucks.OrderBy(x => x.Id).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Brand} {t.Model} (#{t.Id})"
            }).ToList();

            Date = DateOnly.FromDateTime(DateTime.Today);
        }

        public IActionResult OnPost() 
        {
            TrucksdbContext context = new TrucksdbContext();
            if (!ModelState.IsValid) 
            {
                OnGet();
                return Page();
            }
            var mant = new SuppRegister
            {
                TruckId = TruckId,
                Date = Date,
                Description = Description
            };

            context.SuppRegisters.Add( mant );
            context.SaveChanges();

            return RedirectToPage();

        }
    }
}
