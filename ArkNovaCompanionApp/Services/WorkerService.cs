using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services;

public class WorkerService : IWorkerService
{
    private readonly ILocalStorageService _storageService;
    private readonly ICollectionService _collectionService;

    public WorkerService(ILocalStorageService storageService, ICollectionService collectionService)
    {
        _storageService = storageService;
        _collectionService = collectionService;
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
            var worker = Workers.Where(w => w.IsActive).Last();
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

    public void ReturnWorkers()
    {
        foreach (var worker in Workers)
        {
            worker.IsUsed = false;
        }

        OnWorkersChanged?.Invoke();
    }

    public async Task GetStoredWorkers()
    {
        Workers = await _storageService.GetItemAsync<List<WorkerModel>>("workers") ?? _collectionService.GetWorkersDefault();
        OnWorkersChanged?.Invoke();
    }

    private async Task UpdateStoredWorkers()
    {
        await _storageService.SetItemAsync("workers", Workers);
    }
}
