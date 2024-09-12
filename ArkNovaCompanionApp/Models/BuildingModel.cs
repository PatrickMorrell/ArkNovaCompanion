﻿namespace ArkNovaCompanionApp.Models;

public class BuildingModel
{
	public string Name { get; set; }

	public int Size { get; set; }

	public string Icon { get; set; }

	public bool IsStandard { get; set; }

	public bool IsOccupied { get; set; }

	public int Order { get; set; }
}