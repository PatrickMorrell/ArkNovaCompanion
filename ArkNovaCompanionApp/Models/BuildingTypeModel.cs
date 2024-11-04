namespace ArkNovaCompanionApp.Models;

public class BuildingTypeModel
{
	public string Name { get; set; }

	public int Size { get; set; }

	public string Icon { get; set; }

	public bool IsStandard { get; set; }

	public bool IsSelected { get; set; }

	public int Order { get; set; }
}