using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using J = Newtonsoft.Json.JsonPropertyAttribute;
using N = Newtonsoft.Json.NullValueHandling;

namespace Arknights.Data
{
    public partial class BaseData
    {
        [J("controlSlotId")] public string ControlSlotId { get; set; }
        [J("meetingSlotId")] public string MeetingSlotId { get; set; }
        [J("initMaxLabor")] public long InitMaxLabor { get; set; }
        [J("laborRecoverTime")] public long LaborRecoverTime { get; set; }
        [J("manufactInputCapacity")] public long ManufactInputCapacity { get; set; }
        [J("shopCounterCapacity")] public long ShopCounterCapacity { get; set; }
        [J("comfortLimit")] public long ComfortLimit { get; set; }
        [J("creditInitiativeLimit")] public long CreditInitiativeLimit { get; set; }
        [J("creditPassiveLimit")] public long CreditPassiveLimit { get; set; }
        [J("creditComfortFactor")] public long CreditComfortFactor { get; set; }
        [J("creditGuaranteed")] public long CreditGuaranteed { get; set; }
        [J("creditCeiling")] public long CreditCeiling { get; set; }
        [J("manufactUnlockTips")] public string ManufactUnlockTips { get; set; }
        [J("shopUnlockTips")] public string ShopUnlockTips { get; set; }
        [J("manufactStationBuff")] public double ManufactStationBuff { get; set; }
        [J("comfortManpowerRecoverFactor")] public long ComfortManpowerRecoverFactor { get; set; }
        [J("manpowerDisplayFactor")] public long ManpowerDisplayFactor { get; set; }
        [J("shopOutputRatio")] public object ShopOutputRatio { get; set; }
        [J("shopStackRatio")] public object ShopStackRatio { get; set; }
        [J("basicFavorPerDay")] public long BasicFavorPerDay { get; set; }
        [J("humanResourceLimit")] public long HumanResourceLimit { get; set; }
        [J("tiredApThreshold")] public long TiredApThreshold { get; set; }
        [J("processedCountRatio")] public long ProcessedCountRatio { get; set; }
        [J("tradingStrategyUnlockLevel")] public long TradingStrategyUnlockLevel { get; set; }
        [J("tradingReduceTimeUnit")] public long TradingReduceTimeUnit { get; set; }
        [J("tradingLaborCostUnit")] public long TradingLaborCostUnit { get; set; }
        [J("manufactReduceTimeUnit")] public long ManufactReduceTimeUnit { get; set; }
        [J("manufactLaborCostUnit")] public long ManufactLaborCostUnit { get; set; }
        [J("laborAssistUnlockLevel")] public long LaborAssistUnlockLevel { get; set; }
        [J("apToLaborUnlockLevel")] public long ApToLaborUnlockLevel { get; set; }
        [J("apToLaborRatio")] public long ApToLaborRatio { get; set; }
        [J("socialResourceLimit")] public long SocialResourceLimit { get; set; }
        [J("socialSlotNum")] public long SocialSlotNum { get; set; }
        [J("furniDuplicationLimit")] public long FurniDuplicationLimit { get; set; }
        [J("manufactManpowerCostByNum")] public List<long> ManufactManpowerCostByNum { get; set; }
        [J("tradingManpowerCostByNum")] public List<long> TradingManpowerCostByNum { get; set; }
        [J("roomUnlockConds")] public Dictionary<string, RoomConditions> RoomUnlockConds { get; set; }
        [J("rooms")] public Rooms Rooms { get; set; }
        [J("layouts")] public Layouts Layouts { get; set; }
        [J("prefabs")] public Dictionary<string, Prefab> Prefabs { get; set; }
        [J("controlData")] public ControlData ControlData { get; set; }
        [J("manufactData")] public ManufactData ManufactData { get; set; }
        [J("shopData")] public DormDataClass ShopData { get; set; }
        [J("hireData")] public HireDataClass HireData { get; set; }
        [J("dormData")] public DormDataClass DormData { get; set; }
        [J("meetingData")] public MeetingData MeetingData { get; set; }
        [J("tradingData")] public HireDataClass TradingData { get; set; }
        [J("workshopData")] public DormDataClass WorkshopData { get; set; }
        [J("trainingData")] public HireDataClass TrainingData { get; set; }
        [J("powerData")] public HireDataClass PowerData { get; set; }
        [J("chars")] public Dictionary<string, Char> Chars { get; set; }
        [J("buffs")] public Dictionary<string, Buff> Buffs { get; set; }
        [J("customData")] public CustomData CustomData { get; set; }
        [J("manufactFormulas")] public Dictionary<string, ManufactFormula> ManufactFormulas { get; set; }
        [J("shopFormulas")] public ShopFormulas ShopFormulas { get; set; }
        [J("workshopFormulas")] public Dictionary<string, WorkshopFormula> WorkshopFormulas { get; set; }
        [J("creditFormula")] public CreditFormula CreditFormula { get; set; }
        [J("goldItems")] public Dictionary<string, long> GoldItems { get; set; }
        [J("assistantUnlock")] public List<long> AssistantUnlock { get; set; }
    }

    public partial class Buff
    {
        [J("buffId")] public string BuffId { get; set; }
        [J("buffName")] public string BuffName { get; set; }
        [J("buffIcon")] public BuffIcon BuffIcon { get; set; }
        [J("skillIcon")] public string SkillIcon { get; set; }
        [J("buffColor")] public BuffColor BuffColor { get; set; }
        [J("textColor")] public TextColor TextColor { get; set; }
        [J("buffCategory")] public BuffCategory BuffCategory { get; set; }
        [J("roomType")] public RoomType RoomType { get; set; }
        [J("description")] public string Description { get; set; }
    }

    public partial class Char
    {
        [J("charId")] public string CharId { get; set; }
        [J("maxManpower")] public long MaxManpower { get; set; }
        [J("buffChar")] public List<BuffChar> BuffChar { get; set; }
    }

    public partial class BuffChar
    {
        [J("buffData")] public List<BuffDatum> BuffData { get; set; }
    }

    public partial class BuffDatum
    {
        [J("buffId")] public string BuffId { get; set; }
        [J("cond")] public Cond Cond { get; set; }
    }

    public partial class Cond
    {
        [J("phase")] public long Phase { get; set; }
        [J("level")] public long Level { get; set; }
    }

    public partial class ControlData
    {
        [J("basicCostBuff")] public long BasicCostBuff { get; set; }
        [J("phases")] public object Phases { get; set; }
    }

    public partial class CreditFormula
    {
        [J("initiative")] public ShopFormulas Initiative { get; set; }
        [J("passive")] public ShopFormulas Passive { get; set; }
    }

    public partial class ShopFormulas
    {
    }

    public partial class CustomData
    {
        [J("furnitures")] public Dictionary<string, Furniture> Furnitures { get; set; }
        [J("themes")] public Dictionary<string, Theme> Themes { get; set; }
        [J("groups")] public Dictionary<string, Group> Groups { get; set; }
        [J("types")] public Dictionary<string, TypeValue> Types { get; set; }
        [J("defaultFurnitures")] public DefaultFurnitures DefaultFurnitures { get; set; }
    }

    public partial class DefaultFurnitures
    {
        [J("room_dormitory_6x2")] public List<RoomDormitory6X2> RoomDormitory6X2 { get; set; }
    }

    public partial class RoomDormitory6X2
    {
        [J("furnitureId")] public string FurnitureId { get; set; }
        [J("xOffset")] public long XOffset { get; set; }
        [J("yOffset")] public long YOffset { get; set; }
        [J("defaultPrefabId")] public DefaultPrefabId DefaultPrefabId { get; set; }
    }

    public partial class Furniture
    {
        [J("id")] public string Id { get; set; }
        [J("name")] public string Name { get; set; }
        [J("iconId")] public string IconId { get; set; }
        [J("type")] public FurnitureType Type { get; set; }
        [J("location")] public Location Location { get; set; }
        [J("category")] public FurnitureCategory Category { get; set; }
        [J("rarity")] public long Rarity { get; set; }
        [J("themeId")] public string ThemeId { get; set; }
        [J("width")] public long Width { get; set; }
        [J("depth")] public long Depth { get; set; }
        [J("height")] public long Height { get; set; }
        [J("comfort")] public long Comfort { get; set; }
        [J("usage")] public Usage Usage { get; set; }
        [J("description")] public string Description { get; set; }
        [J("obtainApproach")] public string ObtainApproach { get; set; }
        [J("processedProductId")] [JsonConverter(typeof(ParseStringConverter))] public long ProcessedProductId { get; set; }
        [J("processedProductCount")] public long ProcessedProductCount { get; set; }
        [J("processedByProductPercentage")] public long ProcessedByProductPercentage { get; set; }
        [J("processedByProductGroup")] public List<object> ProcessedByProductGroup { get; set; }
        [J("canBeDestroy")] public bool CanBeDestroy { get; set; }
    }

    public partial class Group
    {
        [J("id")] public string Id { get; set; }
        [J("name")] public string Name { get; set; }
        [J("themeId")] public string ThemeId { get; set; }
        [J("comfort")] public long Comfort { get; set; }
        [J("count")] public long Count { get; set; }
        [J("furniture")] public List<string> Furniture { get; set; }
    }

    public partial class Theme
    {
        [J("id")] public string Id { get; set; }
        [J("name")] public string Name { get; set; }
        [J("desc")] public string Desc { get; set; }
        [J("quickSetup")] public List<QuickSetup> QuickSetup { get; set; }
    }

    public partial class QuickSetup
    {
        [J("furnitureId")] public string FurnitureId { get; set; }
        [J("pos0")] public long Pos0 { get; set; }
        [J("pos1")] public long Pos1 { get; set; }
    }

    public partial class TypeValue
    {
        [J("type")] public FurnitureType Type { get; set; }
        [J("name")] public string Name { get; set; }
    }

    public partial class DormDataClass
    {
        [J("phases")] public List<DormDataPhase> Phases { get; set; }
    }

    public partial class DormDataPhase
    {
        [J("manpowerRecover", NullValueHandling = N.Ignore)] public long? ManpowerRecover { get; set; }
        [J("decorationLimit", NullValueHandling = N.Ignore)] public long? DecorationLimit { get; set; }
        [J("manpowerFactor", NullValueHandling = N.Ignore)] public double? ManpowerFactor { get; set; }
    }

    public partial class HireDataClass
    {
        [J("basicSpeedBuff")] public double BasicSpeedBuff { get; set; }
        [J("phases")] public List<HireDataPhase> Phases { get; set; }
    }

    public partial class HireDataPhase
    {
        [J("economizeRate", NullValueHandling = N.Ignore)] public double? EconomizeRate { get; set; }
        [J("resSpeed", NullValueHandling = N.Ignore)] public long? ResSpeed { get; set; }
        [J("refreshTimes", NullValueHandling = N.Ignore)] public long? RefreshTimes { get; set; }
        [J("orderSpeed", NullValueHandling = N.Ignore)] public long? OrderSpeed { get; set; }
        [J("orderLimit", NullValueHandling = N.Ignore)] public long? OrderLimit { get; set; }
        [J("orderRarity", NullValueHandling = N.Ignore)] public long? OrderRarity { get; set; }
        [J("specSkillLvlLimit", NullValueHandling = N.Ignore)] public long? SpecSkillLvlLimit { get; set; }
    }

    public partial class Layouts
    {
        [J("v0")] public V0 V0 { get; set; }
    }

    public partial class V0
    {
        [J("id")] public string Id { get; set; }
        [J("slots")] public Dictionary<string, Slot> Slots { get; set; }
        [J("cleanCosts")] public Dictionary<string, CleanCostType> CleanCostTypes { get; set; }
        [J("storeys")] public Dictionary<string, Storey> Storeys { get; set; }
    }

    public partial class CleanCostType
    {
        [J("id")] public string Id { get; set; }
        [J("number")] public Dictionary<string, CleanCost> CleanCostByNumber { get; set; }
    }

    public partial class CleanCost
    {
        [J("items")] public List<Cost> Items { get; set; }
    }

    public partial class Cost
    {
        [J("id")] [JsonConverter(typeof(ParseStringConverter))] public long Id { get; set; }
        [J("count")] public long Count { get; set; }
        [J("type")] public CostType Type { get; set; }
    }

    public partial class Slot
    {
        [J("id")] public string Id { get; set; }
        [J("cleanCostId")] public string CleanCostId { get; set; }
        [J("costLabor")] public long CostLabor { get; set; }
        [J("provideLabor")] public long ProvideLabor { get; set; }
        [J("size")] public Position Size { get; set; }
        [J("offset")] public Position Offset { get; set; }
        [J("category")] public PurpleCategory Category { get; set; }
        [J("storeyId")] public StoreyId StoreyId { get; set; }
    }

    public partial class Position
    {
        [J("row")] public long Row { get; set; }
        [J("col")] public long Col { get; set; }
    }

    public partial class Storey
    {
        [J("id")] public StoreyId Id { get; set; }
        [J("yOffset")] public long YOffset { get; set; }
        [J("unlockControlLevel")] public long UnlockControlLevel { get; set; }
        [J("type")] public StoreyType Type { get; set; }
    }

    public partial class ManufactData
    {
        [J("basicSpeedBuff")] public double BasicSpeedBuff { get; set; }
        [J("phases")] public List<ManufactDataPhase> Phases { get; set; }
    }

    public partial class ManufactDataPhase
    {
        [J("speed")] public long Speed { get; set; }
        [J("outputCapacity")] public long OutputCapacity { get; set; }
    }

    public partial class ManufactFormula
    {
        [J("formulaId")] [JsonConverter(typeof(ParseStringConverter))] public long FormulaId { get; set; }
        [J("itemId")] [JsonConverter(typeof(ParseStringConverter))] public long ItemId { get; set; }
        [J("count")] public long Count { get; set; }
        [J("weight")] public long Weight { get; set; }
        [J("costPoint")] public long CostPoint { get; set; }
        [J("formulaType")] public string FormulaType { get; set; }
        [J("buffType")] public string BuffType { get; set; }
        [J("costs")] public List<Cost> Costs { get; set; }
        [J("requireRooms")] public List<RequireRoom> RequireRooms { get; set; }
        [J("requireStages")] public List<object> RequireStages { get; set; }
    }

    public partial class RequireRoom
    {
        [J("roomId")] public RoomType RoomId { get; set; }
        [J("roomLevel")] public long RoomLevel { get; set; }
        [J("roomCount")] public long RoomCount { get; set; }
    }

    public partial class MeetingData
    {
        [J("basicSpeedBuff")] public double BasicSpeedBuff { get; set; }
        [J("phases")] public List<MeetingDataPhase> Phases { get; set; }
    }

    public partial class MeetingDataPhase
    {
        [J("friendSlotInc")] public long FriendSlotInc { get; set; }
        [J("maxVisitorNum")] public long MaxVisitorNum { get; set; }
        [J("gatheringSpeed")] public long GatheringSpeed { get; set; }
    }

    public partial class Prefab
    {
        [J("id")] public string Id { get; set; }
        [J("blueprintRoomOverrideId")] public object BlueprintRoomOverrideId { get; set; }
        [J("size")] public Position Size { get; set; }
        [J("floorGridSize")] public Position FloorGridSize { get; set; }
        [J("backWallGridSize")] public Position BackWallGridSize { get; set; }
        [J("obstacleId")] public object ObstacleId { get; set; }
    }

    public class RoomConditions
    {
        [J("id")] public string Id { get; set; }
        [J("number")] public Dictionary<string, RoomCondition> Number { get; set; }
    }

    public partial class RoomCondition
    {
        [J("type")] public RoomType Type { get; set; }
        [J("level")] public long Level { get; set; }
        [J("count")] public long Count { get; set; }
    }

    public partial class Rooms
    {
        [J("CONTROL")] public Control Control { get; set; }
        [J("POWER")] public Control Power { get; set; }
        [J("MANUFACTURE")] public Control Manufacture { get; set; }
        [J("TRADING")] public Control Trading { get; set; }
        [J("DORMITORY")] public Control Dormitory { get; set; }
        [J("WORKSHOP")] public Control Workshop { get; set; }
        [J("HIRE")] public Control Hire { get; set; }
        [J("TRAINING")] public Control Training { get; set; }
        [J("MEETING")] public Control Meeting { get; set; }
        [J("ELEVATOR")] public Control Elevator { get; set; }
        [J("CORRIDOR")] public Control Corridor { get; set; }
    }

    public partial class Control
    {
        [J("id")] public RoomType Id { get; set; }
        [J("name")] public string Name { get; set; }
        [J("description")] public string Description { get; set; }
        [J("defaultPrefabId")] public string DefaultPrefabId { get; set; }
        [J("canLevelDown")] public bool CanLevelDown { get; set; }
        [J("maxCount")] public long MaxCount { get; set; }
        [J("category")] public PurpleCategory Category { get; set; }
        [J("size")] public Position Size { get; set; }
        [J("phases")] public List<PurplePhase> Phases { get; set; }
    }

    public partial class PurplePhase
    {
        [J("overrideName")] public object OverrideName { get; set; }
        [J("overridePrefabId")] public object OverridePrefabId { get; set; }
        [J("unlockCondId")] public string UnlockCondId { get; set; }
        [J("buildCost")] public BuildCost BuildCost { get; set; }
        [J("electricity")] public long Electricity { get; set; }
        [J("maxStationedNum")] public long MaxStationedNum { get; set; }
        [J("manpowerCost")] public long ManpowerCost { get; set; }
    }

    public partial class BuildCost
    {
        [J("items")] public List<Cost> Items { get; set; }
        [J("time")] public long Time { get; set; }
        [J("labor")] public long Labor { get; set; }
    }

    public partial class WorkshopFormula
    {
        [J("formulaId")] [JsonConverter(typeof(ParseStringConverter))] public long FormulaId { get; set; }
        [J("rarity")] public long Rarity { get; set; }
        [J("itemId")] [JsonConverter(typeof(ParseStringConverter))] public long ItemId { get; set; }
        [J("count")] public long Count { get; set; }
        [J("goldCost")] public long GoldCost { get; set; }
        [J("apCost")] public long ApCost { get; set; }
        [J("formulaType")] public FormulaType FormulaType { get; set; }
        [J("buffType")] public BuffType BuffType { get; set; }
        [J("extraOutcomeRate")] public double ExtraOutcomeRate { get; set; }
        [J("extraOutcomeGroup")] public List<ExtraOutcomeGroup> ExtraOutcomeGroup { get; set; }
        [J("costs")] public List<Cost> Costs { get; set; }
        [J("requireRooms")] public List<RequireRoom> RequireRooms { get; set; }
        [J("requireStages")] public List<RequireStage> RequireStages { get; set; }
    }

    public partial class ExtraOutcomeGroup
    {
        [J("weight")] public long Weight { get; set; }
        [J("itemId")] [JsonConverter(typeof(ParseStringConverter))] public long ItemId { get; set; }
        [J("itemCount")] public long ItemCount { get; set; }
    }

    public partial class RequireStage
    {
        [J("stageId")] public string StageId { get; set; }
        [J("rank")] public long Rank { get; set; }
    }

    public enum BuffCategory { Function, Output, Recovery };

    public enum BuffColor { HexDD653F, HexE3EB00, HexFFD800, Hex005752, Hex0075A9, Hex21CDCB, Hex565656, Hex7D0022, Hex8FC31F };

    public enum BuffIcon { Control, Dormitory, Hire, Manufacture, Meeting, Power, Trading, Training, Workshop };

    public enum RoomType { Control, Corridor, Dormitory, Elevator, Functional, Hire, Manufacture, Meeting, None, Power, Trading, Training, Workshop };

    public enum TextColor { HexFFFFFF, Hex333333 };

    public enum DefaultPrefabId { RoomDormitory6X2 };

    public enum FurnitureCategory { Floor, Furniture, Wall };

    public enum Location { Carpet, Ceiling, Floor, None, Poster, Wall };

    public enum FurnitureType { Bedding, Cabinet, Carpet, Ceiling, Ceilinglamp, Decoration, Floor, Seating, Table, Walldeco, Walllamp, Wallpaper };

    public enum Usage { CanBeUsedToDecorateTheDormAndImproveTheAmbience };

    public enum CostType { Gold, Material };

    public enum PurpleCategory { Corridor, Custom, Elevator, Function, Output, Special };

    public enum StoreyId { B1, B2, B3, B4, Empty, The1F };

    public enum BuffType { WAsc, WBuilding, WEvolve, WSkill };

    public enum FormulaType { FAsc, FBuilding, FEvolve, FSkill };

    public enum StoreyType { UPGROUND, DOWNGROUND };

    public partial class BaseData
    {
        public static BaseData FromJson(string json) => JsonConvert.DeserializeObject<BaseData>(json, Arknights.Data.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this BaseData self) => JsonConvert.SerializeObject(self, Arknights.Data.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                BuffCategoryConverter.Singleton,
                BuffColorConverter.Singleton,
                BuffIconConverter.Singleton,
                RoomTypeConverter.Singleton,
                TextColorConverter.Singleton,
                DefaultPrefabIdConverter.Singleton,
                FurnitureCategoryConverter.Singleton,
                LocationConverter.Singleton,
                FurnitureTypeConverter.Singleton,
                UsageConverter.Singleton,
                CostTypeConverter.Singleton,
                PurpleCategoryConverter.Singleton,
                StoreyIdConverter.Singleton,
                BuffTypeConverter.Singleton,
                FormulaTypeConverter.Singleton,
                StoreyTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class BuffCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BuffCategory) || t == typeof(BuffCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "FUNCTION" => BuffCategory.Function,
                "OUTPUT" => BuffCategory.Output,
                "RECOVERY" => BuffCategory.Recovery,
                _ => throw new Exception("Cannot unmarshal type BuffCategory"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BuffCategory)untypedValue;
            switch (value)
            {
                case BuffCategory.Function:
                    serializer.Serialize(writer, "FUNCTION");
                    return;
                case BuffCategory.Output:
                    serializer.Serialize(writer, "OUTPUT");
                    return;
                case BuffCategory.Recovery:
                    serializer.Serialize(writer, "RECOVERY");
                    return;
            }
            throw new Exception("Cannot marshal type BuffCategory");
        }

        public static readonly BuffCategoryConverter Singleton = new BuffCategoryConverter();
    }

    internal class BuffColorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BuffColor) || t == typeof(BuffColor?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "#005752" => BuffColor.Hex005752,
                "#0075a9" => BuffColor.Hex0075A9,
                "#21cdcb" => BuffColor.Hex21CDCB,
                "#565656" => BuffColor.Hex565656,
                "#7d0022" => BuffColor.Hex7D0022,
                "#8fc31f" => BuffColor.Hex8FC31F,
                "#dd653f" => BuffColor.HexDD653F,
                "#e3eb00" => BuffColor.HexE3EB00,
                "#ffd800" => BuffColor.HexFFD800,
                _ => throw new Exception("Cannot unmarshal type BuffColor"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BuffColor)untypedValue;
            switch (value)
            {
                case BuffColor.Hex005752:
                    serializer.Serialize(writer, "#005752");
                    return;
                case BuffColor.Hex0075A9:
                    serializer.Serialize(writer, "#0075a9");
                    return;
                case BuffColor.Hex21CDCB:
                    serializer.Serialize(writer, "#21cdcb");
                    return;
                case BuffColor.Hex565656:
                    serializer.Serialize(writer, "#565656");
                    return;
                case BuffColor.Hex7D0022:
                    serializer.Serialize(writer, "#7d0022");
                    return;
                case BuffColor.Hex8FC31F:
                    serializer.Serialize(writer, "#8fc31f");
                    return;
                case BuffColor.HexDD653F:
                    serializer.Serialize(writer, "#dd653f");
                    return;
                case BuffColor.HexE3EB00:
                    serializer.Serialize(writer, "#e3eb00");
                    return;
                case BuffColor.HexFFD800:
                    serializer.Serialize(writer, "#ffd800");
                    return;
            }
            throw new Exception("Cannot marshal type BuffColor");
        }

        public static readonly BuffColorConverter Singleton = new BuffColorConverter();
    }

    internal class BuffIconConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BuffIcon) || t == typeof(BuffIcon?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "control" => BuffIcon.Control,
                "dormitory" => BuffIcon.Dormitory,
                "hire" => BuffIcon.Hire,
                "manufacture" => BuffIcon.Manufacture,
                "meeting" => BuffIcon.Meeting,
                "power" => BuffIcon.Power,
                "trading" => BuffIcon.Trading,
                "training" => BuffIcon.Training,
                "workshop" => BuffIcon.Workshop,
                _ => throw new Exception("Cannot unmarshal type BuffIcon"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BuffIcon)untypedValue;
            switch (value)
            {
                case BuffIcon.Control:
                    serializer.Serialize(writer, "control");
                    return;
                case BuffIcon.Dormitory:
                    serializer.Serialize(writer, "dormitory");
                    return;
                case BuffIcon.Hire:
                    serializer.Serialize(writer, "hire");
                    return;
                case BuffIcon.Manufacture:
                    serializer.Serialize(writer, "manufacture");
                    return;
                case BuffIcon.Meeting:
                    serializer.Serialize(writer, "meeting");
                    return;
                case BuffIcon.Power:
                    serializer.Serialize(writer, "power");
                    return;
                case BuffIcon.Trading:
                    serializer.Serialize(writer, "trading");
                    return;
                case BuffIcon.Training:
                    serializer.Serialize(writer, "training");
                    return;
                case BuffIcon.Workshop:
                    serializer.Serialize(writer, "workshop");
                    return;
            }
            throw new Exception("Cannot marshal type BuffIcon");
        }

        public static readonly BuffIconConverter Singleton = new BuffIconConverter();
    }

    internal class RoomTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RoomType) || t == typeof(RoomType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "CONTROL" => RoomType.Control,
                "CORRIDOR" => RoomType.Corridor,
                "DORMITORY" => RoomType.Dormitory,
                "ELEVATOR" => RoomType.Elevator,
                "FUNCTIONAL" => RoomType.Functional,
                "HIRE" => RoomType.Hire,
                "MANUFACTURE" => RoomType.Manufacture,
                "MEETING" => RoomType.Meeting,
                "NONE" => RoomType.None,
                "POWER" => RoomType.Power,
                "TRADING" => RoomType.Trading,
                "TRAINING" => RoomType.Training,
                "WORKSHOP" => RoomType.Workshop,
                _ => throw new Exception("Cannot unmarshal type RoomType"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RoomType)untypedValue;
            switch (value)
            {
                case RoomType.Control:
                    serializer.Serialize(writer, "CONTROL");
                    return;
                case RoomType.Corridor:
                    serializer.Serialize(writer, "CORRIDOR");
                    return;
                case RoomType.Dormitory:
                    serializer.Serialize(writer, "DORMITORY");
                    return;
                case RoomType.Elevator:
                    serializer.Serialize(writer, "ELEVATOR");
                    return;
                case RoomType.Functional:
                    serializer.Serialize(writer, "FUNCTIONAL");
                    return;
                case RoomType.Hire:
                    serializer.Serialize(writer, "HIRE");
                    return;
                case RoomType.Manufacture:
                    serializer.Serialize(writer, "MANUFACTURE");
                    return;
                case RoomType.Meeting:
                    serializer.Serialize(writer, "MEETING");
                    return;
                case RoomType.None:
                    serializer.Serialize(writer, "NONE");
                    return;
                case RoomType.Power:
                    serializer.Serialize(writer, "POWER");
                    return;
                case RoomType.Trading:
                    serializer.Serialize(writer, "TRADING");
                    return;
                case RoomType.Training:
                    serializer.Serialize(writer, "TRAINING");
                    return;
                case RoomType.Workshop:
                    serializer.Serialize(writer, "WORKSHOP");
                    return;
            }
            throw new Exception("Cannot marshal type RoomType");
        }

        public static readonly RoomTypeConverter Singleton = new RoomTypeConverter();
    }

    internal class TextColorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TextColor) || t == typeof(TextColor?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "#333333" => TextColor.Hex333333,
                "#ffffff" => TextColor.HexFFFFFF,
                _ => throw new Exception("Cannot unmarshal type TextColor"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TextColor)untypedValue;
            switch (value)
            {
                case TextColor.Hex333333:
                    serializer.Serialize(writer, "#333333");
                    return;
                case TextColor.HexFFFFFF:
                    serializer.Serialize(writer, "#ffffff");
                    return;
            }
            throw new Exception("Cannot marshal type TextColor");
        }

        public static readonly TextColorConverter Singleton = new TextColorConverter();
    }

    internal class DefaultPrefabIdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DefaultPrefabId) || t == typeof(DefaultPrefabId?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "room_dormitory_6x2")
            {
                return DefaultPrefabId.RoomDormitory6X2;
            }
            throw new Exception("Cannot unmarshal type DefaultPrefabId");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DefaultPrefabId)untypedValue;
            if (value == DefaultPrefabId.RoomDormitory6X2)
            {
                serializer.Serialize(writer, "room_dormitory_6x2");
                return;
            }
            throw new Exception("Cannot marshal type DefaultPrefabId");
        }

        public static readonly DefaultPrefabIdConverter Singleton = new DefaultPrefabIdConverter();
    }

    internal class FurnitureCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FurnitureCategory) || t == typeof(FurnitureCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "FLOOR" => FurnitureCategory.Floor,
                "FURNITURE" => FurnitureCategory.Furniture,
                "WALL" => FurnitureCategory.Wall,
                _ => throw new Exception("Cannot unmarshal type FurnitureCategory"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FurnitureCategory)untypedValue;
            switch (value)
            {
                case FurnitureCategory.Floor:
                    serializer.Serialize(writer, "FLOOR");
                    return;
                case FurnitureCategory.Furniture:
                    serializer.Serialize(writer, "FURNITURE");
                    return;
                case FurnitureCategory.Wall:
                    serializer.Serialize(writer, "WALL");
                    return;
            }
            throw new Exception("Cannot marshal type FurnitureCategory");
        }

        public static readonly FurnitureCategoryConverter Singleton = new FurnitureCategoryConverter();
    }

    internal class LocationConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Location) || t == typeof(Location?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "CARPET" => Location.Carpet,
                "CEILING" => Location.Ceiling,
                "FLOOR" => Location.Floor,
                "NONE" => Location.None,
                "POSTER" => Location.Poster,
                "WALL" => Location.Wall,
                _ => throw new Exception("Cannot unmarshal type Location"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Location)untypedValue;
            switch (value)
            {
                case Location.Carpet:
                    serializer.Serialize(writer, "CARPET");
                    return;
                case Location.Ceiling:
                    serializer.Serialize(writer, "CEILING");
                    return;
                case Location.Floor:
                    serializer.Serialize(writer, "FLOOR");
                    return;
                case Location.None:
                    serializer.Serialize(writer, "NONE");
                    return;
                case Location.Poster:
                    serializer.Serialize(writer, "POSTER");
                    return;
                case Location.Wall:
                    serializer.Serialize(writer, "WALL");
                    return;
            }
            throw new Exception("Cannot marshal type Location");
        }

        public static readonly LocationConverter Singleton = new LocationConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            if (Int64.TryParse(value, out long l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class FurnitureTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FurnitureType) || t == typeof(FurnitureType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "BEDDING" => FurnitureType.Bedding,
                "CABINET" => FurnitureType.Cabinet,
                "CARPET" => FurnitureType.Carpet,
                "CEILING" => FurnitureType.Ceiling,
                "CEILINGLAMP" => FurnitureType.Ceilinglamp,
                "DECORATION" => FurnitureType.Decoration,
                "FLOOR" => FurnitureType.Floor,
                "SEATING" => FurnitureType.Seating,
                "TABLE" => FurnitureType.Table,
                "WALLDECO" => FurnitureType.Walldeco,
                "WALLLAMP" => FurnitureType.Walllamp,
                "WALLPAPER" => FurnitureType.Wallpaper,
                _ => throw new Exception("Cannot unmarshal type FurnitureType"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FurnitureType)untypedValue;
            switch (value)
            {
                case FurnitureType.Bedding:
                    serializer.Serialize(writer, "BEDDING");
                    return;
                case FurnitureType.Cabinet:
                    serializer.Serialize(writer, "CABINET");
                    return;
                case FurnitureType.Carpet:
                    serializer.Serialize(writer, "CARPET");
                    return;
                case FurnitureType.Ceiling:
                    serializer.Serialize(writer, "CEILING");
                    return;
                case FurnitureType.Ceilinglamp:
                    serializer.Serialize(writer, "CEILINGLAMP");
                    return;
                case FurnitureType.Decoration:
                    serializer.Serialize(writer, "DECORATION");
                    return;
                case FurnitureType.Floor:
                    serializer.Serialize(writer, "FLOOR");
                    return;
                case FurnitureType.Seating:
                    serializer.Serialize(writer, "SEATING");
                    return;
                case FurnitureType.Table:
                    serializer.Serialize(writer, "TABLE");
                    return;
                case FurnitureType.Walldeco:
                    serializer.Serialize(writer, "WALLDECO");
                    return;
                case FurnitureType.Walllamp:
                    serializer.Serialize(writer, "WALLLAMP");
                    return;
                case FurnitureType.Wallpaper:
                    serializer.Serialize(writer, "WALLPAPER");
                    return;
            }
            throw new Exception("Cannot marshal type FurnitureType");
        }

        public static readonly FurnitureTypeConverter Singleton = new FurnitureTypeConverter();
    }

    internal class UsageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Usage) || t == typeof(Usage?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Can be used to decorate the dorm and improve the ambience.")
            {
                return Usage.CanBeUsedToDecorateTheDormAndImproveTheAmbience;
            }
            throw new Exception("Cannot unmarshal type Usage");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Usage)untypedValue;
            if (value == Usage.CanBeUsedToDecorateTheDormAndImproveTheAmbience)
            {
                serializer.Serialize(writer, "Can be used to decorate the dorm and improve the ambience.");
                return;
            }
            throw new Exception("Cannot marshal type Usage");
        }

        public static readonly UsageConverter Singleton = new UsageConverter();
    }

    internal class CostTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CostType) || t == typeof(CostType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "GOLD" => CostType.Gold,
                "MATERIAL" => CostType.Material,
                _ => throw new Exception("Cannot unmarshal type CostType"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CostType)untypedValue;
            switch (value)
            {
                case CostType.Gold:
                    serializer.Serialize(writer, "GOLD");
                    return;
                case CostType.Material:
                    serializer.Serialize(writer, "MATERIAL");
                    return;
            }
            throw new Exception("Cannot marshal type CostType");
        }

        public static readonly CostTypeConverter Singleton = new CostTypeConverter();
    }

    internal class PurpleCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PurpleCategory) || t == typeof(PurpleCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "CORRIDOR" => PurpleCategory.Corridor,
                "CUSTOM" => PurpleCategory.Custom,
                "ELEVATOR" => PurpleCategory.Elevator,
                "FUNCTION" => PurpleCategory.Function,
                "OUTPUT" => PurpleCategory.Output,
                "SPECIAL" => PurpleCategory.Special,
                _ => throw new Exception("Cannot unmarshal type PurpleCategory"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PurpleCategory)untypedValue;
            switch (value)
            {
                case PurpleCategory.Corridor:
                    serializer.Serialize(writer, "CORRIDOR");
                    return;
                case PurpleCategory.Custom:
                    serializer.Serialize(writer, "CUSTOM");
                    return;
                case PurpleCategory.Elevator:
                    serializer.Serialize(writer, "ELEVATOR");
                    return;
                case PurpleCategory.Function:
                    serializer.Serialize(writer, "FUNCTION");
                    return;
                case PurpleCategory.Output:
                    serializer.Serialize(writer, "OUTPUT");
                    return;
                case PurpleCategory.Special:
                    serializer.Serialize(writer, "SPECIAL");
                    return;
            }
            throw new Exception("Cannot marshal type PurpleCategory");
        }

        public static readonly PurpleCategoryConverter Singleton = new PurpleCategoryConverter();
    }

    internal class StoreyIdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StoreyId) || t == typeof(StoreyId?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "" => StoreyId.Empty,
                "1F" => StoreyId.The1F,
                "B1" => StoreyId.B1,
                "B2" => StoreyId.B2,
                "B3" => StoreyId.B3,
                "B4" => StoreyId.B4,
                _ => throw new Exception("Cannot unmarshal type StoreyId"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StoreyId)untypedValue;
            switch (value)
            {
                case StoreyId.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case StoreyId.The1F:
                    serializer.Serialize(writer, "1F");
                    return;
                case StoreyId.B1:
                    serializer.Serialize(writer, "B1");
                    return;
                case StoreyId.B2:
                    serializer.Serialize(writer, "B2");
                    return;
                case StoreyId.B3:
                    serializer.Serialize(writer, "B3");
                    return;
                case StoreyId.B4:
                    serializer.Serialize(writer, "B4");
                    return;
            }
            throw new Exception("Cannot marshal type StoreyId");
        }

        public static readonly StoreyIdConverter Singleton = new StoreyIdConverter();
    }

    internal class BuffTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BuffType) || t == typeof(BuffType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "W_ASC" => BuffType.WAsc,
                "W_BUILDING" => BuffType.WBuilding,
                "W_EVOLVE" => BuffType.WEvolve,
                "W_SKILL" => BuffType.WSkill,
                _ => throw new Exception("Cannot unmarshal type BuffType"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BuffType)untypedValue;
            switch (value)
            {
                case BuffType.WAsc:
                    serializer.Serialize(writer, "W_ASC");
                    return;
                case BuffType.WBuilding:
                    serializer.Serialize(writer, "W_BUILDING");
                    return;
                case BuffType.WEvolve:
                    serializer.Serialize(writer, "W_EVOLVE");
                    return;
                case BuffType.WSkill:
                    serializer.Serialize(writer, "W_SKILL");
                    return;
            }
            throw new Exception("Cannot marshal type BuffType");
        }

        public static readonly BuffTypeConverter Singleton = new BuffTypeConverter();
    }

    internal class FormulaTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FormulaType) || t == typeof(FormulaType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "F_ASC" => FormulaType.FAsc,
                "F_BUILDING" => FormulaType.FBuilding,
                "F_EVOLVE" => FormulaType.FEvolve,
                "F_SKILL" => FormulaType.FSkill,
                _ => throw new Exception("Cannot unmarshal type FormulaType"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FormulaType)untypedValue;
            switch (value)
            {
                case FormulaType.FAsc:
                    serializer.Serialize(writer, "F_ASC");
                    return;
                case FormulaType.FBuilding:
                    serializer.Serialize(writer, "F_BUILDING");
                    return;
                case FormulaType.FEvolve:
                    serializer.Serialize(writer, "F_EVOLVE");
                    return;
                case FormulaType.FSkill:
                    serializer.Serialize(writer, "F_SKILL");
                    return;
            }
            throw new Exception("Cannot marshal type FormulaType");
        }

        public static readonly FormulaTypeConverter Singleton = new FormulaTypeConverter();
    }

    internal class StoreyTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StoreyType) || t == typeof(StoreyType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "UPGROUND" => StoreyType.UPGROUND,
                "DOWNGROUND" => StoreyType.DOWNGROUND,
                _ => throw new Exception("Cannot unmarshal type StoreyType"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StoreyType)untypedValue;
            switch (value)
            {
                case StoreyType.UPGROUND:
                    serializer.Serialize(writer, "UPGROUND");
                    return;
                case StoreyType.DOWNGROUND:
                    serializer.Serialize(writer, "DOWNGROUND");
                    return;
            }
            throw new Exception("Cannot marshal type StoreyType");
        }

        public static readonly StoreyTypeConverter Singleton = new StoreyTypeConverter();
    }
}
