using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services.Interfaces;

public interface ICollectionsService
{
    List<ActionModel> GetActions();
}