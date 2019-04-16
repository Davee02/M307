using System.Collections.Generic;
using M307_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace M307_Project.ViewModels
{
    public class RepairOrderViewModel
    {
        public RepairOrder RepairOrder { get; set; }

        public List<SelectListItem> AllTools { get; set; }

        public bool RepairIsInDeadline { get; set; }
    }
}
