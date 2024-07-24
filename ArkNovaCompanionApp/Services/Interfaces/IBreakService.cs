﻿namespace ArkNovaCompanionApp.Services.Interfaces;

public interface IBreakService
{
    int BreakAmount { get; set; }
    event Action OnBreakChanged;
    event Action OnBreakTriggered;
    void AdvanceBreak(int amount = 1);
    void ResetBreak(int amount);
    Task GetStoredBreak(int amount);
}