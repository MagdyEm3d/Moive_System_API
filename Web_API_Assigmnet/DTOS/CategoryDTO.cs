using System.ComponentModel.DataAnnotations;

namespace Web_API_Assigmnet.DTOS
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
    }
}
