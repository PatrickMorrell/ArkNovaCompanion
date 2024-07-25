using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;
using System.Text.Json;

namespace ArkNovaCompanionApp.Services
{
	public class BuildingService : IBuildingService
	{
		private readonly IStorageService _storageService;
		private readonly ICollectionService _collectionService;

		private List<BuildingModel> _buildings;
		public BuildingService(IStorageService storageService, ICollectionService collectionService)
		{
			_storageService = storageService;
			_collectionService = collectionService;
			Buildings = _collectionService.GetBuildingsDefault();
			OnBuildingsChanged += async () => await UpdateStoredBuildings();
		}

		public event Action OnBuildingsChanged;

		public List<BuildingModel> Buildings { get; set; }

		public async Task SaveBuildings(List<BuildingModel> selectedBuildings)
		{
			foreach (var building in selectedBuildings)
			{
				Buildings.First(b => b.Name == building.Name).Amount++;
			}
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
