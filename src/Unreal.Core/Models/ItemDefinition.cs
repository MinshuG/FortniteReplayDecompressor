using Unreal.Core.Contracts;

namespace Unreal.Core.Models
{
    /// <summary>
    /// Just a wrapper class for <see cref="NetworkGUID"/>
    /// </summary>
    public class ItemDefinition : NetworkGUID
    {
        public string Name { get; set; }

        public void Resolve(NetGuidCache cache)
        {
            base.Resolve(cache);
            if (IsValid())
            {
                if (GuidCache.TryGetPathName(Value, out var name))
                {
                    Name = name;
                }
            }
        }
    }
}
