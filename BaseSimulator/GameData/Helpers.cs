using System;

namespace Arknights.Data
{
    public static class Helpers
    {
        public static RoomType ToRoomType(this RoomTypeCondition cond) =>
            cond switch
            {
                RoomTypeCondition.Control => RoomType.Control,
                RoomTypeCondition.Power => RoomType.Power,
                RoomTypeCondition.Manufacture => RoomType.Manufacture,
                RoomTypeCondition.Trading => RoomType.Trading,
                RoomTypeCondition.Dormitory => RoomType.Dormitory,
                RoomTypeCondition.Workshop => RoomType.Workshop,
                RoomTypeCondition.Hire => RoomType.Hire,
                RoomTypeCondition.Training => RoomType.Training,
                RoomTypeCondition.Meeting => RoomType.Meeting,
                RoomTypeCondition.Elevator => RoomType.Elevator,
                RoomTypeCondition.Corridor => RoomType.Corridor,
                _ => throw new NotSupportedException(),
            };

        public static RoomTypeCondition ToRoomTypeCondition(this RoomType roomType) =>
            roomType switch
            {
                RoomType.Control => RoomTypeCondition.Control,
                RoomType.Power => RoomTypeCondition.Power,
                RoomType.Manufacture => RoomTypeCondition.Manufacture,
                RoomType.Trading => RoomTypeCondition.Trading,
                RoomType.Dormitory => RoomTypeCondition.Dormitory,
                RoomType.Workshop => RoomTypeCondition.Workshop,
                RoomType.Hire => RoomTypeCondition.Hire,
                RoomType.Training => RoomTypeCondition.Training,
                RoomType.Meeting => RoomTypeCondition.Meeting,
                RoomType.Elevator => RoomTypeCondition.Elevator,
                RoomType.Corridor => RoomTypeCondition.Corridor,
                _ => throw new NotSupportedException(),
            };
    }
}
