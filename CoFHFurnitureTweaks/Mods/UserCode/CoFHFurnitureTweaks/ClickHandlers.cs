namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Networking;
    using Eco.Core.Controller;
    using Eco.Gameplay.Interactions.Interactors;
    using Eco.Shared.Items;
    using Eco.Shared.SharedTypes;

    public partial class BookshelfItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new BookshelfSealedItem();
            return "Sealed";
        }
    }

    public partial class BookshelfSealedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new BookshelfItem();
            return "Unsealed";
        }
    }

    public partial class HardwoodLumberDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HardwoodLumberDresserSealedItem();
            return "Sealed";
        }
    }

    public partial class HardwoodLumberDresserSealedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HardwoodLumberDresserItem();
            return "Unsealed";
        }
    }

    public partial class HewnDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HewnDresserSealedItem();
            return "Sealed";
        }
    }

    public partial class HewnDresserSealedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HewnDresserItem();
            return "Unsealed";
        }
    }

    public partial class IceboxItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new IceboxSealedItem();
            return "Sealed";
        }
    }

    public partial class IceboxSealedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new IceboxItem();
            return "Unsealed";
        }
    }

    public partial class LumberDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new LumberDresserSealedItem();
            return "Sealed";
        }
    }

    public partial class LumberDresserSealedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new LumberDresserItem();
            return "Unsealed";
        }
    }

    public partial class RefrigeratorItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new RefrigeratorSealedItem();
            return "Sealed";
        }
    }

    public partial class RefrigeratorSealedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new RefrigeratorItem();
            return "Unsealed";
        }
    }

    public partial class ShelfCabinetItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new ShelfCabinetSealedItem();
            return "Sealed";
        }
    }

    public partial class ShelfCabinetSealedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new ShelfCabinetItem();
            return "Unsealed";
        }
    }

    public partial class SoftwoodLumberDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new SoftwoodLumberDresserSealedItem();
            return "Sealed";
        }
    }

    public partial class SoftwoodLumberDresserSealedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new SoftwoodLumberDresserItem();
            return "Unsealed";
        }
    }
}