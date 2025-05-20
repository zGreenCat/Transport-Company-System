using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Transport.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TrucksdbContext _ctx;
        public int TotalTrips { get; private set; }
        public int TripsInProgress { get; private set; }
        public int ScheduledTrips { get; private set; }
        public int CompletedTrips { get; private set; }
        public List<TravelRegister> RecentTrips { get; private set; }
        [BindProperty] public int TripId { get; set; }
        [BindProperty] public string NewStatus { get; set; }
        public string[] StatusOptions { get; } = { "Terminado", "Iniciado" };
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            TrucksdbContext _ctx = new TrucksdbContext();
            TotalTrips = _ctx.TravelRegisters.Count();
            TripsInProgress = _ctx.TravelRegisters.Count(t => t.Status == "in_travel");
            ScheduledTrips = _ctx.TravelRegisters.Count(t => t.Status == "scheduled");
            CompletedTrips = _ctx.TravelRegisters.Count(t => t.Status == "completed");
            RecentTrips = _ctx.TravelRegisters
                                .Include(t => t.IdTruckNavigation)
                                .OrderByDescending(t => t.Date)
                                .Take(5)
                                .ToList();

        }
        public IActionResult OnPostUpdateTripStatus()
        {
            TrucksdbContext _ctx = new TrucksdbContext();
            var trip = _ctx.TravelRegisters.Find(TripId);
            if (trip != null)
            {
                trip.Status = NewStatus;
                _ctx.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
