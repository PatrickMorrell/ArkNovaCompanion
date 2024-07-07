using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;

namespace ArkNovaCompanionApp.Services
{
    public class CollectionsService : ICollectionsService
    {
        public List<ActionCard> GetActions()
        {
            return new List<ActionCard>()
            {
                new()
                {
                    Name = "Animals",
                    IconName = "paw",
                    Description = "Play Animal cards from your hand.",
                    UpgradedDescription = "Play Animal cards from your hand or within reputation range."
                },
                new()
                {
                    Name = "Association",
                    IconName = "user-large",
                    Description = "Perform exactly one association task.",
                    UpgradedDescription = "Perform one or more different association tasks. You may make one donation."
                },
                new()
                {
                    Name = "Build",
                    IconName = "person-digging",
                    Description = "Build exactly 1 building of your choice with a maximum size of <i class=\"fa-solid fa-square-xmark\"></i> on your zoo map. Pay 2 money per space. Available: Kiosk, pavilion, standard enclosure, and Petting Zoo.",
                    UpgradedDescription = "Build as many different buildings as you like with a maximum total size of <FontAwesome IconName=\"square-xmark\" Size=5></FontAwesome> on your zoo map. Newly available: Large Bird Aviary and Reptile House."
                },
                new()
                {
                    Name = "Cards",
                    IconName = "layer-group",
                    Description = "Advance the Break token 2 spaces. Then draw cards from the deck OR snap.",
                    UpgradedDescription = "Advance the Break token 2 spaces. Then draw cards from the deck or within reputation range OR snap."
                },
                new()
                {
                    Name = "Sponsors",
                    IconName = "at",
                    Description = "Play exactly 1 Sponsor card OR advance the Break token and take money.",
                    UpgradedDescription = "Play one or more Sponsor cards OR advance the Break token and take money."
                }
            };
        }
    }
}
