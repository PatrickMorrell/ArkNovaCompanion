namespace ArkNovaCompanionApp.Services.Interfaces
{
    public interface ITokenService
    {
        int TokenAmount { get; set; }

        event Action OnTokensChanged;

        void AddToken();

        void RemoveTokens(int amount = 1);

		Task GetStoredTokens();
    }
}