using MediaClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.Classes.APIClasses
{
    public class DailyAiringApiResult
    {
        public int page { get; set; }
        public List<DailyShowAiringViewModel> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }
}
