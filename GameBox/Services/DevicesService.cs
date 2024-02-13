

namespace GameBox.Services
{
    
    public class DevicesService : IDevicesService
    {
        private readonly inherDbContext _context;

        public DevicesService(inherDbContext context )
        {

            _context = context;
            
        }

        public IEnumerable<SelectListItem> GetDevices()
        {
            return  _context.Devices
                    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                    .OrderBy(d => d.Text)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
