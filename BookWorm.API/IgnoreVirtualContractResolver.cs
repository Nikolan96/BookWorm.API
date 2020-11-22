using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using JsonProperty = Newtonsoft.Json.Serialization.JsonProperty;

namespace BookWorm.API
{
    public class IgnoreVirtualContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            var propInfo = member as PropertyInfo;
            if (propInfo != null)
            {
                if (propInfo.GetMethod.IsVirtual && !propInfo.GetMethod.IsFinal)
                {
                    prop.ShouldSerialize = obj => false;
                }
            }
            return prop;
        }
    }
}