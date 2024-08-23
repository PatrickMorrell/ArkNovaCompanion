﻿using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces;

public interface ICollectionService
{
    List<ActionModel> GetActions();

	List<CoinModel> GetCoinsDefault();

	List<BuildingModel> GetBuildingsDefault();

	List<WorkerModel> GetWorkersDefault();
}