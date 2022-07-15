using System;
using System.Collections.Generic;

namespace Train.Data.Models
{
    public partial class TrainDay
    {
        public int TrainNumber { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public virtual TrainInfo TrainNumberNavigation { get; set; } = null!;
    }
}
