



using Microsoft.AspNetCore.Http.HttpResults;

namespace GameBox.Services
{
    public class GameServices : IGameServices
    {
        private readonly inherDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly string _imagePath;
        public GameServices(inherDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _imagePath = $"{_environment.WebRootPath}{FileSettings.ImagePath}";
        }

        public IEnumerable<Game> GetGames()
        {
            var games = _context.Games
                .Include(g=>g.Category)
                .Include(g=>g.Devices)
                .ThenInclude(d=>d.devices)
                .AsNoTracking()
                .ToList();
            return games;
        }
        public Game? getById(int id)
        {
            var gets = _context.Games
                        .Include(g => g.Category)
                        .Include(g => g.Devices)
                        .ThenInclude(d => d.devices)
                        .AsNoTracking()
                        .SingleOrDefault(g=>g.Id==id);
            return gets;
        }

        public async Task Create(CreateGameFormViewModel modelC)
        {

            // generate name for the cover to save in server
            var coverName = await SaveCoverInServer(modelC.Cover);

            Game game = new Game()
            {
                Name = modelC.Name,
                Description = modelC.Description,
                CategoryId  = modelC.CategoryId,
                Cover = coverName,
                Devices = modelC.SelectedDevices.Select(d=> new GameDevices { DeviceId = d}).ToList()
            };
            _context.Add(game);
            _context.SaveChanges();
        }

        public async Task<Game?> Update(UpdateGameFromViewModel model)
        {
            var game = _context.Games
                .Include(g => g.Devices)
                .SingleOrDefault(g => g.Id == model.Id);
            if (game is null)
            {
                return null;
            }

            var IfNewCover = model.Cover is not null;
            // save the current cover in varibale because we will need it when we will add a new cover and delete the old one:
            var CurrentCover = game.Cover;

            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.Devices = model.SelectedDevices.Select(d => new GameDevices { DeviceId = d }).ToList();

            if(IfNewCover)
            {
                game.Cover = await SaveCoverInServer(model.Cover!);
            }

            var effectedRows = _context.SaveChanges();
            if(effectedRows > 0)
            {
                if (IfNewCover)
                {
                    // delete the old one 
                    var cover = Path.Combine(_imagePath, CurrentCover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {
                // if the operation of the change the cover not complete for any reason we will need to delete the new cover we dont need it untill the operation success:
                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(game.Cover);

                return null;
            }
        }

        public bool Delete(int id)
        {
            var IsDeleted = false;

            var game = _context.Games.Find(id);

            if (game is null )
            {
                return IsDeleted;
            }
            _context.Games.Remove(game);

            var effectedRows = _context.SaveChanges();

            if(effectedRows > 0)
            {
                IsDeleted = true;
                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);
            }


            return true;
        }

        private async Task<string> SaveCoverInServer(IFormFile Cover)
        {
            // generate name for the cover to save in server
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";
            // path save:
            var path = Path.Combine(_imagePath, coverName);
            // save cover in server
            using var stream = File.Create(path);
            await Cover.CopyToAsync(stream);
            stream.Dispose();

            return coverName;
        }

       
    }

}
