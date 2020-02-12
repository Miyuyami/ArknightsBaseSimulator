using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace Arknights.Data
{
    public partial class ItemTable
    {
        [J("items")] public Dictionary<string, Item> Items { get; set; }
        [J("expItems")] public Dictionary<string, ExpItem> ExpItems { get; set; }
        [J("potentialItems")] public Dictionary<string, PotentialItem> PotentialItems { get; set; }
        [J("apSupplies")] public Dictionary<string, ApSupply> ApSupplies { get; set; }
    }

    public class Item
    {
        [J("itemId")] public string ItemId { get; set; }
        [J("name")] public string Name { get; set; }
        [J("description")] public string Description { get; set; }
        [J("rarity")] public int Rarity { get; set; }
        [J("iconId")] public string IconId { get; set; }
        [J("overrideBkg")] public object OverrideBkg { get; set; }
        [J("stackIconId")] public string StackIconId { get; set; }
        [J("sortId")] public long SortId { get; set; }
        [J("usage")] public string Usage { get; set; }
        [J("obtainApproach")] public string ObtainApproach { get; set; }
        [J("classifyType")] public ClassType ClassType { get; set; }
        [J("itemType")] public ItemType ItemType { get; set; }
        [J("stageDropList")] public List<StageDrop> StageDrops { get; set; }
        [J("buildingProductList")] public List<BuildingProduct> BuildingProductList { get; set; }
    }

    public class BuildingProduct
    {
        [J("roomType")] public RoomType RoomType { get; set; }
        [J("formulaId")] public string FormulaId { get; set; }
    }

    public class StageDrop
    {
        [J("stageId")] public string StageId { get; set; }
        [J("occPer")] public Occurence Occurence { get; set; }
    }

    public class ExpItem
    {
        [J("id")] public string Id { get; set; }
        [J("gainExp")] public int GainExp { get; set; }
    }

    public class PotentialItem
    {
        [J("PIONEER")] public string Pioneer { get; set; }
        [J("WARRIOR")] public string Warrior { get; set; }
        [J("SNIPER")] public string Sniper { get; set; }
        [J("TANK")] public string Tank { get; set; }
        [J("MEDIC")] public string Medic { get; set; }
        [J("SUPPORT")] public string Support { get; set; }
        [J("CASTER")] public string Caster { get; set; }
        [J("SPECIAL")] public string Special { get; set; }
    }

    public class ApSupply
    {
        [J("id")] public string Id { get; set; }
        [J("ap")] public int Ap { get; set; }
        [J("hasTs")] public bool HasTs { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ClassType
    {
        [EnumMember(Value = "NONE")] None,
        [EnumMember(Value = "NORMAL")] Normal,
        [EnumMember(Value = "MATERIAL")] Material,
        [EnumMember(Value = "CONSUME")] Consume,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemType
    {
        [EnumMember(Value = "EXP_PLAYER")] PlayerExp,
        [EnumMember(Value = "SOCIAL_PT")] SocialPoint,
        [EnumMember(Value = "AP_GAMEPLAY")] GameplayAp,
        [EnumMember(Value = "GOLD")] Gold,
        [EnumMember(Value = "DIAMOND")] Diamond,
        [EnumMember(Value = "DIAMOND_SHD")] DiamondShard,
        [EnumMember(Value = "HGG_SHD")] HggShard,
        [EnumMember(Value = "LGG_SHD")] LggShard,
        [EnumMember(Value = "MATERIAL")] Material,
        [EnumMember(Value = "CARD_EXP")] CardExp,
        [EnumMember(Value = "TKT_TRY")] TicketTry,
        [EnumMember(Value = "TKT_RECRUIT")] TicketRecruit,
        [EnumMember(Value = "TKT_INST_FIN")] TicketInstantFinish,
        [EnumMember(Value = "TKT_GACHA")] TicketGacha,
        [EnumMember(Value = "TKT_GACHA_10")] TicketGacha10,
        [EnumMember(Value = "TKT_GACHA_PRSV")] TicketGachaPreregistration, // bilibili001
        [EnumMember(Value = "AP_BASE")] BaseAp,
        [EnumMember(Value = "AP_ITEM")] ItemAp, // instantly consumed AP items
        [EnumMember(Value = "ACTIVITY_COIN")] ActivityCoin,
        [EnumMember(Value = "AP_SUPPLY")] SupplyAp, // consumable AP items
        [EnumMember(Value = "VOUCHER_PICK")] VoucherPick, // voucher_item_4pick1
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Occurence
    {
        [EnumMember(Value = "ALMOST")] Almost,
        [EnumMember(Value = "ALWAYS")] Always,
        [EnumMember(Value = "OFTEN")] Often,
        [EnumMember(Value = "SOMETIMES")] Sometimes,
        [EnumMember(Value = "USUAL")] Usual,
    }

    public partial class ItemTable
    {
        public static ItemTable FromJson(string json) => JsonConvert.DeserializeObject<ItemTable>(json, Converter.ItemSettings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this ItemTable self) => JsonConvert.SerializeObject(self, Converter.ItemSettings);
    }

    internal static partial class Converter
    {
        public static readonly JsonSerializerSettings ItemSettings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
