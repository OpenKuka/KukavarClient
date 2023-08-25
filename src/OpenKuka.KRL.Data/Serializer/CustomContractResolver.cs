using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenKuka.KRL.Data.Serializer
{
    public class OrderedContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).OrderBy(p => p.PropertyName).ToList();
        }
    }

    public class PrivateSetterContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jProperty = base.CreateProperty(member, memberSerialization);
            if (!jProperty.Writable)
            {
                jProperty.Writable = member.IsPropertyWithSetter();
            }
            return jProperty;
        }
    }
    public class PrivateSetterCamelCasePropertyNamesContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jProperty = base.CreateProperty(member, memberSerialization);
            if (!jProperty.Writable)
            {
                jProperty.Writable = member.IsPropertyWithSetter();
            }
            return jProperty;
        }
    }
    internal static class MemberInfoExtensions
    {
        internal static bool IsPropertyWithSetter(this MemberInfo member)
        {
            var property = member as PropertyInfo;
            if (property != null)
            {
                return property.GetSetMethod(true) != null;
            }
            return false;
        }
    }



    //public class DataObjectConcreteClassContractResolver : DefaultContractResolver
    //{
    //    protected override JsonConverter ResolveContractConverter(Type objectType)
    //    {
    //        if (typeof(ValueObject).IsAssignableFrom(objectType) && !objectType.IsAbstract)
    //            return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
    //        return base.ResolveContractConverter(objectType);
    //    }
    //}
    //public class DataObjectConverter : JsonConverter
    //{
    //    private static JsonSerializerSettings settings = new JsonSerializerSettings() {
    //        ContractResolver = new DataObjectConcreteClassContractResolver(),
    //        TypeNameHandling = TypeNameHandling.All
    //    };

    //    public override bool CanConvert(Type objectType)
    //    {
    //        return (objectType == typeof(ValueObject));
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        JObject jo = JObject.Load(reader);
    //        switch (jo["type"].Value<int>())
    //        {
    //            case 0:
    //                return JsonConvert.DeserializeObject<BoolValue>(jo.ToString(), settings);
    //            case 1:
    //                return JsonConvert.DeserializeObject<IntValue>(jo.ToString(), settings);
    //            case 2:
    //                return JsonConvert.DeserializeObject<RealValue>(jo.ToString(), settings);
    //            case 3:
    //                return JsonConvert.DeserializeObject<CharValue>(jo.ToString(), settings);
    //            case 4:
    //                return JsonConvert.DeserializeObject<EnumValue>(jo.ToString(), settings);
    //            case 5:
    //                return JsonConvert.DeserializeObject<StringValue>(jo.ToString(), settings);
    //            case 6:
    //                return JsonConvert.DeserializeObject<BitArrayValue>(jo.ToString(), settings);
    //            case 7:
    //                return JsonConvert.DeserializeObject<StrucValue>(jo.ToString(), settings);
    //        }
    //        throw new NotImplementedException();
    //    }

    //    public override bool CanWrite
    //    {
    //        get { return false; }
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException(); // won't be called because CanWrite returns false
    //    }
    //}



    //[JsonConverter(typeof(DataObjectConverter))]



}
