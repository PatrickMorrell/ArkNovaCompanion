using ArkNovaCompanionApp.Services.Interfaces;
using Microsoft.JSInterop;
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
}
