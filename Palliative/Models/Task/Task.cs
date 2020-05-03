using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palliative.Models.Task
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public bool IsPeriodic { get; set; }
        public int IntervalInDays { get; set; }
        public DateTime? End { get; set; }
    }
}
