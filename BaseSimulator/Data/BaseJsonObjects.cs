using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
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
        [J("layouts")] public Dictionary<LayoutVersion, Layout> Layouts { get; set; }
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
        [J("usage")] public string Usage { get; set; }
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

    public partial class Layout
    {
        [J("id")] public string Id { get; set; }
        [J("slots")] public Dictionary<string, Slot> Slots { get; set; }
        [J("cleanCosts")] public Dictionary<string, CleanCostType> CleanCostTypes { get; set; }
        [J("storeys")] public Dictionary<StoreyId, Storey> Storeys { get; set; }
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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BuffCategory
    {
        [EnumMember(Value = "FUNCTION")] Function,
        [EnumMember(Value = "OUTPUT")] Output,
        [EnumMember(Value = "RECOVERY")] Recovery,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BuffColor
    {
        [EnumMember(Value = "#005752")] Hex005752,
        [EnumMember(Value = "#0075a9")] Hex0075A9,
        [EnumMember(Value = "#21cdcb")] Hex21CDCB,
        [EnumMember(Value = "#565656")] Hex565656,
        [EnumMember(Value = "#7d0022")] Hex7D0022,
        [EnumMember(Value = "#8fc31f")] Hex8FC31F,
        [EnumMember(Value = "#dd653f")] HexDD653F,
        [EnumMember(Value = "#e3eb00")] HexE3EB00,
        [EnumMember(Value = "#ffd800")] HexFFD800,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BuffIcon
    {
        [EnumMember(Value = "control")] Control,
        [EnumMember(Value = "dormitory")] Dormitory,
        [EnumMember(Value = "hire")] Hire,
        [EnumMember(Value = "manufacture")] Manufacture,
        [EnumMember(Value = "meeting")] Meeting,
        [EnumMember(Value = "power")] Power,
        [EnumMember(Value = "trading")] Trading,
        [EnumMember(Value = "training")] Training,
        [EnumMember(Value = "workshop")] Workshop,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoomType
    {
        [EnumMember(Value = "CONTROL")] Control,
        [EnumMember(Value = "CORRIDOR")] Corridor,
        [EnumMember(Value = "DORMITORY")] Dormitory,
        [EnumMember(Value = "ELEVATOR")] Elevator,
        [EnumMember(Value = "FUNCTIONAL")] Functional,
        [EnumMember(Value = "HIRE")] Hire,
        [EnumMember(Value = "MANUFACTURE")] Manufacture,
        [EnumMember(Value = "MEETING")] Meeting,
        [EnumMember(Value = "NONE")] None,
        [EnumMember(Value = "POWER")] Power,
        [EnumMember(Value = "TRADING")] Trading,
        [EnumMember(Value = "TRAINING")] Training,
        [EnumMember(Value = "WORKSHOP")] Workshop,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextColor
    {
        [EnumMember(Value = "#333333")] Hex333333,
        [EnumMember(Value = "#ffffff")] HexFFFFFF,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DefaultPrefabId
    {
        [EnumMember(Value = "room_dormitory_6x2")] RoomDormitory6X2,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FurnitureCategory
    {
        [EnumMember(Value = "FLOOR")] Floor,
        [EnumMember(Value = "FURNITURE")] Furniture,
        [EnumMember(Value = "WALL")] Wall,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Location
    {
        [EnumMember(Value = "CARPET")] Carpet,
        [EnumMember(Value = "CEILING")] Ceiling,
        [EnumMember(Value = "FLOOR")] Floor,
        [EnumMember(Value = "NONE")] None,
        [EnumMember(Value = "POSTER")] Poster,
        [EnumMember(Value = "WALL")] Wall,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FurnitureType
    {
        [EnumMember(Value = "BEDDING")] Bedding,
        [EnumMember(Value = "CABINET")] Cabinet,
        [EnumMember(Value = "CARPET")] Carpet,
        [EnumMember(Value = "CEILING")] Ceiling,
        [EnumMember(Value = "CEILINGLAMP")] Ceilinglamp,
        [EnumMember(Value = "DECORATION")] Decoration,
        [EnumMember(Value = "FLOOR")] Floor,
        [EnumMember(Value = "SEATING")] Seating,
        [EnumMember(Value = "TABLE")] Table,
        [EnumMember(Value = "WALLDECO")] Walldeco,
        [EnumMember(Value = "WALLLAMP")] Walllamp,
        [EnumMember(Value = "WALLPAPER")] Wallpaper,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CostType
    {
        [EnumMember(Value = "GOLD")] Gold,
        [EnumMember(Value = "MATERIAL")] Material,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PurpleCategory
    {
        [EnumMember(Value = "CORRIDOR")] Corridor,
        [EnumMember(Value = "CUSTOM")] Custom,
        [EnumMember(Value = "ELEVATOR")] Elevator,
        [EnumMember(Value = "FUNCTION")] Function,
        [EnumMember(Value = "OUTPUT")] Output,
        [EnumMember(Value = "SPECIAL")] Special,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum StoreyId
    {
        [EnumMember(Value = "")] Empty,
        [EnumMember(Value = "1F")] F1,
        [EnumMember(Value = "B1")] B1,
        [EnumMember(Value = "B2")] B2,
        [EnumMember(Value = "B3")] B3,
        [EnumMember(Value = "B4")] B4,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BuffType
    {
        [EnumMember(Value = "W_ASC")] WAsc,
        [EnumMember(Value = "W_BUILDING")] WBuilding,
        [EnumMember(Value = "W_EVOLVE")] WEvolve,
        [EnumMember(Value = "W_SKILL")] WSkill,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FormulaType
    {
        [EnumMember(Value = "F_ASC")] FAsc,
        [EnumMember(Value = "F_BUILDING")] FBuilding,
        [EnumMember(Value = "F_EVOLVE")] FEvolve,
        [EnumMember(Value = "F_SKILL")] FSkill,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum StoreyType
    {
        [EnumMember(Value = "UPGROUND")] UPGROUND,
        [EnumMember(Value = "DOWNGROUND")] DOWNGROUND,
    };

    [JsonConverter(typeof(StringEnumConverter))]
    public enum LayoutVersion
    {
        [EnumMember(Value = "v0")] V0,
    }

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
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
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
}
