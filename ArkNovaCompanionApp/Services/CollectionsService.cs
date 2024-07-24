using ArkNovaCompanionApp.Constants;
using ArkNovaCompanionApp.Models;
using ArkNovaCompanionApp.Services.Interfaces;

namespace ArkNovaCompanionApp.Services;

public class CollectionsService : ICollectionsService
{
    public List<ActionModel> GetActions()
    {
        const string ACTION_STRENGTH = "<i class=\"bi bi-[STRENGTH]-square-fill fs-3 px-1\"></i>";
	    const string BREAK_TOKEN = "<i class=\"fa-solid fa-mug-hot fs-3 px-1\"></i>";
	    const string KIOSK = "<i class=\"fa-solid fa-store fs-3 px-1\"></i>";
	    const string PAVILION = "<i class=\"fa-solid fa-landmark-dome fs-3 px-1\"></i>";
	    const string ENCLOSURE = "<i class=\"fa-solid fa-dice-one fs-3 px-1\"></i>";
		const string PETTING_ZOO = "<i class=\"fa-solid fa-cow fs-3 px-1\"></i>";
	    const string AVIARY = "<i class=\"fa-solid fa-dove fs-3 px-1\"></i>";
	    const string REPTILE_HOUSE = "<i class=\"fa-solid fa-worm fs-3 px-1\"></i>";
		const string DIV = "<div class=\"mb-4\">";

        return new List<ActionModel>()
        {
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
                Description = $"{DIV}Build exactly <strong>one building</strong> of your choice with a maximum size of {ACTION_STRENGTH} on your zoo map</div>{DIV}Pay 2 money per space</div>{DIV}Available: Kiosk {KIOSK}, pavilion {PAVILION}, standard enclosure {ENCLOSURE}, and Petting Zoo {PETTING_ZOO}</div>",
                UpgradedDescription = $"{DIV}Build <strong>one or more different buildings</strong> with a maximum total size of {ACTION_STRENGTH} on your zoo map</div>{DIV}Pay 2 money per space</div>{DIV}Newly available: Large Bird Aviary {AVIARY} and Reptile House {REPTILE_HOUSE}</div>"
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
        };
    }
}
