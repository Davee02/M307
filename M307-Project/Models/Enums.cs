using System.ComponentModel.DataAnnotations;

namespace M307_Project.Models
{
    public static class Enums
    {
        public enum Severety
        {
            [Display(Name = "Really low")]
            ReallyLow = 0,
            [Display(Name = "Low")]
            Low = 1,
            [Display(Name = "Normal")]
            Normal = 2,
            [Display(Name = "High")]
            High = 3,
            [Display(Name = "Really high")]
            ReallyHigh = 4
        }
        public enum RepairState
        {
            [Display(Name = "Pending")]
            Pending = 0,
            [Display(Name = "Finished")]
            Finished = 1
        }
    }
}
