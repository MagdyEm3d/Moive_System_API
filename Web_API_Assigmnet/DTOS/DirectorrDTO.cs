using System.ComponentModel.DataAnnotations;

namespace Web_API_Assigmnet.DTOS
{
    public class DirectorrDTO
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Phone(ErrorMessage = "Please Enter Valid Phone")]
        public string Contact { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        public List<MoiveeDTO> MoiveeDTOs { get; set; }

        public NationalityDTO NationalityDTO { get; set; }
    }
}
