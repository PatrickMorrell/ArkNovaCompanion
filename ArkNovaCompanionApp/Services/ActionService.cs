using ArkNovaCompanionApp.Constants;
using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;
using System.Text.Json;

namespace ArkNovaCompanionApp.Services;

public class ActionService : IActionService
{
    private readonly IStorageService _storageService;
    private readonly ICollectionService _collectionService;
    private List<ActionModel> _actions;
    public ActionService(IStorageService storageService, ICollectionService collectionService)
    {
        _storageService = storageService;
        _collectionService = collectionService;
        Actions = _collectionService.GetActions();
        RecalculateActionStrengths();
        OnActionsChanged += RecalculateActionStrengths;
        OnActionsChanged += async () => await UpdateStoredActions();
    }

    public event Action OnActionsChanged;

    public List<ActionModel> Actions { get; set; }

    public void MoveAction(ActionModel action, int position = 0)
    {
        Actions.Remove(action);
        Actions.Insert(position, action);
        OnActionsChanged.Invoke();
	}

	public void MoveAction(string actionName, int position = 0)
	{
        ActionModel action = Actions.First(a => a.Name == actionName);
        MoveAction(action, position);
	}

    public void UpgradeAction(ActionModel action)
    {
        var upgradeAction = Actions.First(a => a.Name == action.Name);
        upgradeAction.IsUpgraded = !upgradeAction.IsUpgraded;
		OnActionsChanged.Invoke();
	}

	public void SetupActions()
	{
        var allActions = _collectionService.GetActions();
        Actions = allActions
            .Where(a => a.Name != ActionNames.Animals)
            .OrderBy(x => Guid.NewGuid()).ToList();
		Actions.Insert(0, allActions.First(a => a.Name == ActionNames.Animals));
        OnActionsChanged.Invoke();
    }

	private void RecalculateActionStrengths()
    {
        for (int i = 0; i < Actions.Count; i++)
        {
            Actions[i].Strength = i + 1;
        }
    }

	public async Task GetStoredActions()
    {
        Actions = await _storageService.GetStoredList<ActionModel>("actions");
        if (Actions is null)
        {
            SetupActions();
        }
    }

    private async Task UpdateStoredActions()
    {
        await _storageService.SaveToStorage("actions", JsonSerializer.Serialize(Actions));
    }
}
