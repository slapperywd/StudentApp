using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field can not be blank")]
        public string Name { get; set; }
    }
}