using Unreal.Core.Contracts;

namespace Unreal.Core.Models;

/// <summary>
/// https://github.com/EpicGames/UnrealEngine/blob/70bc980c6361d9a7d23f6d23ffe322a2d6ef16fb/Engine/Source/Runtime/Core/Public/Misc/NetworkGuid.h#L14
/// </summary>
public class NetworkGUID : IProperty, IResolvable
{
    public uint Value { get; set; }
    public NetworkGUID? OuterGuid { get; set; }

    public string Object
    {
        get
        {
            if (GuidCache == null) return "None";

            var resultPath = null as string;

            // if (GuidCache != null && GuidCache.TryGetPathName(Value, out var pathName)) // v1
            if (GuidCache != null && GuidCache.ObjectLookup.ContainsKey(Value)) // v2
            {
                var objectName = GuidCache.ObjectLookup[Value].PathName;
                    var package = GuidCache
                        .ObjectLookup[GuidCache.ObjectLookup[Value].OuterGuid.Value].PathName;
                    if (objectName.StartsWith("Default__"))
                        objectName = objectName.Substring("Default__".Length);
                    resultPath = $"{package}.{objectName}";
            }

            if (GuidCache != null && resultPath == null && GuidCache.NetFieldExportGroupMapPathFixed.TryGetValue(Value, out var group))
            {
                resultPath = group.PathName;
            }

            if (resultPath == null && GuidCache != null && GuidCache.TryGetPathName(Value, out var pathName)) {
                resultPath = pathName;
            }

            return resultPath ?? "None";
        }
    }

    public NetGuidCache? GuidCache;

    public bool IsValid() => Value > 0;

    public bool IsDynamic() => Value > 0 && (Value & 1) != 1;

    public bool IsDefault() => Value == 1;

    public void Resolve(NetGuidCache cache) => GuidCache = cache;

    public void Serialize(NetBitReader reader) => Value = reader.ReadIntPacked();

    public override string ToString() => Object;
}
