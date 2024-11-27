using System.ComponentModel.DataAnnotations;

namespace Web_API_Assigmnet.Models
{
    public class Director
    {
        public int DirectorId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Phone(ErrorMessage ="Please Enter Valid Phone")]
        public string Contact {  get; set; }
        [EmailAddress(ErrorMessage ="Please Enter Valid Email")]
        public string Email { get; set; }

        public List<Moive> Moives { get; set; } 
        public int NationalityId { get; set; }  
        public Nationality Nationality { get; set; }

    }
}
