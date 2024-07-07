using Microsoft.AspNetCore.Components;

namespace ArkNovaCompanionApp.Models
{
    public class ActionCard
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? UpgradedDescription { get; set; }

        public MarkupString RenderedDescription => new(Description ?? string.Empty);

        public MarkupString RenderedUpgradedDescription => new(UpgradedDescription ?? string.Empty);

        public string? IconName { get; set; }

        public bool Upgraded { get; set; } = false;

    }
}
