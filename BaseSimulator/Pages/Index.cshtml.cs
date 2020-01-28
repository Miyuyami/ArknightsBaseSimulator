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
