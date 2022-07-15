using System;
using System.Collections.Generic;

namespace Train.Data.Models
{
    public partial class TrainInfo
    {
        public int TrainNo { get; set; }
        public string TrainName { get; set; } = null!;
        public string FromStation { get; set; } = null!;
        public string ToStation { get; set; } = null!;
        public DateTime JourneyStartTime { get; set; }
        public DateTime JourneyEndTime { get; set; }

        public virtual TrainDay TrainDay { get; set; } = null!;
    }
}
