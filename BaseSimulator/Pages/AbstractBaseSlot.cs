using Arknights.BaseSimulator.Data;
using Microsoft.AspNetCore.Components;

namespace Arknights.BaseSimulator
{
    public abstract class AbstractBaseSlot : ComponentBase
    {
        [CascadingParameter]
        public string Id { get; set; }

        [CascadingParameter]
        public Game Game { get; set; }

        [CascadingParameter]
        public bool IsInBuildMode { get; set; }
    }

    public abstract class AbstractClickableBaseSlot : AbstractBaseSlot
    {
        [Parameter]
        public EventCallback<SlotData> OnClick { get; set; }
    }
}
