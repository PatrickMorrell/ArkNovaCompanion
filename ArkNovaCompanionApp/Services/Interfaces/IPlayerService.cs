using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces;

public interface IPlayerService
{
    List<PlayerModel> Players { get; set; }

    event Action OnPlayersChanged;

    void AddPlayer(string icon);
    Task GetStoredPlayers();
    void RemovePlayer(PlayerModel player);
}
