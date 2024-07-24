namespace ArkNovaCompanionApp.Models;

public class BuildingModel
{
	public int Size { get; set; }

	public string Name { get; set; }

	public int Amount { get; set; } = 0;

	public string Icon { get; set; }

	public bool IsStandard { get; set; } = false;

	public bool IsSelected { get; set; }
}