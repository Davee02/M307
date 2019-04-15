using System.ComponentModel.DataAnnotations;

namespace M307_Project.Models
{
    public class ErrorViewModel
    {
        [Required]
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}