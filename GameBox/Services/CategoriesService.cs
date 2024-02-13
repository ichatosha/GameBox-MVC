


namespace GameBox.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly inherDbContext _context;
       

        public CategoriesService(inherDbContext context )
        {
            _context = context;
            
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Categories
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .OrderBy(c => c.Text)
                    .AsNoTracking()
                    .ToList();
        }

        
    }
}
