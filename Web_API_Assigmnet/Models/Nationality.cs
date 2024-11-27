using System.ComponentModel.DataAnnotations;

namespace Web_API_Assigmnet.Models
{
    public class Nationality
    {
        public int NationalityId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        public Director Director { get; set; }
    }
}
