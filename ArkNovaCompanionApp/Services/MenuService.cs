using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;

namespace ArkNovaCompanionApp.Services
{
    public class MenuService : IMenuService
    {
        private readonly ILocalStorageService _storageService;
        private readonly ICollectionService _collectionService;
        public MenuService(ILocalStorageService storageService, ICollectionService collectionService)
        {
            _storageService = storageService;
            _collectionService = collectionService;
            OnMenuChanged += async () => await UpdateStoredMenu();
        }

        public event Action OnMenuChanged;

        public List<MenuItemModel> Menu { get; set; }

        public void SelectItem(MenuItemModel menuItem)
        {
            foreach (MenuItemModel item in Menu)
            {
                item.IsSelected = false;
            }

            menuItem.IsSelected = true;
            ToggleAlert(menuItem, false);
            OnMenuChanged?.Invoke();
        }

        public void ToggleAlert(MenuItemModel menuItem, bool show = true)
        {
            menuItem.ShowAlert = show;
            OnMenuChanged?.Invoke();
        }

        public void ToggleAlert(string menuItemName, bool show = true)
        {
            MenuItemModel menuItem = Menu.First(i => i.ItemName == menuItemName);
            ToggleAlert(menuItem, show);
        }

        public async Task GetStoredMenu()
        {
            var menu = await _storageService.GetItemAsync<List<MenuItemModel>>("menu") ?? [];
			if (menu is null || menu.Count == 0)
			{
				menu = _collectionService.GetMenuDefault();
			}

            Menu = menu;
		    OnMenuChanged?.Invoke();
		}

        private async Task UpdateStoredMenu()
        {
            await _storageService.SetItemAsync("menu", Menu);
        }
    }
}
