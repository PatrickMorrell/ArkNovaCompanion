namespace ArkNovaCompanionApp.Services.Interfaces;

public interface IStorageService
{
    Task<string> GetFromStorage(string key);

    Task SaveToStorage(string key, string value);

    Task<int> GetStoredNumber(string key);

    Task<List<T>> GetStoredList<T>(string key, List<T> currentList);

    Task<List<T>> GetStoredList<T>(string key);
}