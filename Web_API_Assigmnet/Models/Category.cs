using System.ComponentModel.DataAnnotations;

namespace Web_API_Assigmnet.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        public List<Moive> Moives { get; set; }
    }
}
