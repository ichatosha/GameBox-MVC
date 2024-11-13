

namespace GameBox.Controllers
{
    public class GamesController : Controller
    {


        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGameServices _gameService;

        public GamesController(IDevicesService devicesService, ICategoriesService categoriesService, IGameServices gameService)
        {
            _devicesService = devicesService;
            _categoriesService = categoriesService;
            _gameService = gameService;
        }

        #region GetAll
        public IActionResult Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                var games = _gameService.GetGames();
                return View(games);
            }
            else
            {
                var game = _gameService.GetGameByName(searchValue);
                return View(game);
            }
        }
        #endregion

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                // initialization
                Categories = _categoriesService.GetSelectList(),

                Devices = _devicesService.GetDevices()
            };


            return View(viewModel);
        }

        [HttpPost]
        // more secure
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {

                model.Categories = _categoriesService.GetSelectList();

                model.Devices = _devicesService.GetDevices();

                return View(model);
            }
            // save game in database
            // save cover to server

            await _gameService.Create(model);
            return RedirectToAction("Index");

        }
        #endregion

        #region Details
        public IActionResult Details(int id)
        {
            var game = _gameService.getById(id);
            if (game is not null)
            {
                return View(game);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var game = _gameService.getById(id);
            if (game is null)
            {
                return NotFound();
            }

            UpdateGameFromViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(s => s.DeviceId).ToList(),
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetDevices(),
                CurrentCover = game.Cover

            };

            return View(viewModel);
        }
        [HttpPost]
        // more secure
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateGameFromViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetDevices();
                return View(model);
            }
            // save game in database
            // save cover to server
            var game = await _gameService.Update(model);
            if (game is null)
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gameService.Delete(id);

            if (isDeleted)
            {
                return Ok(); // Respond with OK for successful deletion
            }

            return BadRequest(); // Respond with BadRequest if deletion fails
        }


        #endregion
    }

}
