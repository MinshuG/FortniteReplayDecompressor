using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace FortniteReplayReader.Models.NetFieldExports {

    [NetFieldExportGroup("FallbackObject2", ParseMode.Minimal)]
    public class FallbackExport : INetFieldExportGroup {
        
        [NetFieldExport("Owner", RepLayoutCmdType.Property)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.Ignore)]
        public bool? bReplicateMovement { get; set; }
        
        [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement, ParseMode.Full)]
        public FRepMovement? ReplicatedMovement { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public int? RemoteRole { get; set; }
        
        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public uint? AttachParent { get; set; }
        
        [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
        public FVector LocationOffset { get; set; }
        
        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector100)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
        public uint? AttachComponent { get; set; }
        
        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("bIsActive", RepLayoutCmdType.PropertyBool)]
        public bool bIsActive { get; set; }
        
        [NetFieldExport("bEnabled", RepLayoutCmdType.PropertyBool)]
        public bool bEnabled { get; set; }
        
        [NetFieldExport("ReplicatedDrawScale3D", RepLayoutCmdType.Ignore)]
        public FVector ReplicatedDrawScale3D { get; set; }
        
        [NetFieldExport("TextureData", RepLayoutCmdType.PropertyObject)]
        public uint? TextureData { get; set; }
        
        [NetFieldExport("R", RepLayoutCmdType.PropertyUInt32)]
        public uint? R { get; set; }
        
        [NetFieldExport("G", RepLayoutCmdType.PropertyUInt32)]
        public uint? G { get; set; }
        
        [NetFieldExport("B", RepLayoutCmdType.PropertyUInt32)]
        public uint? B { get; set; }
        
        [NetFieldExport("A", RepLayoutCmdType.PropertyUInt32)]
        public uint? A { get; set; }
    }
}