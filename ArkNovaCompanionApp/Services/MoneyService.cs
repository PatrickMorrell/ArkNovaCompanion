using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services;

public class MoneyService : IMoneyService
{
	private readonly ILocalStorageService _storageService;
	private readonly ICollectionService _collectionService;

	public MoneyService(ILocalStorageService storageService, ICollectionService collectionService)
	{
		_storageService = storageService;
		_collectionService = collectionService;
		OnMoneyChanged += async () => await UpdateStoredMoney();
	}

	public event Action OnMoneyChanged;

	public List<CoinModel> Coins { get; set; }

	public void AddMoney(CoinModel coin)
	{
		Coins.First(c => c.Value == coin.Value).Amount++;
		OnMoneyChanged?.Invoke();
	}

	public void AddCoins(int money)
	{
		Coins.First(c => c.Value == 1).Amount += money;
		OnMoneyChanged?.Invoke();
	}

	public void RemoveMoney(CoinModel coin)
	{
		if (coin.Amount > 0)
		{
			Coins.First(c => c.Value == coin.Value).Amount--;
			OnMoneyChanged?.Invoke();
		}
    }

	public void ClearMoney()
	{
		foreach (CoinModel coin in Coins)
		{
			coin.Amount = 0;
        }

        OnMoneyChanged?.Invoke();
    }

	public void DistributeCoinsFromTotal(int money)
	{
		int remaining = money;
        foreach (CoinModel coin in Coins.OrderByDescending(c => c.Value))
        {
			while (remaining >= coin.Value) 
			{
				coin.Amount++;
				remaining -= coin.Value;
			}
        }

        OnMoneyChanged?.Invoke();
    }

    public int GetMoneyTotal()
    {
        if (Coins is null)
        {
            return 0;
        }
        else
        {
            return Coins.Sum(c => c.Value * c.Amount);
        }
    }

    public async Task GetStoredMoney()
	{
		var coins = await _storageService.GetItemAsync<List<CoinModel>>("coins");
		if (coins is null)
		{
			coins = _collectionService.GetCoinsDefault();
		}

		Coins = coins;
        OnMoneyChanged?.Invoke();
    }

	private async Task UpdateStoredMoney()
	{
		await _storageService.SetItemAsync("coins", Coins);
	}
}
