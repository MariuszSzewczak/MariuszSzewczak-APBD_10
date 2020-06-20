using System.ComponentModel.DataAnnotations;

namespace Cw10.DTOs.Requests
{
    public class DeleteStudentRequest
    {
        [Required]
        public string IndexNumber { get; set; }
    }
}