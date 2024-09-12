using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;
using System.Text.Json;

namespace ArkNovaCompanionApp.Services
{
	public class BuildingService : IBuildingService
	{
		private readonly IStorageService _storageService;
		private readonly ICollectionService _collectionService;

		public BuildingService(IStorageService storageService, ICollectionService collectionService)
		{
			_storageService = storageService;
			_collectionService = collectionService;
			BuildingTypes = _collectionService.GetBuildingTypes();
			OnBuildingsChanged += async () => await UpdateStoredBuildings();
		}

		public event Action OnBuildingsChanged;

		public List<BuildingTypeModel> BuildingTypes { get; set; }
		public List<BuildingModel> Buildings { get; set; } = [];

		public void SaveBuildings(List<BuildingTypeModel> selectedBuildings)
		{
			foreach (var building in selectedBuildings)
			{
				Buildings.Add(new() 
				{ 
					Name = building.Name,
					Size = building.Size,
					Icon = building.Icon,
					IsStandard = building.IsStandard,
					Order = building.Order,
				});
			}

			OnBuildingsChanged?.Invoke();
		}

		public void ToggleOccupied(BuildingModel building)
		{
			if (!building.IsStandard)
			{
				return;
			}

			building.IsOccupied = !building.IsOccupied;
			OnBuildingsChanged?.Invoke();
		}

		public async Task GetStoredBuildings()
		{
			Buildings = await _storageService.GetStoredList("buildings", Buildings);
		}

		private async Task UpdateStoredBuildings()
		{
			await _storageService.SaveToStorage("buildings", JsonSerializer.Serialize(Buildings));
		}
	}
}
