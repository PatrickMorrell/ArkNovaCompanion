using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces
{
    public interface IBuildingService
	{
		event Action OnBuildingsChanged;

		public List<BuildingTypeModel> BuildingTypes { get; set; }

		public List<BuildingModel> Buildings { get; set; }

		void SaveBuildings(List<BuildingTypeModel> selectedBuildings);

		void RemoveBuilding(string buildingName);

        void ToggleOccupied(BuildingModel building);

		Task GetStoredBuildings();
    }
}