using Unreal.Core.Contracts;

namespace Unreal.Core.Models
{
    /// <summary>
    /// https://github.com/EpicGames/UnrealEngine/blob/70bc980c6361d9a7d23f6d23ffe322a2d6ef16fb/Engine/Source/Runtime/Core/Public/Misc/NetworkGuid.h#L14
    /// </summary>
    public class NetworkGUID : IProperty
    {
        public uint Value { get; set; }

        public string Object
        {
            get
            {
                // if (GuidCache != null && GuidCache.TryGetPathName(Value, out var pathName)) // v1
                if (GuidCache != null && GuidCache.ObjectLookup.ContainsKey(Value)) // v2
                // if (GuidCache.NetFieldExportGroupMapPathFixed.TryGetValue(Value, out var group))
                {
                    return GuidCache.ObjectLookup[Value].PathName; // v2
                    // return group.PathName;
                    // return pathName; // v1
                }
                return "None";    
            }
        }
        
        public NetGuidCache? GuidCache;

        public bool IsValid()
        {
            return Value > 0;
        }

        public bool IsDynamic()
        {
            return Value > 0 && (Value & 1) != 1;
        }

        public bool IsDefault()
        {
            return Value == 1;
        }

        public override string ToString()
        {
            return Object;
        }

        public void Serialize(NetBitReader reader)
        {
            Value = reader.ReadIntPacked();
        }
    }
}
