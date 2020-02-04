using Arknights.BaseSimulator.Data;
using Arknights.Data;
using Microsoft.AspNetCore.Components;

namespace Arknights.BaseSimulator
{
    public abstract class AbstractBaseSlot : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public Game Game { get; set; }

        [Parameter]
        public bool IsInBuildMode { get; set; }
    }

    public abstract class AbstractClickableBaseSlot : AbstractBaseSlot
    {
        [Parameter]
        public EventCallback<SlotData> OnClick { get; set; }
    }
}
