namespace CoFH.XPTweaks
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
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

        public static bool Enable = true;           // quick enable or disable of the plugin

        public static bool EnableWorldAgeXP = true; // enable starting XP based on world time passed (as if user logged in on server start and logged off immediately)
        public static int StartingStars = 1;        // These are normal stars and affect XP requirements
        public static int BonusStars = 0;           // These are bonus stars are do not count as normal levels

        public static void Initialize()
        {
            UserManager.NewUserJoinedEvent.Add(user =>
            {
                if (Enable)
                {
                    SetStartingXPAndStars(user);
                }
            });

            Skillset.OnExperienceGained.Add((user, skill) =>
            {
                if (skill.GetType() == typeof(SelfImprovementSkill))
                {
                    return;
                }
                user.Skillset.AddExperience(typeof(SelfImprovementSkill), 0.01f, Localizer.DoStr("for gaining experience in another skill."));
            });

            UserManager.ManagerInitializedEvent.Add(() =>
            {
                foreach (var user in UserManager.Users)
                {
                    user.OnWorkOrderComplete.Add((order) =>
                    {
                        user.Skillset.AddExperience(typeof(SelfImprovementSkill), order.LaborPerformed * 0.0001f, Localizer.DoStr("for completing a work order with another skill."));
                    });
                }
            });
        }

        public static void PostInitialize()
        { }

        public static void SetStartingXPAndStars(User user)
        {
            while (user.UserXP.TotalStarsEarned < StartingStars - 1)
            {
                user.UserXP.AddExperience(user.UserXP.NextStarCost);
            }
            if (EnableWorldAgeXP)
            {
                user.UserXP.UpdateXP((float)WorldTime.Seconds);
            }
            user.UserXP.AddStars(BonusStars);
        }

        // public static void OnUserLogIn(User user)
        // {
        //     user.OnLogOut.Add(OnUserLogout);
        // }

        // public static void OnUserLogout(User user)
        // {

        // }
    }
}
