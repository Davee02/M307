using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M307_Project.Models
{
    public class Enums
    {
        public enum Severety
        {
            ReallyLow = 0,
            Low = 1,
            Normal = 2,
            High = 3,
            ReallyHigh = 4
        }
        public enum RepairState
        {
            Pending = 0,
            Finished = 1
        }
    }
}
