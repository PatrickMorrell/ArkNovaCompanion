using ArkNovaCompanionApp.Services.Interfaces;
using Microsoft.JSInterop;
using System.Text.Json;
namespace ArkNovaCompanionApp.Services;

public class StorageService : IStorageService
{
	private readonly IJSRuntime _jsRuntime;

	public StorageService(IJSRuntime jsRuntime)
	{
		_jsRuntime = jsRuntime;
	}

	public async Task<string> GetFromStorage(string key)
	{
		return await _jsRuntime.InvokeAsync<string>("getItem", key);
	}

	public async Task SaveToStorage(string key, string value)
	{
		await _jsRuntime.InvokeVoidAsync("setItem", key, value);
	}

	public async Task<int> GetStoredNumber(string key)
	{
		string storedValue = await GetFromStorage(key);
		if (!int.TryParse(storedValue, out int value))
		{
			value = 0;
		}
		return value;
	}

	public async Task<List<T>> GetStoredList<T>(string key, List<T> currentList)
	{
		string storedList = await GetFromStorage(key);
		List<T> list = currentList;
		if (!string.IsNullOrEmpty(storedList))
		{
			var listData = JsonSerializer.Deserialize<List<T>>(storedList);
			if (listData != null)
			{
				list = listData;
			}
		}
		return list;
    }

    public async Task<List<T>> GetStoredList<T>(string key)
    {
        string storedList = await GetFromStorage(key);
        List<T> list = null;
        if (!string.IsNullOrEmpty(storedList))
        {
            var listData = JsonSerializer.Deserialize<List<T>>(storedList);
            if (listData != null)
            {
                list = listData;
            }
        }
        return list;
    }
}
