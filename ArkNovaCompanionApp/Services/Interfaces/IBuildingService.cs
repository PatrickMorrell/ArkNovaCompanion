using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces
{
    public interface IBuildingService
	{
		event Action OnBuildingsChanged;

		List<BuildingModel> Buildings { get; set; }

        Task SaveBuildings(List<BuildingModel> selectedBuildings);

        Task GetStoredBuildings();
    }
}