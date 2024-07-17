using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;
using System.Drawing;
using System.Text.Json;

namespace ArkNovaCompanionApp.Services;

public class MoneyService : IMoneyService
{
    private readonly IStorageService _storageService;
    public MoneyService(IStorageService storageService)
    {
        _storageService = storageService;
        Coins = GetNoCoins();
    }

    private async Task InitializeAsync()
    {
        await GetStoredMoney();
    }

    public Task Initialization { get; private set; }

    public int Total { get; set; } = 0;

    public List<CoinModel> Coins { get; set; }

    public async Task AddMoney(CoinModel coin)
    {
        Total += coin.Value;
        Coins.First(c => c.Value == coin.Value).Amount++;
        await UpdateStoredMoney();
    }

    public async Task AddMoney(int money)
    {
        Total += money;
        Coins.First(c => c.Value == 1).Amount += money;
        await UpdateStoredMoney();
    }

    public async Task RemoveMoney(CoinModel coin)
    {
        if (coin.Amount > 0)
        {
            Total -= coin.Value;
            Coins.First(c => c.Value == coin.Value).Amount--;
            await UpdateStoredMoney();
        }
    }

    public async Task GetStoredMoney()
    {
        string storedTotal = await _storageService.GetFromStorage("moneyTotal");
        if (!int.TryParse(storedTotal, out int moneyTotal))
        {
            moneyTotal = 0;
        }
        Total = moneyTotal;

        string storedCoins = await _storageService.GetFromStorage("coins");
        List<CoinModel> currentCoins = Coins;
        if (!string.IsNullOrEmpty(storedCoins))
        {
            var coinData = JsonSerializer.Deserialize<List<CoinModel>>(storedCoins);
            if (coinData != null)
            {
                currentCoins = coinData;
            }
        }
        Coins = currentCoins;
    }

    private List<CoinModel> GetNoCoins()
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
        await _storageService.SaveToStorage("moneyTotal", Total.ToString());

        await _storageService.SaveToStorage("coins", JsonSerializer.Serialize(Coins));
    }
}
