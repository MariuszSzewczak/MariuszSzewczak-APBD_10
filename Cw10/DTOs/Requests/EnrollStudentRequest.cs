using System;
using System.ComponentModel.DataAnnotations;

namespace Cw10.DTOs.Requests
{
    public class EnrollStudentRequest
    {
        [Required]
        public string IndexNumber { get; set; }
        [Required(ErrorMessage = "Musisz podac imie")]
        [MaxLength(100)] 
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Musisz podac nazwisko")]
        [MaxLength(100)]
        public string LastName { get; set; } 
        [Required(ErrorMessage = "Musisz podac date urodzenia")]
        public string BirthDate { get; set; }
        [Required(ErrorMessage = "Musisz podac nazwe studiow")]
        public string StudiesName { get; set; }
    }
}