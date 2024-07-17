namespace ArkNovaCompanionApp.Services.Interfaces;

public interface IStorageService
{
    Task<string> GetFromStorage(string key);
    Task SaveToStorage(string key, string value);
}