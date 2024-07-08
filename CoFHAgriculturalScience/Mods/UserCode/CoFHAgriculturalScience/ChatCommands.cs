namespace Eco.Gameplay.Players.Food
{
    using System;
    using System.Linq;
    using System.Text;
    using Eco.Core.Tests;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Systems.Messaging.Chat.Commands;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Utils;
    using Eco.Shared;
    using Eco.Shared.Localization;
    using static Eco.Gameplay.Players.ItemTaste;

    [ChatCommandHandler]
    public static class CoFHFoodChatCommands
    {
        [ChatCommand("Do Not Use - Testing purposes only", ChatAuthorizationLevel.Admin)] public static void Cofh(User user) { }

        [ChatSubCommand("Cofh", "Randomize taste preference on a given user for an already tried food (self if untargeted user)", "randomtaste", ChatAuthorizationLevel.User)]
        public static void RandomTaste(User user, User target = null, string foodName = null)
        {
            target ??= user;
            var food = foodName != null ? CommandsUtil.ClosestMatchingItem<FoodItem>(target, foodName) : null;

            if (food != null && target.Stomach.TasteBuds.FoodToTaste.ContainsKey(food.Type))
            {
                target.Stomach.TasteBuds.FoodToTaste[food.Type] = MakeRandomNonExtremeTaste(true);
                target.Stomach.RecalcAverageNutrients();
            }
        }

        [ChatSubCommand("Cofh", "Set taste preference on a given user for an already tried food (self if untargeted user)", "settaste", ChatAuthorizationLevel.User)]
        public static void SetTaste(User user, User target = null, string foodName = null, int preference = 3)
        {
            preference = Math.Clamp(preference, 1, 5);

            target ??= user;
            var food = foodName != null ? CommandsUtil.ClosestMatchingItem<FoodItem>(target, foodName) : null;

            if (food != null && target.Stomach.TasteBuds.FoodToTaste.ContainsKey(food.Type))
            {
                target.Stomach.TasteBuds.FoodToTaste[food.Type] = new ItemTaste() { Discovered = true, Preference = (TastePreference) preference };
                target.Stomach.RecalcAverageNutrients();
            }
        }

        // [ChatSubCommand("Cofh", "Reset ALL tastes on a given user. It's as if they have never tried ANYTHING (self if untargeted user)", "resetalltastes", ChatAuthorizationLevel.User)]
        // public static void ResetAllTastes(User user, User target = null, int confirm = 0)
        // {
        //     if (confirm == 0)
        //     {
        //         return;
        //     }
        //     target ??= user;

        //     target.Stomach.ClearCalories(target.Player);
        //     target.Stomach.Contents.RemoveAll(entry => true, out var removedFood);
        //     foreach (StomachEntry entry in removedFood) Stomach.FoodContentUpdatedEvent?.Invoke(user, entry.Food.GetType());
        //     target.Stomach.RecalcAverageNutrients();
        //     target.Stomach.TasteBuds.FoodToTaste.Clear();
        // }

        [ChatSubCommand("Cofh", "List food tastes for a specified user and preference (using the called if none specified and Ok default).", "tastes", ChatAuthorizationLevel.User)]
        public static void Tastes(User user, User otherUser = null)
        {
            if (otherUser == null) otherUser = user;
            var s = new StringBuilder();

            for (int index = 1; index <= 5; ++index)
            {
                TastePreference pref = (TastePreference) index;
                int count = 0;
                s.Append(pref.ToString() + ":\n");

                foreach (var item in Item.AllItemsIncludingHidden.OfType<FoodItem>())
                {
                    if (otherUser.Stomach.TasteBuds.FoodToTaste.ContainsKey(item.Type))
                    {
                        if (otherUser.Stomach.TasteBuds.FoodToTaste[item.Type].Preference == pref)
                        {
                            s.Append($"{item.UILink()}\n");
                            ++count;
                        }
                    }
                }
                s.Append("Total " + pref.ToString() + " count: " + count.ToString() + "\n\n");
            }
            user.Msg(s.ToStringLoc());
        }
    }
}
