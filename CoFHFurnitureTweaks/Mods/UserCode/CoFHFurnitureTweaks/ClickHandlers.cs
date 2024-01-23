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
            itemStack.Item = new BookshelfHiddenItem();
            return "Inventory Hidden";
        }
    }

    public partial class BookshelfHiddenItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new BookshelfItem();
            return "Inventory Visible";
        }
    }

    public partial class HardwoodLumberDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HardwoodLumberDresserHiddenItem();
            return "Inventory Hidden";
        }
    }

    public partial class HardwoodLumberDresserHiddenItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HardwoodLumberDresserItem();
            return "Inventory Visible";
        }
    }

    public partial class HewnDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HewnDresserHiddenItem();
            return "Inventory Hidden";
        }
    }

    public partial class HewnDresserHiddenItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HewnDresserItem();
            return "Inventory Visible";
        }
    }

    public partial class IceboxItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new IceboxHiddenItem();
            return "Inventory Hidden";
        }
    }

    public partial class IceboxHiddenItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new IceboxItem();
            return "Inventory Visible";
        }
    }

    public partial class LumberDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new LumberDresserHiddenItem();
            return "Inventory Hidden";
        }
    }

    public partial class LumberDresserHiddenItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new LumberDresserItem();
            return "Inventory Visible";
        }
    }

    public partial class RefrigeratorItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new RefrigeratorHiddenItem();
            return "Inventory Hidden";
        }
    }

    public partial class RefrigeratorHiddenItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new RefrigeratorItem();
            return "Inventory Visible";
        }
    }

    public partial class ShelfCabinetItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new ShelfCabinetHiddenItem();
            return "Inventory Hidden";
        }
    }

    public partial class ShelfCabinetHiddenItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new ShelfCabinetItem();
            return "Inventory Visible";
        }
    }

    public partial class SoftwoodLumberDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new SoftwoodLumberDresserHiddenItem();
            return "Inventory Hidden";
        }
    }

    public partial class SoftwoodLumberDresserHiddenItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new SoftwoodLumberDresserItem();
            return "Inventory Visible";
        }
    }
}