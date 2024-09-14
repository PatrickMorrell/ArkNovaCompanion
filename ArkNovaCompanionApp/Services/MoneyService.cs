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
		Coins = _collectionService.GetCoinsDefault();
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

	public async Task GetStoredMoney()
	{
		var coins = await _storageService.GetItemAsync<List<CoinModel>>("coins");
		Coins = coins ?? _collectionService.GetCoinsDefault();
	}

	private async Task UpdateStoredMoney()
	{
		await _storageService.SetItemAsync("coins", Coins);
	}
}
