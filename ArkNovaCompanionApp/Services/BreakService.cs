using ArkNovaCompanionApp.Services.Interfaces;

namespace ArkNovaCompanionApp.Services;

public class BreakService : IBreakService
{
    public int BreakAmount { get; set; } = 0;

    public event Action OnBreakTriggered;

    public void AdvanceBreak(int amount = 1)
    {
        int newBreak = BreakAmount - amount;
        BreakAmount = newBreak < 0 ? 0 : newBreak;
        if (BreakAmount == 0)
        {
            OnBreakTriggered?.Invoke();
        }
    }

    public void ResetBreak(int amount)
    {
        BreakAmount = amount;
    }
}
