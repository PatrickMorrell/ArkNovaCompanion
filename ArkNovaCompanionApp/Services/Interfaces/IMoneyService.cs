﻿using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces;
public interface IMoneyService
{
    event Action OnMoneyChanged;

    List<CoinModel> Coins { get; set; }

    void AddMoney(CoinModel coin);

    void AddCoins(int money);

    void RemoveMoney(CoinModel coin);

    void ClearMoney();

    void DistributeCoinsFromTotal(int money);

    int GetMoneyTotal();

    Task GetStoredMoney();
}