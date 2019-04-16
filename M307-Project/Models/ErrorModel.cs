using System.ComponentModel.DataAnnotations;

namespace M307_Project.Models
{
    public class ErrorModel
    {
        [Required]
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}