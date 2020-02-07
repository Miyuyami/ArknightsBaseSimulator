using System;
using Arknights.Data;

namespace Arknights.BaseSimulator
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
    }
}
