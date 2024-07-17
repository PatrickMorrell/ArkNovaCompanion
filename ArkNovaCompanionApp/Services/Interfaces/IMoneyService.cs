using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces;
public interface IMoneyService
{
    List<CoinModel> Coins { get; set; }
    int Total { get; set; }
    Task AddMoney(CoinModel coin);
    Task AddMoney(int money);
    Task GetStoredMoney();
    Task RemoveMoney(CoinModel coin);
}