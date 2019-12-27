﻿using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace FortniteReplayReader.Models.NetFieldExports
{
    [NetFieldExportGroup("/Game/Athena/SupplyDrops/Llama/AthenaSupplyDrop_Llama.AthenaSupplyDrop_Llama_C")]
    public class SupplyDropLlama : INetFieldExportGroup
    {
        [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
        public bool? bHidden { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
        public FRepMovement ReplicatedMovement { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("bDestroyed", RepLayoutCmdType.PropertyBool)]
        public bool? bDestroyed { get; set; }

        [NetFieldExport("bEditorPlaced", RepLayoutCmdType.PropertyBool)]
        public bool? bEditorPlaced { get; set; }

        [NetFieldExport("bInstantDeath", RepLayoutCmdType.PropertyBool)]
        public bool? bInstantDeath { get; set; }

        [NetFieldExport("bHasSpawnedPickups", RepLayoutCmdType.PropertyBool)]
        public bool? bHasSpawnedPickups { get; set; }

        [NetFieldExport("Looted", RepLayoutCmdType.PropertyBool)]
        public bool? Looted { get; set; }

        [NetFieldExport("FinalDestination", RepLayoutCmdType.PropertyVector)]
        public FVector FinalDestination { get; set; }
    }
}