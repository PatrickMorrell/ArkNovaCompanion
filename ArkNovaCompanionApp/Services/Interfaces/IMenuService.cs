using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces
{
    public interface IMenuService
    {
        List<MenuItemModel> Menu { get; set; }

        event Action OnMenuChanged;

        Task GetStoredMenu();
        void SelectItem(MenuItemModel menuItem);
        void ToggleAlert(MenuItemModel menuItem, bool show = true);
        void ToggleAlert(string menuItemName, bool show = true);
    }
}