using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName field can not be blank")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName field can not be blank")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Faculty field can not be blank")]
        public string Faculty { get; set; }

        [Required(ErrorMessage = "Group id can not be blank and must be specified")]
        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}