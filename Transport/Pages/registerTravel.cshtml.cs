using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Transport.Pages
{
    public class registerTravelModel : PageModel
    {
        
        public List<SelectListItem> TruckOptions { get; set; }

        [BindProperty, DataType(DataType.Date), Required]
        public DateOnly Date { get; set; }

        [BindProperty, StringLength(25, MinimumLength = 5,ErrorMessage ="El destino debe tener 5 caracteres minimos")]
        public string Destination { get; set; }
        [BindProperty, Required(ErrorMessage = "Debe seleccionar un camion")]
        public int TruckId { get; set; }
        public void OnGet()
        {
            TrucksdbContext context = new TrucksdbContext();
            TruckOptions = context.Trucks.Where(t => t.Status=="Disponible").OrderBy(x => x.Id).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Brand} {t.Model} (#{t.Id})"
            }).ToList();
            Date = DateOnly.FromDateTime(DateTime.Today);
        }

        public IActionResult OnPost()
        {
            TrucksdbContext context = new TrucksdbContext();
            if (!ModelState.IsValid) {
                OnGet();
                return Page();
            }
            var travel = new TravelRegister
            {
                IdTruck = TruckId,
                Date = Date,
                Destination = Destination,
                Status = "Iniciado",
            };
            context.TravelRegisters.Add(travel);
            context.SaveChanges();
            return RedirectToPage();
        }
    }
}
