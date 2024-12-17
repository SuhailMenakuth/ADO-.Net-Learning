using System.ComponentModel.DataAnnotations;

namespace ADOLearningPerson.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required]
        public string NAME { get; set; }

        [Range(1, 120)]
        public int AGE { get; set; }

        [Required]
        public string ADRESS { get; set; }
    }
}
