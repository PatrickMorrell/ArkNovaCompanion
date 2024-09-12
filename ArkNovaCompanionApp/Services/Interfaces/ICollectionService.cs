using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces;

public interface ICollectionService
{
    List<ActionModel> GetActions();

	List<CoinModel> GetCoinsDefault();

	List<BuildingTypeModel> GetBuildingTypes();

	List<WorkerModel> GetWorkersDefault();
}