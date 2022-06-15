using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}