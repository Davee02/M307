using System.ComponentModel;

namespace M307_Project.Models
{
    public class Enums
    {
        public enum Severety
        {
            [DisplayName("Really low")]
            ReallyLow = 0,
            [DisplayName("Low")]
            Low = 1,
            [DisplayName("Normal")]
            Normal = 2,
            [DisplayName("High")]
            High = 3,
            [DisplayName("Really high")]
            ReallyHigh = 4
        }
        public enum RepairState
        {
            [DisplayName("Pending")]
            Pending = 0,
            [DisplayName("Finished")]
            Finished = 1
        }
    }
}
