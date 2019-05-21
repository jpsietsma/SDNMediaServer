using System;
using System.Collections.Generic;

namespace WebUI.DatabaseContext
{
    public partial class SortQueue
    {
        public int PkFileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Classification { get; set; }
        public string ClassificationDate { get; set; }
        public string ShowName { get; set; }
        public string ShowSeason { get; set; }
        public string ShowDrive { get; set; }
    }
}
