using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces
{
    public interface IActionService
    {
        event Action OnActionsChanged;

        List<ActionModel> Actions { get; set; }

        Task GetStoredActions();

        void MoveAction(ActionModel action, int position = 0);

        void MoveAction(string actionName, int position = 0);

        void UpgradeAction(ActionModel action);

        void SetupActions();
    }
}