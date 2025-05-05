using GameZone.Data;
using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly IDevicesService _devicesService;
        private readonly ICategoriesService _categoriesService;
        private readonly IGamesService _gamesService;

        public GamesController(AppDbContext context, ICategoriesService categoriesService, IDevicesService devicesService, IGamesService gamesService)
        {
            _devicesService = devicesService;
            _categoriesService = categoriesService;
            _gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var games = _gamesService.GetAll();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gamesService.GetById(id);

            if (game is null)
                return NotFound();

            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GameViewModel model = new()
            {
                Categories = _categoriesService.GetCategoryList(),
                Devices = _devicesService.GetDevicesList(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameViewModel game)
        {
            if (!ModelState.IsValid)
            {
                game.Categories = _categoriesService.GetCategoryList();
                game.Devices = _devicesService.GetDevicesList();
                return View(game);
            }
               

            await _gamesService.Create(game);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gamesService.GetById(id);

            if (game is null)
                return NotFound();

            EditGameViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _categoriesService.GetCategoryList(),
                Devices = _devicesService.GetDevicesList(),
                CurrentCover = game.Cover
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetCategoryList();
                model.Devices = _devicesService.GetDevicesList();
                return View(model);
            }

            var game = await _gamesService.Update(model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gamesService.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}
