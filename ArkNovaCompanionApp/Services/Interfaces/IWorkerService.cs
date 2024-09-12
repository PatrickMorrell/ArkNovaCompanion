using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces
{
    public interface IWorkerService
    {
        List<WorkerModel> Workers { get; set; }

        event Action OnWorkersChanged;

        void AddWorker();
        Task GetStoredWorkers();
        void RemoveWorker();
        void ToggleWorker(WorkerModel worker);
        void ReturnWorkers();
    }
}