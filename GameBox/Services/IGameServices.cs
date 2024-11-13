namespace GameBox.Services
{
    public interface IGameServices
    {
        IEnumerable<Game> GetGames();
        IEnumerable<Game> GetGameByName(string SearchValue);
        Game? getById(int id);
        Task Create(CreateGameFormViewModel model);
        Task<Game?> Update(UpdateGameFromViewModel model);
        bool Delete(int id);
    }
}
