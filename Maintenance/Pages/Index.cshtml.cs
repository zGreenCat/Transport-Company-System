using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Maintenance.Pages
{
    public class IndexModel : PageModel
    {
        public int TotalTrucks { get; set; }
        public int AvailableTrucks { get; set; }
        public int MaintenancesToday { get; set; }
        public List<SuppRegister> RecentMaintenances { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            TrucksdbContext _ctx = new TrucksdbContext();
            TotalTrucks = _ctx.Trucks.Count();
            AvailableTrucks = _ctx.Trucks.Count(t => t.Status == "available");
            MaintenancesToday = _ctx.SuppRegisters
                .Count(s => s.Date == DateOnly.FromDateTime(DateTime.Today));

            RecentMaintenances = _ctx.SuppRegisters
                .Include(s => s.Truck)
                .OrderByDescending(s => s.Date)
                .Take(5)
                .ToList();
        }
    }
}
