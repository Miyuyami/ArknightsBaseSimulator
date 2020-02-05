using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Arknights.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace Arknights.BaseSimulator.Data
{
    public partial class SaveData
    {
        [J("slots")] public Dictionary<string, SlotData> Slots { get; set; }
        [J("labor")] public int Labor { get; set; }
        [J("items")] public Dictionary<int, ItemData> Items { get; set; }

        public SaveData()
        {
            this.Slots = new Dictionary<string, SlotData>();
        }
    }

    public abstract class SlotData
    {
        [J("id")] public string Id { get; set; }

        [JsonConstructor]
        protected SlotData() { }

        protected SlotData(string id)
        {
            this.Id = id;
        }
    }

    public class LockedSlotData : SlotData
    {
        [JsonConstructor]
        public LockedSlotData() : base() { }

        public LockedSlotData(string id) : base(id) { }
    }

    public class EmptySlotData : SlotData
    {
        [JsonConstructor]
        public EmptySlotData() : base() { }

        public EmptySlotData(string id) : base(id) { }
    }

    public class RoomSlotData : SlotData
    {
        [J("roomType")] public RoomType RoomType { get; set; }
        [J("level")] public int Level { get; set; }

        [JsonConstructor]
        public RoomSlotData() : base() { }

        public RoomSlotData(string id, RoomType roomType, int level) : base(id)
        {
            this.RoomType = roomType;
            this.Level = level;
        }
    }

    public class ItemData
    {
        [J("id")] public int Id { get; set; }
        [J("count")] public int Count { get; set; }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.None,
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new SlotDataConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
            },
        };
    }

    public class SlotDataConverter : JsonConverter
    {
        private static readonly Type T = typeof(SlotData);
        private static List<Type> DerivedTypes => DerivedTypesLazy.Value;
        private static readonly Lazy<List<Type>> DerivedTypesLazy = new Lazy<List<Type>>(() =>
            Assembly.GetAssembly(T)
                    .GetTypes()
                    .Where(t => t != T &&
                                T.IsAssignableFrom(t))
                    .ToList());

        public override bool CanWrite => true;
        public override bool CanRead => true;

        public override bool CanConvert(Type objectType)
        {
            return T.IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            var jo = JObject.Load(reader);
            var joType = jo["type"];
            var type = DerivedTypes.Where(t => t.Name == joType.Value<string>()).SingleOrDefault();
            if (type == null)
            {
                throw new JsonSerializationException("type property not found or malformed");
            }

            var obj = Activator.CreateInstance(type);

            using var joReader = jo.CreateReader();
            serializer.Populate(joReader, obj);
            return obj;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var o = JObject.FromObject(value);
            o.AddFirst(new JProperty("type", value.GetType().Name));
            o.WriteTo(writer);
        }
    }

    public partial class SaveData
    {
        public static SaveData FromJson(string json) => JsonConvert.DeserializeObject<SaveData>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SaveData self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
