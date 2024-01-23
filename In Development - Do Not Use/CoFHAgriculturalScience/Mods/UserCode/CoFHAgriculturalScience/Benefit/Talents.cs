namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;

    [Serialized]
    [LocDisplayName("Focused Workflow: Agricultural Science")]
    [LocDescription("Doubles the speed of related tables when alone.")]
    public partial class AgriculturalScienceFocusedWorkflowTalentGroup : TalentGroup
    {
        public AgriculturalScienceFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(AgriculturalScienceFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(AgriculturalScienceSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class AgriculturalScienceFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(AgriculturalScienceFocusedWorkflowTalentGroup); } }
        public AgriculturalScienceFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Frugal Workspace: Agricultural Science")]
    [LocDescription("Lowers the tier requirement of related tables by 0.2.(Only applies to claimed workstations)")]
    public partial class AgriculturalScienceFrugalWorkspaceTalentGroup : TalentGroup
    {
        public AgriculturalScienceFrugalWorkspaceTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(AgriculturalScienceFrugalReqTalent),
            };
            this.OwningSkill = typeof(AgriculturalScienceSkill);
            this.Level = 6;
        }
    }

    [Serialized]
    public partial class AgriculturalScienceFrugalReqTalent : FrugalWorkspaceTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(AgriculturalScienceFrugalWorkspaceTalentGroup); } }
        public AgriculturalScienceFrugalReqTalent()
        {
            this.Value = -0.2f;
        }
    }

    [Serialized]
    [LocDisplayName("Lavish Workspace: Agricultural Science")]
    [LocDescription("Increases the tier requirement of tables by 0.2, but reduces the resources needed by 5 percent.(Only applies to claimed workstations)")]
    public partial class AgriculturalScienceLavishWorkspaceTalentGroup : TalentGroup
    {
        public AgriculturalScienceLavishWorkspaceTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(AgriculturalScienceLavishResourcesTalent),
                typeof(AgriculturalScienceLavishReqTalent),
            };
            this.OwningSkill = typeof(AgriculturalScienceSkill);
            this.Level = 6;
        }
    }

    [Serialized]
    public partial class AgriculturalScienceLavishResourcesTalent : LavishWorkspaceTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(AgriculturalScienceLavishWorkspaceTalentGroup); } }
        public AgriculturalScienceLavishResourcesTalent()
        {
            this.Value = 0.95f;
        }
    }
    [Serialized]
    public partial class AgriculturalScienceLavishReqTalent : LavishWorkspaceTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(AgriculturalScienceLavishWorkspaceTalentGroup); } }
        public AgriculturalScienceLavishReqTalent()
        {
            this.Value = 0.2f;
        }
    }

    [Serialized]
    [LocDisplayName("Parallel Processing: Agricultural Science")]
    [LocDescription("Increases the crafting speed of identical tables when they share a room by 20 percent.")]
    public partial class AgriculturalScienceParallelProcessingTalentGroup : TalentGroup
    {
        public AgriculturalScienceParallelProcessingTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(AgriculturalScienceParallelSpeedTalent),
            };
            this.OwningSkill = typeof(AgriculturalScienceSkill);
            this.Level = 3;
        }
    }
    
    [Serialized]
    public partial class AgriculturalScienceParallelSpeedTalent : ParallelProcessingTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(AgriculturalScienceParallelProcessingTalentGroup); } }
        public AgriculturalScienceParallelSpeedTalent()
        {
            this.Value = 0.8f;
        }
    }

}