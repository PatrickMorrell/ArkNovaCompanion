namespace ArkNovaCompanionApp.Services;

public class TokenService : ITokenService
{
    private readonly ILocalStorageService _storageService;
    private int _tokenAmount;
    public TokenService(ILocalStorageService storageService)
    {
        _storageService = storageService;
        OnTokensChanged += async () => await UpdateStoredTokens();
    }

    public int TokenAmount
    {
        get => _tokenAmount;
        set
        {
            if (value != _tokenAmount)
            {
                _tokenAmount = value;
                OnTokensChanged?.Invoke();
            }
        }
    }

    public event Action OnTokensChanged;

    public void AddToken()
    {
        if (TokenAmount < 5)
        {
            TokenAmount++;
        }
    }

	public void RemoveTokens(int amount = 1)
    {
        if (TokenAmount > 0)
        {
            TokenAmount -= amount;
        }
    }

    public async Task GetStoredTokens()
    {
		TokenAmount = await _storageService.GetItemAsync<int>("tokens");
    }

    private async Task UpdateStoredTokens()
    {
        await _storageService.SetItemAsync("tokens", TokenAmount);
    }
}
