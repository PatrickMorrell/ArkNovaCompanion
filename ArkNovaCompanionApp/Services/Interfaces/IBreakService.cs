namespace ArkNovaCompanionApp.Services.Interfaces;

public interface IBreakService
{
    event Action OnBreakChanged;

    event Action OnBreakTriggered;

    int BreakAmount { get; set; }

    int StartingBreak { get; set; }

    void AdvanceBreak(int amount = 1);

    void ResetBreak(int amount);

    void RecalculateStartingBreak(int playerCount);

    Task GetStoredBreak(int amount);
}
