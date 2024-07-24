using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces;
public interface IMoneyService
{
    event Action OnMoneyChanged;
    List<CoinModel> Coins { get; set; }
    void AddMoney(CoinModel coin);
    void AddMoney(int money);
    void RemoveMoney(CoinModel coin);
    Task GetStoredMoney();
}