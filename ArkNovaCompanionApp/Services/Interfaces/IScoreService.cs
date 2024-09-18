using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces
{
    public interface IScoreService
    {
        ScoresModel Scores { get; set; }

        event Action OnScoreChanged;

        Task GetStoredScores();
        void UpdateAppeal(int points);
        void UpdateConservation(int points);
        void UpdateReputation(int points);
        int CalculateIncomeFromAppeal();

	}
}