using System;
using System.Collections.Generic;

namespace WebUI.DatabaseContext
{
    public partial class UserPriorityShows
    {
        public int PkPriorityId { get; set; }
        public int? FkShowId { get; set; }
        public string ShowName { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
