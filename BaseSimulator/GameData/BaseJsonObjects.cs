using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace Arknights.Data
{
    public partial class BaseData
    {
        [J("controlSlotId")] public string ControlSlotId { get; set; }
        [J("meetingSlotId")] public string MeetingSlotId { get; set; }
        [J("initMaxLabor")] public int InitMaxLabor { get; set; }
        [J("laborRecoverTime")] public int LaborRecoverTime { get; set; }
        [J("manufactInputCapacity")] public int ManufactInputCapacity { get; set; }
        [J("shopCounterCapacity")] public int ShopCounterCapacity { get; set; }
        [J("comfortLimit")] public int ComfortLimit { get; set; }
        [J("creditInitiativeLimit")] public int CreditInitiativeLimit { get; set; }
        [J("creditPassiveLimit")] public int CreditPassiveLimit { get; set; }
        [J("creditComfortFactor")] public int CreditComfortFactor { get; set; }
        [J("creditGuaranteed")] public int CreditGuaranteed { get; set; }
        [J("creditCeiling")] public int CreditCeiling { get; set; }
        [J("manufactUnlockTips")] public string ManufactUnlockTips { get; set; }
        [J("shopUnlockTips")] public string ShopUnlockTips { get; set; }
        [J("manufactStationBuff")] public double ManufactStationBuff { get; set; }
        [J("comfortManpowerRecoverFactor")] public int ComfortManpowerRecoverFactor { get; set; }
        [J("manpowerDisplayFactor")] public int ManpowerDisplayFactor { get; set; }
        [J("shopOutputRatio")] public object ShopOutputRatio { get; set; }
        [J("shopStackRatio")] public object ShopStackRatio { get; set; }
        [J("basicFavorPerDay")] public int BasicFavorPerDay { get; set; }
        [J("humanResourceLimit")] public int HumanResourceLimit { get; set; }
        [J("tiredApThreshold")] public int TiredApThreshold { get; set; }
        [J("processedCountRatio")] public int ProcessedCountRatio { get; set; }
        [J("tradingStrategyUnlockLevel")] public int TradingStrategyUnlockLevel { get; set; }
        [J("tradingReduceTimeUnit")] public int TradingReduceTimeUnit { get; set; }
        [J("tradingLaborCostUnit")] public int TradingLaborCostUnit { get; set; }
        [J("manufactReduceTimeUnit")] public int ManufactReduceTimeUnit { get; set; }
        [J("manufactLaborCostUnit")] public int ManufactLaborCostUnit { get; set; }
        [J("laborAssistUnlockLevel")] public int LaborAssistUnlockLevel { get; set; }
        [J("apToLaborUnlockLevel")] public int ApToLaborUnlockLevel { get; set; }
        [J("apToLaborRatio")] public int ApToLaborRatio { get; set; }
        [J("socialResourceLimit")] public int SocialResourceLimit { get; set; }
        [J("socialSlotNum")] public int SocialSlotNum { get; set; }
        [J("furniDuplicationLimit")] public int FurniDuplicationLimit { get; set; }
        [J("manufactManpowerCostByNum")] public List<int> ManufactManpowerCostByNum { get; set; }
        [J("tradingManpowerCostByNum")] public List<int> TradingManpowerCostByNum { get; set; }
        [J("roomUnlockConds")] public Dictionary<string, RoomConditions> RoomUnlockConds { get; set; }
        [J("rooms")] public Dictionary<RoomType, Room> Rooms { get; set; }
        [J("layouts")] public Dictionary<LayoutVersion, Layout> Layouts { get; set; }
        [J("prefabs")] public Dictionary<string, Prefab> Prefabs { get; set; }
        [J("controlData")] public ControlData ControlData { get; set; }
        [J("manufactData")] public ManufactData ManufactData { get; set; }
        [J("shopData")] public ShopData ShopData { get; set; }
        [J("hireData")] public HireData HireData { get; set; }
        [J("dormData")] public DormData DormData { get; set; }
        [J("meetingData")] public MeetingData MeetingData { get; set; }
        [J("tradingData")] public TradingData TradingData { get; set; }
        [J("workshopData")] public WorkshopData WorkshopData { get; set; }
        [J("trainingData")] public TrainingData TrainingData { get; set; }
        [J("powerData")] public PowerData PowerData { get; set; }
        [J("chars")] public Dictionary<string, Char> Chars { get; set; }
        [J("buffs")] public Dictionary<string, Buff> Buffs { get; set; }
        [J("customData")] public CustomData CustomData { get; set; }
        [J("manufactFormulas")] public Dictionary<string, ManufactFormula> ManufactFormulas { get; set; }
        [J("shopFormulas")] public ShopFormulas ShopFormulas { get; set; }
        [J("workshopFormulas")] public Dictionary<string, WorkshopFormula> WorkshopFormulas { get; set; }
        [J("creditFormula")] public CreditFormula CreditFormula { get; set; }
        [J("goldItems")] public Dictionary<string, int> GoldItems { get; set; }
        [J("assistantUnlock")] public List<int> AssistantUnlock { get; set; }
    }

    public class Buff
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

    public class Char
    {
        [J("charId")] public string CharId { get; set; }
        [J("maxManpower")] public int MaxManpower { get; set; }
        [J("buffChar")] public List<BuffChar> BuffChar { get; set; }
    }

    public class BuffChar
    {
        [J("buffData")] public List<BuffDatum> BuffData { get; set; }
    }

    public class BuffDatum
    {
        [J("buffId")] public string BuffId { get; set; }
        [J("cond")] public Cond Cond { get; set; }
    }

    public class Cond
    {
        [J("phase")] public int Phase { get; set; }
        [J("level")] public int Level { get; set; }
    }

    public class CreditFormula
    {
        [J("initiative")] public ShopFormulas Initiative { get; set; }
        [J("passive")] public ShopFormulas Passive { get; set; }
    }

    public class ShopFormulas
    {
    }

    public class CustomData
    {
        [J("furnitures")] public Dictionary<string, Furniture> Furnitures { get; set; }
        [J("themes")] public Dictionary<string, Theme> Themes { get; set; }
        [J("groups")] public Dictionary<string, Group> Groups { get; set; }
        [J("types")] public Dictionary<string, TypeValue> Types { get; set; }
        [J("defaultFurnitures")] public DefaultFurnitures DefaultFurnitures { get; set; }
    }

    public class DefaultFurnitures
    {
        [J("room_dormitory_6x2")] public List<RoomDormitory6X2> RoomDormitory6X2 { get; set; }
    }

    public class RoomDormitory6X2
    {
        [J("furnitureId")] public string FurnitureId { get; set; }
        [J("xOffset")] public int XOffset { get; set; }
        [J("yOffset")] public int YOffset { get; set; }
        [J("defaultPrefabId")] public DefaultPrefabId DefaultPrefabId { get; set; }
    }

    public class Furniture
    {
        [J("id")] public string Id { get; set; }
        [J("name")] public string Name { get; set; }
        [J("iconId")] public string IconId { get; set; }
        [J("type")] public FurnitureType Type { get; set; }
        [J("location")] public Location Location { get; set; }
        [J("category")] public FurnitureCategory Category { get; set; }
        [J("rarity")] public int Rarity { get; set; }
        [J("themeId")] public string ThemeId { get; set; }
        [J("width")] public int Width { get; set; }
        [J("depth")] public int Depth { get; set; }
        [J("height")] public int Height { get; set; }
        [J("comfort")] public int Comfort { get; set; }
        [J("usage")] public string Usage { get; set; }
        [J("description")] public string Description { get; set; }
        [J("obtainApproach")] public string ObtainApproach { get; set; }
        [J("processedProductId")] public string ProcessedProductId { get; set; }
        [J("processedProductCount")] public int ProcessedProductCount { get; set; }
        [J("processedByProductPercentage")] public int ProcessedByProductPercentage { get; set; }
        [J("processedByProductGroup")] public List<object> ProcessedByProductGroup { get; set; }
        [J("canBeDestroy")] public bool CanBeDestroy { get; set; }
    }

    public class Group
    {
        [J("id")] public string Id { get; set; }
        [J("name")] public string Name { get; set; }
        [J("themeId")] public string ThemeId { get; set; }
        [J("comfort")] public int Comfort { get; set; }
        [J("count")] public int Count { get; set; }
        [J("furniture")] public List<string> Furniture { get; set; }
    }

    public class Theme
    {
        [J("id")] public string Id { get; set; }
        [J("name")] public string Name { get; set; }
        [J("desc")] public string Desc { get; set; }
        [J("quickSetup")] public List<QuickSetup> QuickSetup { get; set; }
    }

    public class QuickSetup
    {
        [J("furnitureId")] public string FurnitureId { get; set; }
        [J("pos0")] public int Pos0 { get; set; }
        [J("pos1")] public int Pos1 { get; set; }
    }

    public class TypeValue
    {
        [J("type")] public FurnitureType Type { get; set; }
        [J("name")] public string Name { get; set; }
    }

    public class Layout
    {
        [J("id")] public string Id { get; set; }
        [J("slots")] public Dictionary<string, Slot> Slots { get; set; }
        [J("cleanCosts")] public Dictionary<string, CleanCostType> CleanCostTypes { get; set; }
        [J("storeys")] public Dictionary<StoreyId, Storey> Storeys { get; set; }
    }

    public class CleanCostType
    {
        [J("id")] public string Id { get; set; }
        [J("number")] public Dictionary<int, CleanCost> CleanCostByNumber { get; set; }
    }

    public class CleanCost
    {
        [J("items")] public List<Cost> Items { get; set; }
    }

    public class Cost
    {
        [J("id")] public string ItemId { get; set; }
        [J("count")] public int Count { get; set; }
        [J("type")] public CostType Type { get; set; }
    }

    public class Slot
    {
        [J("id")] public string Id { get; set; }
        [J("cleanCostId")] public string CleanCostId { get; set; }
        [J("costLabor")] public int CostLabor { get; set; }
        [J("provideLabor")] public int ProvideLabor { get; set; }
        [J("size")] public Position Size { get; set; }
        [J("offset")] public Position Offset { get; set; }
        [J("category")] public RoomCategory Category { get; set; }
        [J("storeyId")] public StoreyId StoreyId { get; set; }
    }

    public class Position
    {
        [J("row")] public int Row { get; set; }
        [J("col")] public int Col { get; set; }
    }

    public class Storey
    {
        [J("id")] public StoreyId Id { get; set; }
        [J("yOffset")] public int YOffset { get; set; }
        [J("unlockControlLevel")] public int UnlockControlLevel { get; set; }
        [J("type")] public StoreyType Type { get; set; }
    }

    public class ControlData
    {
        [J("basicCostBuff")] public int BasicCostBuff { get; set; }
        [J("phases")] public List<ControlPhaseData> Phases { get; set; }
    }

    public class ControlPhaseData
    {

    }

    public class ManufactData
    {
        [J("basicSpeedBuff")] public double BasicSpeedBuff { get; set; }
        [J("phases")] public List<ManufactPhaseData> Phases { get; set; }
    }

    public class ManufactPhaseData
    {
        [J("speed")] public double Speed { get; set; }
        [J("outputCapacity")] public int OutputCapacity { get; set; }
    }

    public class ShopData
    {
        [J("phases")] public List<ShopPhaseData> Phases { get; set; }
    }

    public class ShopPhaseData
    {

    }

    public class HireData
    {
        [J("basicSpeedBuff")] public double BasicSpeedBuff { get; set; }
        [J("phases")] public List<HirePhaseData> Phases { get; set; }
    }

    public class HirePhaseData
    {
        [J("economizeRate")] public double EconomizeRate { get; set; }
        [J("resSpeed")] public int ResSpeed { get; set; }
        [J("refreshTimes")] public int RefreshTimes { get; set; }
    }

    public class DormData
    {
        [J("phases")] public List<DormPhaseData> Phases { get; set; }
    }

    public class DormPhaseData
    {
        [J("manpowerRecover")] public int ManpowerRecover { get; set; }
        [J("decorationLimit")] public int DecorationLimit { get; set; }
    }

    public class MeetingData
    {
        [J("basicSpeedBuff")] public double BasicSpeedBuff { get; set; }
        [J("phases")] public List<MeetingPhaseData> Phases { get; set; }
    }

    public class MeetingPhaseData
    {
        [J("friendSlotInc")] public int FriendSlotInc { get; set; }
        [J("maxVisitorNum")] public int MaxVisitorNum { get; set; }
        [J("gatheringSpeed")] public int GatheringSpeed { get; set; }
    }

    public class TradingData
    {
        [J("basicSpeedBuff")] public double BasicSpeedBuff { get; set; }
        [J("phases")] public List<TradingPhaseData> Phases { get; set; }
    }

    public class TradingPhaseData
    {
        [J("orderSpeed")] public double OrderSpeed { get; set; }
        [J("orderLimit")] public int OrderLimit { get; set; }
        [J("orderRarity")] public int OrderRarity { get; set; }
    }

    public class WorkshopData
    {
        [J("phases")] public List<WorkshopPhaseData> Phases { get; set; }
    }

    public class WorkshopPhaseData
    {
        [J("manpowerFactor")] public double ManpowerFactor { get; set; }
    }

    public class TrainingData
    {
        [J("basicSpeedBuff")] public double BasicSpeedBuff { get; set; }
        [J("phases")] public List<TrainingPhaseData> Phases { get; set; }
    }

    public class TrainingPhaseData
    {
        [J("specSkillLvlLimit")] public int SpecSkillLvlLimit { get; set; }
    }

    public class PowerData
    {
        [J("basicSpeedBuff")] public double BasicSpeedBuff { get; set; }
        [J("phases")] public List<PowerPhaseData> Phases { get; set; }
    }

    public class PowerPhaseData
    {

    }

    public class ManufactFormula
    {
        [J("formulaId")] public string FormulaId { get; set; }
        [J("itemId")] public string ItemId { get; set; }
        [J("count")] public int Count { get; set; }
        [J("weight")] public int Weight { get; set; }
        [J("costPoint")] public int CostPoint { get; set; }
        [J("formulaType")] public string FormulaType { get; set; }
        [J("buffType")] public string BuffType { get; set; }
        [J("costs")] public List<Cost> Costs { get; set; }
        [J("requireRooms")] public List<RequireRoom> RequireRooms { get; set; }
        [J("requireStages")] public List<object> RequireStages { get; set; }
    }

    public class RequireRoom
    {
        [J("roomId")] public RoomType RoomId { get; set; }
        [J("roomLevel")] public int RoomLevel { get; set; }
        [J("roomCount")] public int RoomCount { get; set; }
    }

    public class Prefab
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

    public class RoomCondition
    {
        [J("type")] public RoomType Type { get; set; }
        [J("level")] public int Level { get; set; }
        [J("count")] public int Count { get; set; }
    }

    public class Room
    {
        [J("id")] public RoomType Id { get; set; }
        [J("name")] public string Name { get; set; }
        [J("description")] public string Description { get; set; }
        [J("defaultPrefabId")] public string DefaultPrefabId { get; set; }
        [J("canLevelDown")] public bool CanLevelDown { get; set; }
        [J("maxCount")] public int MaxCount { get; set; }
        [J("category")] public RoomCategory Category { get; set; }
        [J("size")] public Position Size { get; set; }
        [J("phases")] public List<RoomPhase> Phases { get; set; }
    }

    public class RoomPhase
    {
        [J("overrideName")] public object OverrideName { get; set; }
        [J("overridePrefabId")] public object OverridePrefabId { get; set; }
        [J("unlockCondId")] public string UnlockCondId { get; set; }
        [J("buildCost")] public BuildCost BuildCost { get; set; }
        [J("electricity")] public int Electricity { get; set; }
        [J("maxStationedNum")] public int MaxStationedNum { get; set; }
        [J("manpowerCost")] public int ManpowerCost { get; set; }
    }

    public class BuildCost
    {
        [J("items")] public List<Cost> Items { get; set; }
        [J("time")] public int Time { get; set; }
        [J("labor")] public int Labor { get; set; }
    }

    public class WorkshopFormula
    {
        [J("formulaId")] public string FormulaId { get; set; }
        [J("rarity")] public int Rarity { get; set; }
        [J("itemId")] public string ItemId { get; set; }
        [J("count")] public int Count { get; set; }
        [J("goldCost")] public int GoldCost { get; set; }
        [J("apCost")] public int ApCost { get; set; }
        [J("formulaType")] public FormulaType FormulaType { get; set; }
        [J("buffType")] public BuffType BuffType { get; set; }
        [J("extraOutcomeRate")] public double ExtraOutcomeRate { get; set; }
        [J("extraOutcomeGroup")] public List<ExtraOutcomeGroup> ExtraOutcomeGroup { get; set; }
        [J("costs")] public List<Cost> Costs { get; set; }
        [J("requireRooms")] public List<RequireRoom> RequireRooms { get; set; }
        [J("requireStages")] public List<RequireStage> RequireStages { get; set; }
    }

    public class ExtraOutcomeGroup
    {
        [J("weight")] public int Weight { get; set; }
        [J("itemId")] public string ItemId { get; set; }
        [J("itemCount")] public int ItemCount { get; set; }
    }

    public class RequireStage
    {
        [J("stageId")] public string StageId { get; set; }
        [J("rank")] public int Rank { get; set; }
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
    public enum RoomCategory
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
        [EnumMember(Value = "")] None,
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
        public static BaseData FromJson(string json) => JsonConvert.DeserializeObject<BaseData>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this BaseData self) => JsonConvert.SerializeObject(self, Converter.Settings);
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
        public override bool CanConvert(Type t) => t == typeof(int) || t == typeof(int?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            if (Int32.TryParse(value, out int l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type int");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (int)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
