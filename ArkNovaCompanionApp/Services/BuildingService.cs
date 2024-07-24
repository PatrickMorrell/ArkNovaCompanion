using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;
using System.Drawing;
using System.Text.Json;

namespace ArkNovaCompanionApp.Services
{
	public class BuildingService : IBuildingService
	{
		private readonly IStorageService _storageService;
		private List<BuildingModel> _buildings;
		public BuildingService(IStorageService storageService)
		{
			_storageService = storageService;
			Buildings = GetBuildingsDefault();
			OnBuildingsChanged += async () => await UpdateStoredBuildings();
		}

		public event Action OnBuildingsChanged;

		public List<BuildingModel> Buildings
		{
			get => _buildings;
			set
			{
				if (value != _buildings)
				{
					_buildings = value;
					OnBuildingsChanged?.Invoke();
				}
			}
		}

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

		public List<BuildingModel> GetBuildingsDefault()
		{
			return new()
			{
				new()
				{
					Size = 1,
					Name = "Standard Size One",
					Icon = "dice-one",
					IsStandard = true,
				},
				new()
				{
					Size = 2,
					Name = "Standard Size Two",
					Icon = "dice-two",
					IsStandard = true,
				},
				new()
				{
					Size = 3,
					Name = "Standard Size Three",
					Icon = "dice-three",
					IsStandard = true,
				},
				new()
				{
					Size = 4,
					Name = "Standard Size Four",
					Icon = "dice-four",
					IsStandard = true,
				},
				new()
				{
					Size = 5,
					Name = "Standard Size Five",
					Icon = "dice-five",
					IsStandard = true,
				},
				new()
				{
					Size = 1,
					Name = "Kiosk",
					Icon = "store",
				},
				new()
				{
					Size = 1,
					Name = "Pavilion",
					Icon = "landmark-dome",
				},
				new()
				{
					Size = 3,
					Name = "Petting Zoo",
					Icon = "cow",
				},
				new()
				{
					Size = 5,
					Name = "Reptile House",
					Icon = "worm",
				},
				new()
				{
					Size = 5,
					Name = "Large Bird Aviary",
					Icon = "dove",
				},
			};
		}

		private async Task UpdateStoredBuildings()
		{
			await _storageService.SaveToStorage("buildings", JsonSerializer.Serialize(Buildings));
		}
	}
}
