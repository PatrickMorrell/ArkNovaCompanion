using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;
using System.Text.Json;

namespace ArkNovaCompanionApp.Services;

public class MoneyService : IMoneyService
{
    private readonly IStorageService _storageService;
    private List<CoinModel> _coins;
    public MoneyService(IStorageService storageService)
    {
        _storageService = storageService;
        Coins = GetCoinsDefault();
        OnMoneyChanged += async () => await UpdateStoredMoney();
    }

    public event Action OnMoneyChanged;

    public List<CoinModel> Coins
    {
        get => _coins; 
        set
        {
            if (value != _coins)
            {
                _coins = value;
                OnMoneyChanged?.Invoke();
            }
        }
    }

    public void AddMoney(CoinModel coin)
    {
        Coins.First(c => c.Value == coin.Value).Amount++;
    }

    public void AddMoney(int money)
    {
        Coins.First(c => c.Value == 1).Amount += money;
    }

    public void RemoveMoney(CoinModel coin)
    {
        if (coin.Amount > 0)
        {
            Coins.First(c => c.Value == coin.Value).Amount--;
        }
    }

    public async Task GetStoredMoney()
    {
        Coins = await _storageService.GetStoredList("coins", Coins);
    }

    private List<CoinModel> GetCoinsDefault()
    {
        return new()
        {
            new CoinModel { Value = 1 },
            new CoinModel { Value = 5 },
            new CoinModel { Value = 10 },
            new CoinModel { Value = 20 },
        };
    }

    private async Task UpdateStoredMoney()
    {
        await _storageService.SaveToStorage("coins", JsonSerializer.Serialize(Coins));
    }
}
