using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services;

public class PlayerService : IPlayerService
{
    private readonly ILocalStorageService _storageService;
    private readonly ICollectionService _collectionService;
    private readonly IBreakService _breakService;

    public PlayerService(
        ILocalStorageService storageService,
        ICollectionService collectionService,
        IBreakService breakService
    )
    {
        _storageService = storageService;
        _collectionService = collectionService;
        _breakService = breakService;
        OnPlayersChanged += async () => await UpdateStoredPlayers();
        OnPlayersChanged += () => _breakService.RecalculateStartingBreak(Players?.Count ?? 0);
    }

    public List<PlayerModel> Players { get; set; }

    public event Action OnPlayersChanged;

    public void AddPlayer(string icon)
    {
        int players = Players.Count;
        if (players < 4 && !Players.Exists(p => p.Icon == icon))
        {
            Players.Add(new() { Position = players, Icon = icon });
            OnPlayersChanged?.Invoke();
        }
    }

    public void RemovePlayer(PlayerModel player)
    {
        if (Players.Count > 0 && player is not null)
        {
            Players.Remove(player);
            foreach (PlayerModel otherPlayer in Players.Where(p => p.Position > player.Position))
            {
                otherPlayer.Position = otherPlayer.Position - 1;
            }
            OnPlayersChanged?.Invoke();
        }
    }

    public async Task GetStoredPlayers()
    {
        Players = await _storageService.GetItemAsync<List<PlayerModel>>("players") ?? new();
        OnPlayersChanged?.Invoke();
    }

    private async Task UpdateStoredPlayers()
    {
        await _storageService.SetItemAsync("players", Players);
    }
}
