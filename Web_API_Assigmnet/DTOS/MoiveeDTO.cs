using System.ComponentModel.DataAnnotations;

namespace Web_API_Assigmnet.DTOS
{
    public class MoiveeDTO
    {
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter ReleaseYear")]
        public DateTime ReleaseYear { get; set; }

        public CategoryDTO CategoryDTO { get; set; }
    }
}
