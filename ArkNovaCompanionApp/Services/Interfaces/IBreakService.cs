namespace ArkNovaCompanionApp.Services.Interfaces;

public interface IBreakService
{
    event Action OnBreakChanged;

    event Action OnBreakTriggered;

    int BreakAmount { get; set; }

    void AdvanceBreak(int amount = 1);

    void ResetBreak(int amount);

    Task GetStoredBreak(int amount);
}