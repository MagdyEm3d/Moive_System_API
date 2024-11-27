using System.ComponentModel.DataAnnotations;

namespace Web_API_Assigmnet.DTOS
{
    public class NationalityDTO
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
    }
}
