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
            itemStack.Item = new BookshelfUnlinkedItem();
            return "Unlinked";
        }
    }

    public partial class BookshelfUnlinkedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new BookshelfItem();
            return "UnUnlinked";
        }
    }

    public partial class HardwoodLumberDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HardwoodLumberDresserUnlinkedItem();
            return "Unlinked";
        }
    }

    public partial class HardwoodLumberDresserUnlinkedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HardwoodLumberDresserItem();
            return "UnUnlinked";
        }
    }

    public partial class HewnDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HewnDresserUnlinkedItem();
            return "Unlinked";
        }
    }

    public partial class HewnDresserUnlinkedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new HewnDresserItem();
            return "UnUnlinked";
        }
    }

    public partial class IceboxItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new IceboxUnlinkedItem();
            return "Unlinked";
        }
    }

    public partial class IceboxUnlinkedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new IceboxItem();
            return "UnUnlinked";
        }
    }

    public partial class LumberDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new LumberDresserUnlinkedItem();
            return "Unlinked";
        }
    }

    public partial class LumberDresserUnlinkedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new LumberDresserItem();
            return "UnUnlinked";
        }
    }

    public partial class RefrigeratorItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new RefrigeratorUnlinkedItem();
            return "Unlinked";
        }
    }

    public partial class RefrigeratorUnlinkedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new RefrigeratorItem();
            return "UnUnlinked";
        }
    }

    public partial class ShelfCabinetItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new ShelfCabinetUnlinkedItem();
            return "Unlinked";
        }
    }

    public partial class ShelfCabinetUnlinkedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new ShelfCabinetItem();
            return "UnUnlinked";
        }
    }

    public partial class SoftwoodLumberDresserItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new SoftwoodLumberDresserUnlinkedItem();
            return "Unlinked";
        }
    }

    public partial class SoftwoodLumberDresserUnlinkedItem {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.Item = new SoftwoodLumberDresserItem();
            return "UnUnlinked";
        }
    }
}