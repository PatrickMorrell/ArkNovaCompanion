namespace ArkNovaCompanionApp.Models;

public class ActionModel
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? UpgradedDescription { get; set; }

    public string? IconName { get; set; }

    public bool Upgraded { get; set; } = false;

}
