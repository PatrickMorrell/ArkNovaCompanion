using ArkNovaCompanionApp.Services.Interfaces;

namespace ArkNovaCompanionApp.Services;

public class BreakService : IBreakService
{
	private readonly IStorageService _storageService;
	private int _breakAmount;
	public BreakService(IStorageService storageService)
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

	public async Task GetStoredBreak(int amount)
	{
		int breakAmount = await _storageService.GetStoredNumber("break");
		BreakAmount = breakAmount > 0 ? breakAmount : amount;
	}

	private async Task UpdateStoredBreak()
	{
		await _storageService.SaveToStorage("break", BreakAmount.ToString());
	}
}
