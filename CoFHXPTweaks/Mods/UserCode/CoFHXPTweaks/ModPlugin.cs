namespace CoFH.XPTweaks
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Utils;
    using Eco.Simulation;
    using Eco.Simulation.Time;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ModPlugin : IModKitPlugin, IModInit
    {
        public string GetCategory() => "Team CoFH Mods";
        public string GetStatus() => $"Loaded CoFH XP Tweaks";

        public static bool enable = true;           // quick enable or disable of the plugin

        public static bool enableWorldAgeXP = true; // enable starting XP based on world time passed (as if user logged in on server start and logged off immediately)
        public static int startingStars = 1;        // These are normal stars and affect XP requirements
        public static int bonusStars = 0;           // These are bonus stars are do not count as normal levels

        public static void Initialize()
        {
            UserManager.NewUserJoinedEvent.Add(user =>
            {
                if (enable) {
                    SetStartingXPAndStars(user);
                }
            });
        }

        public static void PostInitialize()
        { }

        public static void SetStartingXPAndStars(User user)
        {
            while (user.UserXP.TotalStarsEarned < startingStars - 1)
            {
                user.UserXP.AddExperience(user.UserXP.NextStarCost);
            }
            if (enableWorldAgeXP)
            {
                user.UserXP.UpdateXP((float)WorldTime.Seconds);
            }
            user.UserXP.AddStars(bonusStars);
        }
    }
}
