namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Networking;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items.Recipes;
    using static Eco.Gameplay.Players.ItemTaste;

    [Serialized] // Tells the save/load system this object needs to be serialized. 
    [LocDisplayName("Creosote Syrup")] // Defines the localized name of the item.
    [Weight(200)] // Defines how heavy the CreosoteSyrup is.
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    [LocDescription("A pungent syrup which unsettles the stomach.")] //The tooltip description for the food item.
    public partial class CreosoteSyrupItem : FoodItem
    {
        /// <summary>The amount of calories awarded for eating the food item.</summary>
        public override float Calories                  => 0;
        /// <summary>The nutritional value of the food item.</summary>
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0};
        /// <summary>Defines the default time it takes for this item to spoil. This value can be modified by the inventory this item currently resides in.</summary>
        protected override float BaseShelfLife          => (float)TimeUtil.HoursToSeconds(144);

        string ConsumeInternal(ItemStack itemStack, User user, bool reaction = false, Action onSuccess = null)
        {
            var message = string.Empty;
            if (itemStack?.Item != null && itemStack.Item.TypeID == this.TypeID) //Validate that item is not null and it is the required type
            {
                //After food item has been consumed - force clear override slot, cause food can only be eat from there
                itemStack.TryModifyStack(user, -1, () => user.Stomach.CanEat(this), () =>
                {
                    user.Stomach.Eat(this, out message, true); //Fill stomach instantly
                    if (reaction) user.Stomach.PlayFoodReaction(this);
                    onSuccess?.Invoke();
                });
            }

            return message;
        }

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            return this.ConsumeInternal(itemStack, player.User, false, () =>
            {
                var stomach = player.User.Stomach;
                // Ensure "Horrible" Taste
                stomach.TasteBuds.FoodToTaste[this.Type] = new ItemTaste() { Discovered = true, Preference = TastePreference.Horrible };

                stomach.ClearCalories(player);
                stomach.Contents.RemoveAll(entry => true, out var removedFood);
                foreach (StomachEntry entry in removedFood) Stomach.FoodContentUpdatedEvent?.Invoke(player.User, entry.Food.GetType());
                stomach.RecalcAverageNutrients();

                var mounted = player.MountManager?.IsMounted ?? false;
                if (mounted || itemStack?.Item is SeedItem) return; // No need to try play food animation while mounted (ik problems, jiggles, etc) or seeds
                player.User.Avatar.SetHeldItem(itemStack?.Item);
                player.RPC("UseItem");
            });
        }
    }

    [RequiresSkill(typeof(AgriculturalScienceSkill), 4)]
    [Ecopedia("Food", "Ingredients", subPageName: "Creosote Syrup Item")]
    public partial class CreosoteSyrupRecipe : RecipeFamily
    {
        public CreosoteSyrupRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "CreosoteSyrup",  //noloc
                displayName: Localizer.DoStr("Creosote Syrup"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CreosoteFlowerItem), 10, typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceLavishResourcesTalent)),
                    new IngredientElement(typeof(EthanolItem), 1, typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CreosoteSyrupItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(120, typeof(AgriculturalScienceSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CreosoteSyrupRecipe), start: 2, skillType: typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceFocusedSpeedTalent), typeof(AgriculturalScienceParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Creosote Syrup"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Creosote Syrup"), recipeType: typeof(CreosoteSyrupRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(LaboratoryObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
