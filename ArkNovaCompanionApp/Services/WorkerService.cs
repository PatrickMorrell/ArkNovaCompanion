using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;
using System.Text.Json;

namespace ArkNovaCompanionApp.Services;

public class WorkerService : IWorkerService
{
	private readonly IStorageService _storageService;
	private readonly ICollectionService _collectionService;

	public WorkerService(IStorageService storageService, ICollectionService collectionService)
	{
		_storageService = storageService;
		_collectionService = collectionService;
		Workers = _collectionService.GetWorkersDefault();
		OnWorkersChanged += async () => await UpdateStoredWorkers();
	}

	public List<WorkerModel> Workers { get; set; }

	public event Action OnWorkersChanged;

	public void AddWorker()
	{
		if (Workers.Count(w => !w.IsActive) > 0)
		{
			Workers.Where(w => !w.IsActive).First().IsActive = true;
			OnWorkersChanged?.Invoke();
		}
	}

	public void RemoveWorker()
	{
		if (Workers.Count(w => w.IsActive) > 0)
		{
			var worker = Workers.Where(w => w.IsActive).First();
			worker.IsActive = false;
			worker.IsUsed = false;
			OnWorkersChanged?.Invoke();
		}
	}

	public void ToggleWorker(WorkerModel worker)
	{
		if (!worker.IsActive)
		{
			return;
		}

		worker.IsUsed = !worker.IsUsed;
		OnWorkersChanged?.Invoke();
	}
	public async Task GetStoredWorkers()
	{
		Workers = await _storageService.GetStoredList("workers", Workers);
	}

	private async Task UpdateStoredWorkers()
	{
		await _storageService.SaveToStorage("workers", JsonSerializer.Serialize(Workers));
	}
}
