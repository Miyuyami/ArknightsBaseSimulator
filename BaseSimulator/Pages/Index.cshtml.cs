using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arknights.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Arknights.BaseSimulator.Pages
{
    public class IndexModel : PageModel
    {
        public readonly double OneUnitSize = 50;

        private ILogger<IndexModel> Logger { get; }
        
        public BaseData BaseData { get; }
        public Layout Layout => this.BaseData.Layouts[LayoutVersion.V0];
        public long MaxLayoutHeight => this.Layout.Slots.Values.Max(s => s.Offset.Row + s.Size.Row);

        public IndexModel(ILogger<IndexModel> logger, BaseData baseData)
        {
            this.Logger = logger;
            this.BaseData = baseData;
        }

        public void OnGet()
        {

        }
    }
}
