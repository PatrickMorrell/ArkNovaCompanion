namespace ArkNovaCompanionApp.Services;

public class BreakService : IBreakService
{
    private readonly ILocalStorageService _storageService;
    private int _breakAmount;
    private int _start;

    public BreakService(ILocalStorageService storageService)
    {
        _storageService = storageService;
        OnBreakChanged += async () => await UpdateStoredBreak();
    }

    public int BreakAmount
    {
        get => _breakAmount;
        set
        {
            if (value != _breakAmount)
            {
                _breakAmount = value;
                OnBreakChanged?.Invoke();
            }
            if (value == 0)
            {
                OnBreakTriggered?.Invoke();
            }
        }
    }

    public int StartingBreak
    {
        get => _start;
        set
        {
            if (value != _start)
            {
                _start = value;
                OnBreakChanged?.Invoke();
            }
        }
    }

    public event Action OnBreakChanged;

    public event Action OnBreakTriggered;

    public void AdvanceBreak(int amount = 1)
    {
        int newBreak = BreakAmount - amount;
        BreakAmount = newBreak < 0 ? 0 : newBreak;
    }

    public void ResetBreak(int amount)
    {
        BreakAmount = amount;
    }

    public void RecalculateStartingBreak(int playerCount)
    {
        switch (playerCount)
        {
            case 4:
                StartingBreak = 15;
                break;
            case 3:
                StartingBreak = 12;
                break;
            default:
                StartingBreak = 9;
                break;
        }
    }

    public async Task GetStoredBreak(int amount)
    {
        int breakAmount = await _storageService.GetItemAsync<int>("break");
        BreakAmount = breakAmount > 0 ? breakAmount : amount;
    }

    private async Task UpdateStoredBreak()
    {
        await _storageService.SetItemAsync("break", BreakAmount);
    }
}
