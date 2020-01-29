using System.Linq;
using Arknights.Data;

namespace Arknights.BaseSimulator.Data
{
    public class BaseService
    {
        public const double OneUnitSize = 50;

        public BaseData BaseData { get; }
        public Layout Layout => this.BaseData.Layouts[LayoutVersion.V0];
        public long MaxLayoutHeight => this.Layout.Slots.Values.Max(s => s.Offset.Row + s.Size.Row);

        public BaseService(BaseData baseData)
        {
            this.BaseData = baseData;
        }
    }
}
