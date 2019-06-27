using MediaClasses.Classes.APIClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.ViewModels
{
    public class DailyShowAiringViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime first_air_date { get; set; }

        public DailyShowAiringViewModel(APIResult _result)
        {
            id = _result.id;
            name = _result.name;
            first_air_date = Convert.ToDateTime(_result.first_air_date);
        }

        public DailyShowAiringViewModel()
        {

        }


    }
}
