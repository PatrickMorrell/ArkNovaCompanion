using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services
{
    public class ScoreService : IScoreService
	{
		private readonly ILocalStorageService _storageService;
		public ScoreService(ILocalStorageService storageService)
		{
			_storageService = storageService;
			OnScoreChanged += async () => await UpdateStoredScores();
		}

		public event Action OnScoreChanged;

		public ScoresModel Scores { get; set; }

		public void UpdateConservation(int points)
		{
			int updatedConservation = Scores.Conservation + points;
			if (updatedConservation >= 0 && updatedConservation <= 41)
			{
				Scores.Conservation = updatedConservation;
				OnScoreChanged.Invoke();
			}
		}

		public void UpdateAppeal(int points)
		{
			int updatedAppeal = Scores.Appeal + points;
			if (updatedAppeal >= 0 && updatedAppeal <= 113)
			{
				Scores.Appeal = updatedAppeal;
				OnScoreChanged.Invoke();
			}
		}

		public void UpdateReputation(int points)
		{
			int updatedReputation = Scores.Reputation + points;
			if (updatedReputation >= 1 && updatedReputation <= 15)
			{
				Scores.Reputation = updatedReputation;
				OnScoreChanged.Invoke();
			}
		}

		public int CalculateIncomeFromAppeal()
		{
			int appeal = Scores.Appeal;
			if (appeal > 95)
			{
				return 35 + (int)((appeal - 96) / 6);
			}
			else if (appeal > 55)
			{
				return 27 + (int)((appeal - 56) / 5);
			}
			else if (appeal > 31)
			{
				return 21 + (int)((appeal - 32) / 4);
			}
			else if (appeal > 16)
			{
				return 16 + (int)((appeal - 17) / 3);
			}
			else if (appeal > 4)
			{
				return 10 + (int)((appeal - 5) / 2);
			}

			return appeal + 5;
		}

		public async Task GetStoredScores()
		{
			Scores = await _storageService.GetItemAsync<ScoresModel>("scores") ?? new();
		}

		private async Task UpdateStoredScores()
		{
			await _storageService.SetItemAsync("scores", Scores);
		}
	}
}
