using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Services
{
    public interface IGamesService
    {
        Task Create(GameViewModel model);
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task<Game?> Update(EditGameViewModel model);
        bool Delete(int id);
    }
}
