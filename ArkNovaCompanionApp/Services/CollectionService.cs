using ArkNovaCompanionApp.Constants;
using ArkNovaCompanionApp.Models;

namespace ArkNovaCompanionApp.Services;

public class CollectionService : ICollectionService
{
	const string BREAK_ICON = "mug-hot";
	const string KIOSK_ICON = "store";
	const string PAVILION_ICON = "landmark-dome";
	const string PETTING_ZOO_ICON = "cow";
	const string REPTILE_HOUSE_ICON = "worm";
	const string AVIARY_ICON = "dove";

	public List<ActionModel> GetActions()
	{
		const string ACTION_STRENGTH = "<i class=\"bi bi-[STRENGTH]-square-fill fs-3 px-1\"></i>";
		const string BREAK_TOKEN = $"<i class=\"fa-solid fa-{BREAK_ICON} fs-3 px-1\"></i>";
		const string REPTILE_HOUSE = $"<i class=\"fa-solid fa-{REPTILE_HOUSE_ICON} fs-3 px-1\"></i>";
		const string AVIARY = $"<i class=\"fa-solid fa-{AVIARY_ICON} fs-3 px-1\"></i>";
		const string DIV = "<div class=\"mb-4\">";

		return
        [
            new()
			{
				Name = ActionNames.Animals,
				IconName = "paw",
				Description = $"{DIV}Play <strong>[ANIMALS]</strong> from your <strong>hand</strong></div>",
				UpgradedDescription = $"{DIV}Play <strong>[ANIMALS]</strong> from your <strong>hand</strong> or within <strong>reputation range</strong> (with additional costs)</div>[REPUTATION]"
			},
			new()
			{
				Name = ActionNames.Association,
				IconName = "user-large",
				Description = $"{DIV}Perform exactly <strong>one association task</strong> with a maximum value of {ACTION_STRENGTH}</div>",
				UpgradedDescription = $"{DIV}Perform <strong>one or more different association tasks</strong> with a maximum total value of {ACTION_STRENGTH}</div>{DIV}In addition, you may make one <strong>donation</strong></div>{DIV}You may play <strong>Conservation Project</strong> cards from within <strong>reputation range</strong> (with additional costs)</div>"
			},
			new()
			{
				Name = ActionNames.Build,
				IconName = "hammer",
				Description = $"{DIV}Build exactly <strong>one building</strong> of your choice with a maximum size of {ACTION_STRENGTH} on your zoo map</div>{DIV}Pay 2 money per space</div>",
				UpgradedDescription = $"{DIV}Build <strong>one or more different buildings</strong> with a maximum total size of {ACTION_STRENGTH} on your zoo map</div>{DIV}Pay 2 money per space</div><div>Newly available:<ul><li>Large Bird Aviary {AVIARY}</li><li>Reptile House {REPTILE_HOUSE}</li></ul></div>"
			},
			new()
			{
				Name = ActionNames.Cards,
				IconName = "layer-group",
				Description = $"{DIV}Advance the Break {BREAK_TOKEN} token 2 spaces</div>{DIV}Then <strong>draw [CARDS]</strong> from the deck[DISCARD]</div>[SNAP]",
				UpgradedDescription = $"{DIV}Advance the Break {BREAK_TOKEN} token 2 spaces</div>{DIV}Then <strong>draw [CARDS]</strong> from the deck or within <strong>reputation range</strong>[DISCARD]</div>[SNAP]"
			},
			new()
			{
				Name = ActionNames.Sponsors,
				IconName = "at",
				Description = $"{DIV}Play exactly <strong>one</strong> Sponsor card with a maximum level of {ACTION_STRENGTH} from your hand</div>{DIV}OR</div>{DIV}Advance the Break {BREAK_TOKEN} token {ACTION_STRENGTH} and gain {ACTION_STRENGTH} money</div>",
				UpgradedDescription = $"{DIV}Play <strong>one or more</strong> Sponsor cards with a maximum total level of {ACTION_STRENGTH} <strong>+ 1</strong> from your hand or from withing reputation range (with additional costs)</div>{DIV}OR</div>{DIV}Advance the Break {BREAK_TOKEN} token {ACTION_STRENGTH} and gain <strong>2 x</strong> {ACTION_STRENGTH} money</div>"
			}
		];
	}

	public List<CoinModel> GetCoinsDefault()
	{
		return
        [
            new CoinModel { Value = 1, Amount = 5 },
			new CoinModel { Value = 5, Amount = 2 },
			new CoinModel { Value = 10,  Amount = 1 },
			new CoinModel { Value = 20 },
		];
	}

	public List<BuildingTypeModel> GetBuildingTypes()
	{
		return
        [
            new()
			{
				Size = 1,
				Name = BuildingTypes.StandardSizeOne,
				IsStandard = true,
				Order = 1,
			},
			new()
			{
				Size = 2,
				Name = BuildingTypes.StandardSizeTwo,
				IsStandard = true,
				Order = 2,
			},
			new()
			{
				Size = 3,
				Name = BuildingTypes.StandardSizeThree,
				IsStandard = true,
				Order = 3,
			},
			new()
			{
				Size = 4,
				Name = BuildingTypes.StandardSizeFour,
				IsStandard = true,
				Order = 4,
			},
			new()
			{
				Size = 5,
				Name = BuildingTypes.StandardSizeFive,
				IsStandard = true,
				Order = 5,
			},
			new()
			{
				Size = 1,
				Name = BuildingTypes.Kiosk,
				Icon = KIOSK_ICON,
				Order = 1,
			},
			new()
			{
				Size = 1,
				Name = BuildingTypes.Pavilion,
				Icon = PAVILION_ICON,
				Order = 2,
			},
			new()
			{
				Size = 3,
				Name = BuildingTypes.PettingZoo,
				Icon = PETTING_ZOO_ICON,
				Order = 3,
			},
			new()
			{
				Size = 5,
				Name = BuildingTypes.ReptileHouse,
				Icon = REPTILE_HOUSE_ICON,
				Order = 4,
			},
			new()
			{
				Size = 5,
				Name = BuildingTypes.LargeBirdAviary,
				Icon = AVIARY_ICON,
				Order = 5,
			},
		];
	}

	public List<WorkerModel> GetWorkersDefault()
	{
		List<WorkerModel> workers =
        [
            new WorkerModel()
            {
                IsActive = true,
            },
        ];

		for (int i = 0; i < 3; i++)
		{
			workers.Add(new WorkerModel());
		}

		return workers;
	}
}
